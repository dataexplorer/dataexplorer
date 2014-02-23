using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Size.Commands
{
    public class SetLowerSizeCommand : ICommand
    {
        private readonly double _value;

        public SetLowerSizeCommand(double value)
        {
            _value = value;
        }

        public double Value
        {
            get { return _value; }
        }
    }
}
