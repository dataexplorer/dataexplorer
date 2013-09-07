using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Importers
{
    [Binding]
    public class CsvFileImporterSteps
    {
        private readonly Context _context;

        public CsvFileImporterSteps(Context context)
        {
            _context = context;
        }

        [Given(@"a CSV file")]
        public void GivenACSVFile()
        {
            _context.FakeCsvFile = new FakeCsvFile();
            _context.MockCsvFileParser.Setup(p => p.OpenFile(It.IsAny<string>()))
                .Callback(() => _context.FakeCsvFile.Open());
            _context.MockCsvFileParser.Setup(p => p.CloseFile())
                .Callback(() => _context.FakeCsvFile.Close());
            _context.MockCsvFileParser.Setup(p => p.ReadFields())
                .Returns(() => _context.FakeCsvFile.GetRow());
            _context.MockCsvFileParser.Setup(p => p.IsEndOfFile())
                .Returns(() => _context.FakeCsvFile.IsEndOfFile());
        }

        [Given(@"the CSV file contains a column")]
        public void GivenTheCSVFileContainsAColumn()
        {
            var headerRow = new string[] { "Column 1" };
            _context.FakeCsvFile.AddRow(headerRow);

        }

        [Given(@"the CSV file contains a row")]
        public void GivenTheCSVFileContainsARow()
        {
            var dataRow = new string[] { "Field 1" };
            _context.FakeCsvFile.AddRow(dataRow);
        }

        [When(@"I import the CSV file source")]
        public void WhenIImportTheCSVFileSource()
        {
            _context.CsvFileImportViewModel.FooterViewModel.ImportCommand.Execute(null);
        }

        [Then(@"the CSV file column is added to the repository")]
        public void ThenTheCSVFileColumnIsAddedToTheRepository()
        {
            _context.DataContext.Columns.Any(p => p.Name == "Column 1");
        }

        [Then(@"the CSV file row is added to the repository")]
        public void ThenTheCSVFileRowIsAddedToTheRepository()
        {
            _context.DataContext.Rows.Any(p => p[0].ToString() == "Field 1");
        }
    }
}
