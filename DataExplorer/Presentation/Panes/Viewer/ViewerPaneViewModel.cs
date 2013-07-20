using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Panes.Viewer
{
    public class ViewerPaneViewModel : IViewerPaneViewModel
    {
        public ViewerPaneViewModel()
        {
            var test = 1;
        }

        public string Message
        {
            get { return "Hello World!"; }
        }
    }
}
