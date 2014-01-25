using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Controls
{
    public class ColorPaletteControl : FrameworkElement
    {
        private readonly List<Visual> _visuals = new List<Visual>();

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", 
            typeof(List<Color>), 
            typeof(ColorPaletteControl), 
            new PropertyMetadata(OnItemsChanged));
        
        public List<Color> ItemsSource
        {
            get { return (List<Color>) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public ColorPaletteControl()
        {
            Render();
            Height = 16;
        }

        public ColorPaletteControl(List<Color> colorPalette)
        {
            SetValue(ItemsSourceProperty, colorPalette);
            Height = 16;
        }

        protected override int VisualChildrenCount
        {
            get { return _visuals.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _visuals.Count)
                throw new ArgumentOutOfRangeException("index");
            
            return _visuals[index];
        }

        private void Render()
        {
            ClearExistingVisuals();

            var colors = (List<Color>) GetValue(ItemsSourceProperty);
            
            if (colors == null)
                return;
            
            var size = GetSize(colors);

            DrawColorTiles(colors, size);

            AddNewVisuals();
        }

        private void ClearExistingVisuals()
        {
            foreach (var visual in _visuals)
            {
                RemoveVisualChild(visual);
                RemoveLogicalChild(visual);
            }
        }

        private Size GetSize(List<Color> colors)
        {
            var size = new Size()
            {
                Width = ActualWidth/colors.Count(),
                Height = ActualHeight
            };

            return size;
        }

        private void DrawColorTiles(List<Color> colors, Size size)
        {
            for (var i = 0; i < colors.Count; i++)
            {
                var drawingVisual = DrawColorTile(colors, i, size);

                _visuals.Add(drawingVisual);
            }
        }

        private static DrawingVisual DrawColorTile(List<Color> colors, int index, Size size)
        {
            var x = size.Width * index;

            var drawingVisual = new DrawingVisual();
            
            using (var context = drawingVisual.RenderOpen())
            {
                var color = colors[index];
                
                var brush = new SolidColorBrush(color);
                
                var rectangle = new Rect(x, 0, size.Width, size.Height);
                
                context.DrawRectangle(brush, null, rectangle);
            }

            return drawingVisual;
        }

        private void AddNewVisuals()
        {
            foreach (var visual in _visuals)
            {
                AddVisualChild(visual);
                AddLogicalChild(visual);
            }
        }

        private static void OnItemsChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((ColorPaletteControl) source).Render();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            Render();
        }
    }
}
