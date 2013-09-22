﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Core.Canvas
{
    public class CanvasControl : FrameworkElement
    {
        private readonly IDependencyPropertyService _propertyService;
        private readonly ICanvasRenderer _renderer;
        private readonly IVisualService _visualService;

        public static readonly DependencyProperty ControlSizeProperty = DependencyProperty.Register(
            "ControlSize",
            typeof(Size),
            typeof(CanvasControl),
            new PropertyMetadata());

        public static readonly DependencyProperty PlotsProperty = DependencyProperty.Register(
            "Plots",
            typeof(List<Circle>),
            typeof(CanvasControl),
            new PropertyMetadata(new List<Circle>(), HandlePlotsChanged));

        public Size ControlSize
        {
            get { return (Size) _propertyService.GetValue(ControlSizeProperty); }
            set { _propertyService.SetValue(ControlSizeProperty, value); }
        }

        public List<Circle> Plots
        {
            set { _propertyService.SetValue(PlotsProperty, value); }
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

        private void DrawPlots()
        {
            var plots = (List<Circle>) _propertyService.GetValue(PlotsProperty);

            var visuals = plots
                .Select(p => _renderer.DrawVisual(p));

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

        private static void HandlePlotsChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((CanvasControl) source).DrawPlots();
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
    }
}
