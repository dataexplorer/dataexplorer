using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Commands
{
    public class EntityIdCommand : ICommand
    {
        private readonly int _id;

        public EntityIdCommand(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
        }
    }
}
