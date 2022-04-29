using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Data
{
    public class ExtendedStorage : ICloneable
    {
        public int Count { get; } = 0;
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
