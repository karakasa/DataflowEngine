using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Graphics
{
    public interface ICanvasStyler
    {
        public void DrawStandardNodeBox(
            Coord2d pivot,
            string name,
            IImage icon,
            IEnumerable<string> inputNames,
            IEnumerable<string> outputNames
            );
    }
}
