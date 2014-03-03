using System;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetYAxisColumnCommand : EntityIdCommand
    {
        public SetYAxisColumnCommand(int id) : base(id)
        {
        }
    }
}
