using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Presentation.Core.Events;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public interface ICsvFileImportViewModel
    {
        ICsvFileImportHeaderViewModel HeaderViewModel { get; }

        ICsvFileImportFooterViewModel FooterViewModel { get; }
    }
}
