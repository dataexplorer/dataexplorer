using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public abstract class CanvasItem
    {
        public int? Id { get; set; }

        public bool IsSelected { get; set; }

        public abstract VisualItem Draw();
    }
}
