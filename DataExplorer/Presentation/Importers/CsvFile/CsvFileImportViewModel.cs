using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Core.Events;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public class CsvFileImportViewModel : BaseViewModel, ICsvFileImportViewModel
    {
        private readonly ICsvFileImportHeaderViewModel _header;
        private readonly ICsvFileImportFooterViewModel _footer;

        public CsvFileImportViewModel(
            ICsvFileImportHeaderViewModel header,
            ICsvFileImportFooterViewModel footer)
        {
            _header = header;
            _footer = footer;
        }

        public ICsvFileImportHeaderViewModel HeaderViewModel
        {
            get { return _header; }
        }

        public ICsvFileImportFooterViewModel FooterViewModel
        {
            get { return _footer; }
        }
    }
}
