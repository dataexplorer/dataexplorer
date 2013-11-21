using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Tests.Presentation.Core.Canvas.Items
{
    public class FakeCanvasItem : CanvasItem
    {
        public override VisualItem Draw()
        {
            throw new NotImplementedException();
        }
    }
}
