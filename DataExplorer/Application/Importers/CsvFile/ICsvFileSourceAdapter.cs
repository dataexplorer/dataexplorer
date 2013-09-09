using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFile
{
    public interface ICsvFileSourceAdapter
    {
        CsvFileSourceDto Adapt(CsvFileSource source);
    }
}
