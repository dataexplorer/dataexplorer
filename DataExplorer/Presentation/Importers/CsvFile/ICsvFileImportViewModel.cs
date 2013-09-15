using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Presentation.Core.Events;
using DataExplorer.Presentation.Importers.CsvFile.Footer;
using DataExplorer.Presentation.Importers.CsvFile.Header;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public interface ICsvFileImportViewModel
    {
        ICsvFileImportHeaderViewModel HeaderViewModel { get; }

        ICsvFileImportFooterViewModel FooterViewModel { get; }
    }
}
