using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataExplorer.Presentation.Core.Controls
{
    /// <summary>
    /// Interaction logic for RangeSlider.xaml
    /// </summary>
    public partial class RangeSlider : UserControl
    {
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(
            "Minimum",
            typeof(double),
            typeof(RangeSlider),
            new UIPropertyMetadata(0.0d));

        public static readonly DependencyProperty LowerValueProperty = DependencyProperty.Register(
            "LowerValue",
            typeof(double),
            typeof(RangeSlider),
            new UIPropertyMetadata(0.0d));

        public static readonly DependencyProperty UpperValueProperty = DependencyProperty.Register(
            "UpperValue",
            typeof(double),
            typeof(RangeSlider),
            new UIPropertyMetadata(1.0d));

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
            "Maximum",
            typeof(double),
            typeof(RangeSlider),
            new UIPropertyMetadata(1.0d));

        public static readonly DependencyProperty IsLowerSliderVisibleProperty = DependencyProperty.Register(
            "IsLowerSliderVisible",
            typeof(bool),
            typeof(RangeSlider),
            new UIPropertyMetadata(true, IsLowerSliderVisiblePropertyChanged));

        public static readonly DependencyProperty IsUpperSliderVisibleProperty = DependencyProperty.Register(
            "IsUpperSliderVisible",
            typeof(bool),
            typeof(RangeSlider),
            new UIPropertyMetadata(true, IsUpperSliderVisiblePropertyChanged));

        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
            "IsLoading",
            typeof(bool),
            typeof(RangeSlider),
            new UIPropertyMetadata(false));

        public double Minimum
        {
            get { return (double) GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public double LowerValue
        {
            get { return (double) GetValue(LowerValueProperty); }
            set { SetValue(LowerValueProperty, value); }
        }

        public double UpperValue
        {
            get { return (double) GetValue(UpperValueProperty); }
            set { SetValue(UpperValueProperty, value); }
        }

        public double Maximum
        {
            get { return (double) GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public bool IsLowerSliderVisible
        {
            get { return (bool) GetValue(IsLowerSliderVisibleProperty); }
            set { SetValue(IsLowerSliderVisibleProperty, value); }
        }

        public bool IsUpperSliderVisible
        {
            get { return (bool) GetValue(IsUpperSliderVisibleProperty); }
            set { SetValue(IsUpperSliderVisibleProperty, value); }
        }

        public bool IsLoading
        {
            get { return (bool) GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }
        
        public RangeSlider()
        {
            InitializeComponent();

            LowerSlider.ValueChanged += HandleLowerSliderValueChanged;
            UpperSlider.ValueChanged += HandleUpperSliderValueChanged;
        }

        private void HandleLowerSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var lowerValue = (double) GetValue(LowerValueProperty);

            var upperValue = (double) GetValue(UpperValueProperty);

            var newUpperValue = Math.Max(upperValue, lowerValue);

            if (newUpperValue == upperValue)
                return;

            SetValue(UpperValueProperty, newUpperValue);
        }

        private void HandleUpperSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var upperValue = (double) GetValue(UpperValueProperty);

            var lowerValue = (double) GetValue(LowerValueProperty);

            var newLowerValue = Math.Min(lowerValue, upperValue);

            if (newLowerValue == lowerValue)
                return;

            SetValue(LowerValueProperty, newLowerValue);
        }
        
        private static void IsLowerSliderVisiblePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var rangeSlider = (RangeSlider)sender;
            rangeSlider.LowerSlider.Visibility = (bool)(e.NewValue)
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private static void IsUpperSliderVisiblePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var rangeSlider = (RangeSlider)sender;
            rangeSlider.UpperSlider.Visibility = (bool)(e.NewValue)
                ? Visibility.Visible
                : Visibility.Hidden;
        }
    }
}
