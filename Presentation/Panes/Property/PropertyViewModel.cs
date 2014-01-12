using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataExplorer.Application;

namespace DataExplorer.Presentation.Panes.Property
{
    public class PropertyViewModel : IPropertyViewModel
    {
        private const string UriRegex = @"^http(s)|file|://";

        private readonly string _name;
        private readonly string _value;
        private readonly IProcess _process;

        public PropertyViewModel(
            string name, 
            string value, 
            IProcess process)
        {
            _name = name;
            _value = value;
            _process = process;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Value
        {
            get { return _value; }
        }

        public bool IsLink
        {
            get { return Regex.IsMatch(_value, UriRegex); }
        }

        public void HandleLinkClick()
        {
            _process.Start(_value);
        }
    }
}
