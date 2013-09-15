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
using DataExplorer.Presentation.Importers.CsvFile.Body;
using DataExplorer.Presentation.Importers.CsvFile.Footer;
using DataExplorer.Presentation.Importers.CsvFile.Header;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public class CsvFileImportViewModel : 
        BaseViewModel, 
        ICsvFileImportViewModel
    {
        private readonly ICsvFileImportHeaderViewModel _header;
        private readonly ICsvFileImportBodyViewModel _body;
        private readonly ICsvFileImportFooterViewModel _footer;

        public CsvFileImportViewModel(
            ICsvFileImportHeaderViewModel header,
            ICsvFileImportBodyViewModel body,
            ICsvFileImportFooterViewModel footer)
        {
            _header = header;
            _body = body;
            _footer = footer;
        }

        public ICsvFileImportHeaderViewModel HeaderViewModel
        {
            get { return _header; }
        }

        public ICsvFileImportBodyViewModel BodyViewModel
        {
            get { return _body; }
        }

        public ICsvFileImportFooterViewModel FooterViewModel
        {
            get { return _footer; }
        }
    }
}
