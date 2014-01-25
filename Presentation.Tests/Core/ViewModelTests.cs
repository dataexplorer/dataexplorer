using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Views;
using DataExplorer.Presentation.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core
{
    public abstract class ViewModelTests
    {
        protected void AssertPropertyChanged<T>(BaseViewModel viewModel, Expression<Func<T>> property, Action action)
        {
            AssertPropertyChanged(viewModel, property, action, Times.Once());
        }

        protected void AssertPropertyChanged<T>(BaseViewModel viewModel, Expression<Func<T>> property, Action action, Times times)
        {
            var timesRaised = 0;

            var propertyName = ((MemberExpression) property.Body).Member.Name;

            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == propertyName)
                    timesRaised++;
            };

            action.Invoke();

            Assert.That(timesRaised, Is.EqualTo(1));
        }
    }
}
