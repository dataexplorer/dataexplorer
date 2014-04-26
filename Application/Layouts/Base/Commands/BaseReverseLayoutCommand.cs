using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Base.Commands
{
    public class BaseReverseLayoutCommand : ICommand
    {
        private readonly bool _isReverse;

        public BaseReverseLayoutCommand(bool isReverse)
        {
            _isReverse = isReverse;
        }

        public bool IsReverse
        {
            get { return _isReverse; }
        }
    }
}
