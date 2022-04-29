using DFE.Core.Graphics;
using DFE.Core.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.VisualObject
{
    public class BasicNodeRepresentation : IVisualObject
    {
        private readonly Component _node;

        public Guid Id => throw new NotImplementedException();

        public virtual void Dispose()
        {
        }

        public void Render(ICanvas canvas, IDrawingContext context)
        {
            throw new NotImplementedException();
        }

        public BasicNodeRepresentation(Component node)
        {
            _node = node;
        }
    }
}
