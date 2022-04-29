using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node.Attributes
{
    /// <summary>
    /// Tell executors that the node may not require all inputs to be calculated.
    /// This attribute enabled lazy computing. Some unnecessary nodes will not calculated.
    /// For example, this attribute could be used in a shortcuted if-statement.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MayNotRequireAllInputsAttribute : Attribute
    {
    }
}
