using System;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Size.Commands
{
    public class SetSizeColumnCommand : EntityIdCommand
    {
        public SetSizeColumnCommand(int id) : base(id)
        {
        }
    }
}
