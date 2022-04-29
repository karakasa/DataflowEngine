using DFE.Core.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.VisualObject
{
    public interface IVisualObject : IDisposable
    {
        public Guid Id { get; }
        public void Render(ICanvas canvas, IDrawingContext context);
    }
}
