using System;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.Views
{
    public interface IViewRepository
    {
        T Get<T>() where T : View;

        void Set<T>(T view) where T : View;
    }
}
