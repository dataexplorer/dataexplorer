using System;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Commands
{
    public class SetYColumnCommand : EntityIdCommand
    {
        public SetYColumnCommand(int id) : base(id)
        {
        }
    }
}
