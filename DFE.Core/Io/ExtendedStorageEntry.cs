using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Io
{
    public struct ExtendedStorageEntry
    {
        public object Data { get; private set; }
        public bool Sensitive { get; private set; }
    }
}
