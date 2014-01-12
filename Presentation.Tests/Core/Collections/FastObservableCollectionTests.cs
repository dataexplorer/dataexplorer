using System.Collections.Generic;
using DataExplorer.Presentation.Core.Collections;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Collections
{
    [TestFixture]
    public class FastObservableCollectionTests
    {
        private FastObservableCollection<object> _collection;
        private List<object> _items;
        private object _item1;
        private object _item2;
    
        [SetUp]
        public void SetUp()
        {
            _item1 = new object();
            _item2 = new object();
            _items = new List<object> { _item1, _item2 };

            _collection = new FastObservableCollection<object>();
        }

        [Test]
        public void TestConstructorShouldAddItems()
        {
            _collection = new FastObservableCollection<object>(_items);
            Assert.That(_collection.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestAddTwiceShouldRaiseCollectionChangedEventTwice()
        {
            var timesRaised = 0;
            _collection.CollectionChanged += (s, e) => timesRaised++;
            _collection.Add(_item1);
            _collection.Add(_item2);
            Assert.That(timesRaised, Is.EqualTo(2));
        }

        [Test]
        public void TestAddRangeShouldRaiseCollectionChangedEventOnce()
        {
            var timesRaised = 0;
            _collection.CollectionChanged += (s, e) => timesRaised++;
            _collection.AddRange(_items);
            Assert.That(timesRaised, Is.EqualTo(1));
        }
    }
}
