using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Layouts.Base.Commands;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetXAxisReverseCommand : BaseReverseLayoutCommand
    {
        public SetXAxisReverseCommand(bool isReverse) : base(isReverse)
        {
        }
    }
}
