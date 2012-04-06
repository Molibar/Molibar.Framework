namespace Molibar.Infrastructure.DataAccess
{
    public class ParametersAndReader<T>
    {
        private SqlParameterHandler _parameters = delegate { };
        private RecordReaderDelegate<T> _reader = delegate { return default(T); };

        public SqlParameterHandler Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public RecordReaderDelegate<T> RecordReader
        {
            get { return _reader; }
            set { _reader = value; }
        }
    }
}