using DFE.Core.Data;
using DFE.Core.Node.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node.BuiltIn
{
    [MayNotRequireAllInputs]
    public abstract class Conditional : Component
    {
        public override void BuildParameters(IInputOutputBuilder builder)
        {
            var input = builder.InputBuilder;

            input.Add<bool>("condition");
            input.AddGeneric("whenTrue");
            input.AddGeneric("whenFalse");

            var output = builder.OutputBuilder;

            output.AddGeneric("triaged");
        }
        public override void Compute(IDataAccess data)
        {
            var triageBool = data.GetAsItem<bool>(0);
            var desiredIndex = triageBool ? 2 : 1;
        }
    }
}
