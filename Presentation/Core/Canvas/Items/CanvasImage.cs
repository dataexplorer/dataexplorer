using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DataExplorer.Presentation.Core.Canvas.Items
{
    public class CanvasImage : CanvasItem
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public BitmapImage Image { get; set; }

        public override VisualItem Draw()
        {
            var visual = new VisualItem();

            visual.Id = Id;
            
            double x = X - Width / 2;
            double y = Y - Height / 2;
            double scaleX = Width / Image.Width;
            double scaleY = Height / Image.Height;
            double imageScale = Math.Min(scaleX, scaleY);
            double imageWidth = Image.Width * imageScale;
            double imageHeight = Image.Height * imageScale;
            double imageX = X - imageWidth / 2;
            double imageY = Y - imageHeight / 2;

            var pen = GetPen();

            using (var context = visual.RenderOpen())
            {
                var rectangle = new Rect(x, y, Width, Height);
                
                context.DrawRectangle(Brushes.White, pen, rectangle);

                var imageRectangle = new Rect(imageX, imageY, imageWidth, imageHeight);
                
                context.DrawImage(Image, imageRectangle);
            }

            return visual;
        }
    }
}
