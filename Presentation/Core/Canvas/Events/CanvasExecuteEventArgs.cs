using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Core.Canvas.Events
{
    public class CanvasExecuteEventArgs : EventArgs
    {
        private readonly int _id;

        public CanvasExecuteEventArgs(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
        }
    }
}
