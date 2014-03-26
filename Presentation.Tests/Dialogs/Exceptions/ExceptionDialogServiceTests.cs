using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Dialogs.Exceptions;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Dialogs.Exceptions
{
    [TestFixture]
    public class ExceptionDialogServiceTests
    {
        private ExceptionDialogService _service;
        private Mock<IDialogFactory> _mockFactory;
        private Mock<IExceptionDialog> _mockExceptionDialog;


        [SetUp]
        public void SetUp()
        {
            _mockExceptionDialog = new Mock<IExceptionDialog>();

            _mockFactory = new Mock<IDialogFactory>();
            _mockFactory.Setup(p => p.CreateExceptionDialog())
                .Returns(_mockExceptionDialog.Object);

            _service = new ExceptionDialogService(
                _mockFactory.Object);
            
        }

        [Test]
        public void TestShowExceptionDialogShouldShowDialog()
        {
            var ex = new Exception();
            _service.Show(ex);
            _mockExceptionDialog.Verify(p => p.SetStartupLocation(WindowStartupLocation.CenterScreen));
            _mockExceptionDialog.Verify(p => p.SetIcon(SystemIcons.Error), Times.Once());
            _mockExceptionDialog.Verify(p => p.SetTitle("Data Explorer Error"), Times.Once());
            _mockExceptionDialog.Verify(p => p.SetException(ex), Times.Once());
            _mockExceptionDialog.Verify(p => p.ShowDialog(), Times.Once());
        }
    }
}
