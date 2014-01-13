using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Commands
{
    public class EntityCommand<T> : ICommand
    {
        private readonly T _entity;

        public EntityCommand(T entity)
        {
            _entity = entity;
        }

        public T Entity
        {
            get { return _entity; }
        }
    }
}
