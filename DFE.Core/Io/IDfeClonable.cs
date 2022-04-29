using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Io
{
    public interface IDfeClonable<T>
    {
        public T Clone();
    }
}
