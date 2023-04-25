using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGDrawer
{
    public class SvgZoom
    {
        public float ZoomLevel { get; private set; } = 1.0f;

        public void ZoomIn()
        {
            ZoomLevel += 0.1f;
        }

        public void ZoomOut()
        {
            ZoomLevel -= 0.1f;
            ZoomLevel = Math.Max(ZoomLevel, 0.1f);
        }
    }
}
