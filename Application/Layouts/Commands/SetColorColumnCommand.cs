using System;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Commands
{
    public class SetColorColumnCommand : EntityIdCommand
    {
        public SetColorColumnCommand(int id) : base(id)
        {
            
        }
    }
}
