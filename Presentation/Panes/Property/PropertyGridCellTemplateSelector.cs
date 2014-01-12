using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataExplorer.Presentation.Panes.Property
{
    public class PropertyGridCellTemplateSelector : DataTemplateSelector
    {
        private DataTemplate _labelTemplate;
        private DataTemplate _linkTemplate;

        public DataTemplate LabelTemplate
        {
            set { _labelTemplate = value; }
        }
        
        public DataTemplate LinkTemplate
        {
            set { _linkTemplate = value; }
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (!(item is PropertyViewModel))
                return _labelTemplate;

            var propertyViewModel = (PropertyViewModel) item;

            return propertyViewModel.IsLink
                ? _linkTemplate
                : _labelTemplate;
        }
    }
}
