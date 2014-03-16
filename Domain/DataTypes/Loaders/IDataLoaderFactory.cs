using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.DataTypes.Loaders
{
    public interface IDataLoaderFactory
    {
        IDataLoader Create(Type dataType, string basePath);
    }
}
