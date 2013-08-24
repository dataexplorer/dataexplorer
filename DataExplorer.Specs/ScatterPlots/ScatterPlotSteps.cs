using System;
using DataExplorer.Domain.ScatterPlots;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.ScatterPlots
{
    [Binding]
    public class ScatterPlotSteps
    {
        private readonly Context _context;

        public ScatterPlotSteps(Context context)
        {
            _context = context;
        }

        [Given(@"a scatterplot view")]
        public void GivenAScatterplotView()
        {
            var scatterPlot = new ScatterPlot();
            _context.ScatterPlot = scatterPlot;
            _context.DataContext.Views.Add(scatterPlot.GetType(), scatterPlot);
        }

        [Then(@"the view is added to the repository")]
        public void ThenTheViewIsAddedToTheRepository()
        {
            Assert.That(_context.DataContext.Sources.ContainsValue(_context.CsvFileSource), Is.True);
        }

        [Then(@"the scatterplot view is removed from the repository")]
        public void ThenTheScatterplotViewIsRemovedFromTheRepository()
        {
            Assert.That(_context.DataContext.Sources.ContainsValue(_context.CsvFileSource), Is.False);
        }

        [Given(@"the following data set:")]
        public void GivenTheFollowingDataSet(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the x-axis is mapped to the ""(.*)"" column")]
        public void GivenTheX_AxisIsMappedToTheColumn(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the y-axis is mapped to the ""(.*)"" column")]
        public void GivenTheY_AxisIsMappedToTheColumn(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I refresh the scatterplot")]
        public void WhenIRefreshTheScatterplot()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a single point should be displayed at \((.*)\)")]
        public void ThenASinglePointShouldBeDisplayedAt(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
