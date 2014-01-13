using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class PanCommand : ICommand
    {
        private readonly Vector _vector;

        public PanCommand(Vector vector)
        {
            _vector = vector;
        }

        public Vector Vector
        {
            get { return _vector; }
        }
    }
}
