using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Views
{
    public interface IViewRepository
    {
        T Get<T>() where T : IView, new();
        void Set<T>(T view) where T : IView;
    }
}
