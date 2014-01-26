using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Views
{
    public interface IViewFactory
    {
        View Create<T>();
    }
}
