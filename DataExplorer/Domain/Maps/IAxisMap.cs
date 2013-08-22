using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps
{
    public interface IAxisMap
    {
        double Map(object value);
    }
}
