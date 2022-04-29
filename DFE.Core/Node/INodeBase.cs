using DFE.Core.VisualObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Node
{
    public interface INodeBase : IDisposable
    {
        public Guid Id { get; }
        public bool TryGetVisualRepresentation(out IVisualObject representation);
        public IList<INodeBase> GetUpstreamObjects();
        public IList<INodeBase> GetDownstreamObjects();        
        public void CollectOutputs(IRequiredOutputs requiredOutputs);
    }
}
