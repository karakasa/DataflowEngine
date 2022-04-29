using DFE.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node
{
    public interface IDataAccess
    {
        public bool IsInputProvided(int index);
        public bool IsInputAvailableIn<T>(int index);
        public T GetAsItem<T>(int index);
        public ITree GetAsTree(int index);
    }
}
