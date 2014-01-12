using System;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Tests.Core.Canvas.Items
{
    public class FakeCanvasItem : CanvasItem
    {
        public override VisualItem Draw()
        {
            throw new NotImplementedException();
        }
    }
}
