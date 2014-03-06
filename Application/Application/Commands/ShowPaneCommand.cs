using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Application.Commands
{
    public class ShowPaneCommand : ICommand
    {
        private readonly Pane _pane;

        public ShowPaneCommand(Pane pane)
        {
            _pane = pane;
        }

        public Pane Pane
        {
            get { return _pane; }
        }
    }
}
