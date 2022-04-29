using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node.Attributes
{
    /// <summary>
    /// Support calculating not all outputs for better performance. It improves the performance of lazy evaluation.
    /// If supported, <see cref="INodeBase.CollectOutputs(IRequiredOutputs)"/> will receive a non-null argument indicating what outputs are required.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SupportPartialOutputAttribute : Attribute
    {
    }
}
