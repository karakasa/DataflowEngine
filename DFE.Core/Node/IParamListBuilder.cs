using DFE.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node
{
    public interface IParamListBuilder
    {
        public int Add<T>(string name, ExpectedDataStructure type = ExpectedDataStructure.AsItem);
        public int AddGeneric(string name, ExpectedDataStructure type = ExpectedDataStructure.AsItem);
    }
}
