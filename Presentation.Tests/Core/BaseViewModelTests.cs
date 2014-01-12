using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core
{
    [TestFixture]
    public class BaseViewModelTests
    {
        private BaseViewModelHarness _viewModel;

        [SetUp]
        public void SetUp()
        {
            _viewModel = new BaseViewModelHarness();
        }

        [Test]
        public void TestOnPropertyChangedByPropertyNameShouldRaisePropertyChangedEvent()
        {
            object sender = null;
            PropertyChangedEventArgs args = null;
            _viewModel.PropertyChanged += (s, e) => { sender = s; args = e; };
            _viewModel.OnPropertyChanged("TestProperty");
            Assert.That(sender, Is.EqualTo(_viewModel));
            Assert.That(args.PropertyName, Is.EqualTo("TestProperty"));
        }

        [Test]
        public void TestOnPropertyChangedByExpressionShouldRaisePropertyChangedEvent()
        {
            object sender = null;
            PropertyChangedEventArgs args = null;
            _viewModel.PropertyChanged += (s, e) => { sender = s; args = e; };
            _viewModel.OnPropertyChanged(() => _viewModel.TestProperty);
            Assert.That(sender, Is.EqualTo(_viewModel));
            Assert.That(args.PropertyName, Is.EqualTo("TestProperty"));
        }

        public class BaseViewModelHarness : BaseViewModel
        {
            public new void OnPropertyChanged(string propertyName)
            {
                base.OnPropertyChanged(propertyName);
            }

            public new void OnPropertyChanged<T>(Expression<Func<T>> property)
            {
                base.OnPropertyChanged(property);
            }

            public object TestProperty
            {
                get { return null; }
            }
        }
    }
}
