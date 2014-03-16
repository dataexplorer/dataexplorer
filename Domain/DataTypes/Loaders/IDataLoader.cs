using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.DataTypes.Loaders
{
    public interface IDataLoader
    {
        object Load(string uri);
    }
}
