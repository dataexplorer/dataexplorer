using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Layouts.Base.Commands;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetYAxisReverseCommand : BaseReverseLayoutCommand
    {
        public SetYAxisReverseCommand(bool isReverse) : base(isReverse)
        {
        }
    }
}
