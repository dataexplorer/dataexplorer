using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Domain.Tests.Sources.Maps;
using Moq;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Importers
{
    [Binding]
    public class CsvFileImporterSteps
    {
        private readonly AppContext _appContext;

        public CsvFileImporterSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"a CSV file")]
        public void GivenACSVFile()
        {
            _appContext.FakeCsvFile = new FakeCsvFile();
            _appContext.MockCsvFileParser.Setup(p => p.OpenFile(It.IsAny<string>()))
                .Callback(() => _appContext.FakeCsvFile.Open());
            _appContext.MockCsvFileParser.Setup(p => p.CloseFile())
                .Callback(() => _appContext.FakeCsvFile.Close());
            _appContext.MockCsvFileParser.Setup(p => p.ReadFields())
                .Returns(() => _appContext.FakeCsvFile.GetRow());
            _appContext.MockCsvFileParser.Setup(p => p.IsEndOfFile())
                .Returns(() => _appContext.FakeCsvFile.IsEndOfFile());
        }

        [Given(@"the CSV file contains a column")]
        public void GivenTheCSVFileContainsAColumn()
        {
            var headerRow = new string[] { "Column 1" };
            _appContext.FakeCsvFile.AddRow(headerRow);

        }

        [Given(@"the CSV file contains a row")]
        public void GivenTheCSVFileContainsARow()
        {
            var dataRow = new string[] { "Field 1" };
            _appContext.FakeCsvFile.AddRow(dataRow);
        }

        [Given(@"a map exists for the the CSV file source")]
        public void GivenAMapExistsForTheTheCSVFileSource()
        {
            var map = new SourceMapBuilder()
                .WithIndex(0)
                .WithDataType(typeof (string))
                .Build();
            _appContext.CsvFileSource.SetMaps(new List<SourceMap> { map });
        }


        [When(@"I import the CSV file source")]
        public void WhenIImportTheCSVFileSource()
        {
            _appContext.CsvFileImportViewModel.FooterViewModel.ImportCommand.Execute(null);
        }

        [Then(@"the CSV file column should be added to the repository")]
        public void ThenTheCSVFileColumnShouldBeAddedToTheRepository()
        {
            _appContext.DataContext.Columns.Any(p => p.Name == "Column 1");
        }

        [Then(@"the CSV file row should be added to the repository")]
        public void ThenTheCSVFileRowShouldBeAddedToTheRepository()
        {
            _appContext.DataContext.Rows.Any(p => p[0].ToString() == "Field 1");
        }
    }
}
