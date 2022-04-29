using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node.Attributes
{
    /// <summary>
    /// Hint the executor the node must be run synchronously.
    /// Optional group indicator for more control. See <see cref="SynchronizationGroup"/> for more information.
    /// This hinting is for nodes utilizing non-parallelable resources.
    /// Be advised nodes isn't guaranteed be parallelized without this attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MustRunSynchronouslyAttribute : Attribute
    {
        /// <summary>
        /// Indicate the sync group. Only one node from the same group will be executed at once.
        /// If no group is indicated, the node will be executed exclusively.
        /// </summary>
        public string SynchronizationGroup { get; set; } = null;
    }
}
