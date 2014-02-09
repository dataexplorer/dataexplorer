using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Panes.Legend.Colors
{
    public class ColorLegend : BaseLegend
    {
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items",
            typeof(List<ColorLegendItemViewModel>),
            typeof(ColorLegend),
            new PropertyMetadata(OnItemsChanged));

        public List<ColorLegendItemViewModel> Items
        {
            get { return (List<ColorLegendItemViewModel>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        protected override void RenderItems()
        {
            base.PreRenderItems();

            var items = GetValue(ItemsProperty) as List<ColorLegendItemViewModel>;

            if (items == null || !items.Any())
            {
                Height = 0;
                return;
            }

            Height = items.Count * 20 + 16 + 8;

            var x = 16d;
            
            var originY = 32d;
            
            var pen = new Pen(Brushes.Black, 1);

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                
                double y = originY + i * 20;

                var visual = new DrawingVisual();

                using (var context = visual.RenderOpen())
                {
                    var brush = new SolidColorBrush(item.Color);
                    var rectangle = new Rect(x - 8, y - 8, 16, 16);
                    context.DrawRectangle(brush, pen, rectangle);
                }
                
                _visuals.Add(visual);

                var labelVisual = new DrawingVisual();

                using (var context = labelVisual.RenderOpen())
                {
                    var text = new FormattedText(
                        item.Label,
                        CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        12,
                        Brushes.Black);

                    context.DrawText(text, new Point(32, y - text.Height / 2));
                }
                _visuals.Add(labelVisual);
            }

            base.PostRenderItems();
        }
    }
}
