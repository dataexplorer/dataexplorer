using System.Windows;

namespace DataExplorer.Presentation.Core.Services
{
    public class DependencyPropertyService : IDependencyPropertyService
    {
        private DependencyObject _source;

        // TODO: This method is for testing only, try to eliminate it
        public DependencyObject GetSource()
        {
            return _source;
        }

        public void SetSource(DependencyObject source)
        {
            _source = source;
        }

        public object GetValue(DependencyProperty property)
        {
            return _source.GetValue(property);
        }

        public void SetValue(DependencyProperty property, object value)
        {
            _source.SetValue(property, value);
        }
    }
}
