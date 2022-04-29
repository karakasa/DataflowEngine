using DFE.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFE.Core.Io
{
    public class ExtendedStorage : IDfeSerializable
    {
        private readonly Dictionary<string, ExtendedStorageEntry> _entrys = new();
        public int Count => _entrys.Count;
        public bool RedactSensitiveInformation()
        {
            var removed = false;
            var keys = _entrys.Keys.ToArray();
            foreach (var key in keys)
            {
                if (_entrys[key].Sensitive)
                    removed = true;

                _entrys.Remove(key);
            }

            return removed;
        }
    }
}
