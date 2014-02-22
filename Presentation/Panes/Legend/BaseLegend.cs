using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Panes.Legend
{
    public abstract class BaseLegend : FrameworkElement
    {
        protected static readonly double Padding = 4d;
        protected static readonly double ItemPadding = 2d;
        protected static readonly double TextHeight = 16d;
        
        private DrawingVisual _backgroundVisual;
        private DrawingVisual _titleVisual;
        protected readonly List<Visual> _visuals = new List<Visual>();

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", 
            typeof(string), 
            typeof(BaseLegend), 
            new PropertyMetadata(OnTitleChanged));

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        protected override int VisualChildrenCount
        {
            get { return _visuals.Count + 2; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _visuals.Count + 2)
                throw new ArgumentOutOfRangeException("index");

            if (index == 0)
                return null;// _backgroundVisual;
            
            if (index == 1)
                return _titleVisual;
            
            return _visuals[index - 2];
        }

        protected void RenderBackground()
        {
            var backgroundVisual = new DrawingVisual();

            using (var context = backgroundVisual.RenderOpen())
            {
                var rectangle = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
                context.DrawRectangle(Brushes.White, new Pen(Brushes.White, 0), rectangle);
            }

            //_backgroundVisual = backgroundVisual;

            _visuals.Add(backgroundVisual);
            
        }

        protected void RenderTitle()
        {
            var title = (string) GetValue(TitleProperty);

            if (title == null)
                return;
            
            RemoveVisualChild(_titleVisual);
            RemoveLogicalChild(_titleVisual);

            _titleVisual = new DrawingVisual();
            using (var context = _titleVisual.RenderOpen())
            {
                var text = new FormattedText(
                    title,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Verdana"),
                    12,
                    Brushes.Black);

                context.DrawText(text, new Point(4, 16 - text.Height / 2));
            }
            
            AddVisualChild(_titleVisual);
            AddLogicalChild(_titleVisual);
        }

        protected abstract void RenderItems();

        protected void PreRenderItems()
        {
            foreach (var visual in _visuals)
            {
                RemoveVisualChild(visual);
                RemoveLogicalChild(visual);
            }
            
            _visuals.Clear();
        }

        protected void PostRenderItems()
        {
            foreach (var visual in _visuals)
            {
                AddVisualChild(visual);
                AddLogicalChild(visual);
            }    
        }

        private static void OnTitleChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((BaseLegend) source).RenderTitle();
        }

        protected static void OnItemsChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((BaseLegend) source).RenderItems();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            RenderBackground();
            RenderTitle();
            RenderItems();
        }
    }
}
