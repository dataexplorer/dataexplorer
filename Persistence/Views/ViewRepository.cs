using System;
using DataExplorer.Application;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence.Views
{
    public class ViewRepository : IViewRepository
    {
        private readonly IDataContext _viewContext;
        private readonly IViewFactory _factory;

        public ViewRepository(IDataContext viewContext, IViewFactory factory)
        {
            _viewContext = viewContext;
            _factory = factory;
        }

        public T Get<T>() where T : View
        {
            if (!_viewContext.Views.ContainsKey(typeof(T)))
            {
                var view = _factory.Create<T>();

                _viewContext.Views.Add(typeof(T), view);
            }

            return (T) _viewContext.Views[typeof(T)];
        }

        public void Set<T>(T view) where T : View
        {
            _viewContext.Views[typeof(T)] = view;
        }
    }
}
