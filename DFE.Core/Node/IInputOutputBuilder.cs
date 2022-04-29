using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node
{
    public interface IInputOutputBuilder
    {
        public IParamListBuilder InputBuilder { get; }
        public IParamListBuilder OutputBuilder { get; }
    }
}
