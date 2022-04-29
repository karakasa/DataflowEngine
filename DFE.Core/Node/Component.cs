using DFE.Core.VisualObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node
{
    /// <summary>
    /// A basic implentation of simple nodes with inputs and outputs.
    /// </summary>
    public abstract class Component : INodeBase
    {
        private BasicNodeRepresentation _visualRepresentation = null;
        private List<INodeBase> Inputs;
        private List<INodeBase> Outputs;

        /// <summary>
        /// Id of the component
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// DFE allows correct release of unmanaged resources or clean-up by natural
        /// Override this method for custom handling.
        /// </summary>
        public virtual void Dispose()
        {
        }

        public virtual IList<INodeBase> GetDownstreamObjects() => Inputs;

        public virtual IList<INodeBase> GetUpstreamObjects() => Outputs;

        public virtual bool TryGetVisualRepresentation(out IVisualObject representation)
        {
            representation = _visualRepresentation ??= new BasicNodeRepresentation(this);
            return _visualRepresentation != null;
        }
        public virtual void CollectOutputs(IRequiredOutputs requiredOutputs)
        {
            throw new NotImplementedException();
        }
        public abstract void Compute(IDataAccess data);
        public abstract void BuildParameters(IInputOutputBuilder builder);
    }
}
