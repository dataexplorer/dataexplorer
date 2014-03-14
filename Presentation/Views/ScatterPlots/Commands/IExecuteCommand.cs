using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public interface IExecuteCommand
    {
        void Execute(int id);
    }
}
