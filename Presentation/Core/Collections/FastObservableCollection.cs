using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DataExplorer.Presentation.Core.Collections
{
    public class FastObservableCollection<T> : ObservableCollection<T>
    {
        private bool _isChangeNotificationSuspended;

        public FastObservableCollection()
        {
            
        }

        public FastObservableCollection(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _isChangeNotificationSuspended = true;

            foreach (T item in items)
                Add(item);

            _isChangeNotificationSuspended = false;

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items));
        }
        
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_isChangeNotificationSuspended)          
               base.OnCollectionChanged(e);
        }
    }
}
