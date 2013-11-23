using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Core
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
