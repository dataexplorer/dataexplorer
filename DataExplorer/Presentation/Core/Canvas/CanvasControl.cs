using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Events;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Core.Canvas
{
    public class CanvasControl : FrameworkElement
    {
        private readonly IDependencyPropertyService _propertyService;
        private readonly ICanvasRenderer _renderer;
        private readonly IVisualService _visualService;

        public event CanvasPanEvent Pan;
        public event CanvasZoomInEvent ZoomIn;
        public event CanvasZoomOutEvent ZoomOut;

        public static readonly DependencyProperty ControlSizeProperty = DependencyProperty.Register(
            "ControlSize",
            typeof(Size),
            typeof(CanvasControl),
            new PropertyMetadata());

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items",
            typeof(List<ICanvasItem>),
            typeof(CanvasControl),
            new PropertyMetadata(new List<ICanvasItem>(), HandleItemsChanged));

        private bool _isMouseDown;
        private Point _previousMousePosition;

        public Size ControlSize
        {
            get { return (Size) _propertyService.GetValue(ControlSizeProperty); }
            set { _propertyService.SetValue(ControlSizeProperty, value); }
        }

        public List<ICanvasItem> Items
        {
            set { _propertyService.SetValue(ItemsProperty, value); }
        }

        public CanvasControl() : this(
            new DependencyPropertyService(),
            new CanvasRenderer(),
            new VisualService())
        {
            // Default constructor necessary to declare control in XAML
            // TODO: Determine if there is a way to inject these dependencies with XAML
        }

        public CanvasControl(
            IDependencyPropertyService propertyService,
            ICanvasRenderer renderer,
            IVisualService visualService)
        {
            _propertyService = propertyService;
            _renderer = renderer;
            _visualService = visualService;

            // TODO: Should this be moved into an initialize method?
            _propertyService.SetSource(this);
            _visualService.SetSource(this);
        }

        private void Draw()
        {
            var visuals = new List<Visual>();

            var backgroundVisual = _renderer.DrawBackground(this.ActualWidth, this.ActualHeight);

            visuals.Add(backgroundVisual);

            var plots = (List<ICanvasItem>) _propertyService.GetValue(ItemsProperty);

            var plotVisuals = _renderer.DrawItems(plots);

            visuals.AddRange(plotVisuals);

            _visualService.Clear();
            
            _visualService.Add(visuals);
        }


        protected override int VisualChildrenCount
        {
            get { return _visualService.GetVisualsCount(); }
        }

        protected override Visual GetVisualChild(int index)
        {
            return _visualService.GetVisual(index);
        }

        private static void HandleItemsChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((CanvasControl) source).Draw();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            _isMouseDown = true;
            _previousMousePosition = Mouse.GetPosition(this);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            _isMouseDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            var location = e.GetPosition(this);

            if (_isMouseDown)
            {
                var delta = _previousMousePosition - location;
                OnPan(new CanvasPanEventArgs(delta));
            }

            _previousMousePosition = location;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            var center = Mouse.GetPosition(this);

            if (e.Delta > 0)
                OnZoomIn(new CanvasZoomInEventArg(center));
            else
                OnZoomOut(new CanvasZoomOutEventArgs(center));
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            var size = new Size(ActualWidth, ActualHeight);
            _propertyService.SetValue(ControlSizeProperty, size);
        }

        public void AddChild(Visual visual)
        {
            AddVisualChild(visual);
            AddLogicalChild(visual);
        }

        public void RemoveChild(Visual visual)
        {
            RemoveVisualChild(visual);
            RemoveLogicalChild(visual);
        }

        protected virtual void OnPan(CanvasPanEventArgs e)
        {
            if (Pan != null) 
                Pan(this, e);
        }

        protected virtual void OnZoomIn(CanvasZoomInEventArg e)
        {
            if (ZoomIn != null) 
                ZoomIn(this, e);
        }

        protected virtual void OnZoomOut(CanvasZoomOutEventArgs e)
        {
            if (ZoomOut != null) 
                ZoomOut(this, e);
        }
    }
}
