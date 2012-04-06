using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Molibar.Infrastructure.DataAccess
{
    public interface IDbAccessor
    {
        string ConnectionString { get; }

        List<T> PerformSpRead<T>(ParametersAndReader<T> parametersAndReader, string storedProcedureName);
        T PerformSpReadSingle<T>(ParametersAndReader<T> parametersAndReader, string storedProcedureName);
        T PerformSpScalar<T>(string storeProcedureName, SqlParameterHandler handler);
        void PerformSpNonQuery(string storedProcedureName, SqlParameterHandler handler);
    }

    public delegate T RecordReaderDelegate<out T>(SqlDataReader reader);
    public delegate void SqlCommandHandler(SqlCommand command);
    public delegate void SqlParameterHandler(SqlParameterCollection parameterCollection);

    public class DbAccessor : IDbAccessor
    {
        private readonly string _connectionString;
        public string ConnectionString { get { return _connectionString; } }

        public DbAccessor(IDatabaseConnectionStringProvider provider)
        {
            _connectionString = provider.ConnectionString;
        }



        public T PerformSpReadSingle<T>(ParametersAndReader<T> parametersAndReader, string storedProcedureName)
        {
            return ExecuteStoredProcedure(storedProcedureName, parametersAndReader,
                                          reader =>
                                          {
                                              T result = default(T);

                                              if (reader != null)
                                              {
                                                  if (reader.Read())
                                                  {
                                                      result = parametersAndReader.RecordReader(reader);
                                                  }
                                              }

                                              return result;

                                          });
        }

        public List<T> PerformSpRead<T>(ParametersAndReader<T> parametersAndReader, string storedProcedureName)
        {
            return ExecuteStoredProcedure(storedProcedureName, parametersAndReader, reader =>
            {
                var result = new List<T>();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        result.Add(parametersAndReader.RecordReader(reader));
                    }
                }

                return result;
            });
        }

        public T PerformSpScalar<T>(string storeProcedureName, SqlParameterHandler handler)
        {
            return ExecuteCommand(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storeProcedureName;
                handler(cmd.Parameters);
                var x = cmd.ExecuteScalar();
                return (T)x;
            });
        }

        private TResult ExecuteStoredProcedure<T, TResult>(string storedProcedureName, ParametersAndReader<T> parametersAndReader, Func<SqlDataReader, TResult> func)
        {
            return ExecuteCommand(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedureName;

                parametersAndReader.Parameters(cmd.Parameters);

                using (var reader = cmd.ExecuteReader())
                {
                    return func(reader);
                }
            });
        }

        public void PerformSpNonQuery(string storedProcedureName, SqlParameterHandler handler)
        {
            ExecuteCommand(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedureName;
                handler(cmd.Parameters);
                cmd.ExecuteNonQuery();
            });
        }

        private T ExecuteCommand<T>(Func<SqlCommand, T> func)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    return func(cmd);
                }
            }
        }

        private void ExecuteCommand(Action<SqlCommand> action)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    action(cmd);
                }
            }
        }
    }
}