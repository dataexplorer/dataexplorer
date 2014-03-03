using System;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetXAxisColumnCommand : EntityIdCommand
    {
        public SetXAxisColumnCommand(int id) : base(id)
        {
        }
    }
}
