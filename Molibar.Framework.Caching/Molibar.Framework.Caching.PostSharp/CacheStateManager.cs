using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Molibar.Caching.PostSharp
{
    [Serializable]
    public class CacheStateManager : ISerializable
    {
        private const string SerializationInfoIdentifier = "state";
        private readonly Dictionary<int, List<int>> _cacheStates = new Dictionary<int, List<int>>();

        public CacheStateManager() { }

        /// <summary>
        /// Creates a <see cref="CacheStateManager"/> by deserializing the specified serialized state.
        /// </summary>
        public CacheStateManager(string serializedState)
        {
            DeserializeState(serializedState);
        }

        protected CacheStateManager(SerializationInfo information, StreamingContext context)
        {
            DeserializeState(information.GetString(SerializationInfoIdentifier));
        }

        public void InvalidateCache(string key)
        {
            var hash = key.GetHashCode();
            _cacheStates.Remove(hash);
            _cacheStates.Add(hash, new List<int>());
        }

        public bool IsCacheStale(string key, string machineName)
        {
            var identifierHash = key.GetHashCode();
            var machineHash = machineName.GetHashCode();

            List<int> states;
            if (_cacheStates.TryGetValue(identifierHash, out states))
            {
                return !states.Contains(machineHash);
            }

            return false;
        }

        public void ClearStaleFlag(string key, string machineName)
        {
            var identifierHash = key.GetHashCode();
            var machineHash = machineName.GetHashCode();

            List<int> states;
            if (_cacheStates.TryGetValue(identifierHash, out states))
            {
                states.Add(machineHash);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var state in _cacheStates)
            {
                if (builder.Length > 0)
                {
                    builder.Append(";");
                }

                builder.Append(state.Key.ToString("X") + ":");

                bool first = true;
                foreach (var machineId in state.Value)
                {
                    builder.Append((first ? "" : ",") + machineId.ToString("X"));
                    first = false;
                }
            }

            return builder.ToString();
        }

        private static int ParseHex(string value)
        {
            int result;
            if (int.TryParse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }

            throw new Exception(string.Format("Can not parse '{0}' to integer.", value));
        }

        private void DeserializeState(string serializedState)
        {
            if (string.IsNullOrEmpty(serializedState)) return;

            foreach (var entry in serializedState.Split(';'))
            {
                var parts = entry.Split(':');

                if (parts.Length != 2)
                {
                    throw new Exception(string.Format("Invalid format of serialized state ({0}).", entry));
                }

                var cacheIdentifier = ParseHex(parts[0]);
                var machines = parts[1];

                _cacheStates.Add(cacheIdentifier, machines.Split(',').Where(value => !string.IsNullOrEmpty(value)).Select(value => ParseHex(value)).ToList());
            }
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(SerializationInfoIdentifier, ToString());
        }

        #endregion
    }
}