using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Queries
{
    public class EntityIdQuery<T> : IQuery<T>
    {
        private readonly int _id;

        public EntityIdQuery(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
        }
    }
}
