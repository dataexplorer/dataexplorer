using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter
{
    [TestFixture]
    public class FilterPaneViewModel
    {
        private FilterPaneViewModel _viewModel;

        [SetUp]
        public void SetUp()
        {
            _viewModel = new FilterPaneViewModel();
        }

    }
}
