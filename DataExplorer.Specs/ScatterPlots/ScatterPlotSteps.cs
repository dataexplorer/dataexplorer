using System;
using DataExplorer.Domain.Views.ScatterPlots;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.ScatterPlots
{
    [Binding]
    public class ScatterPlotSteps
    {
        private readonly AppContext _appContext;

        public ScatterPlotSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"a scatterplot view")]
        public void GivenAScatterplotView()
        {
            var scatterPlot = new ScatterPlot();
            _appContext.ScatterPlot = scatterPlot;
            _appContext.DataContext.Views.Add(scatterPlot.GetType(), scatterPlot);
        }

        [Then(@"the view should be added to the repository")]
        public void ThenTheViewIsAddedToTheRepository()
        {
            Assert.That(_appContext.DataContext.Sources.ContainsValue(_appContext.CsvFileSource), Is.True);
        }

        [Then(@"the scatterplot view should be removed from the repository")]
        public void ThenTheScatterplotViewIsRemovedFromTheRepository()
        {
            Assert.That(_appContext.DataContext.Sources.ContainsValue(_appContext.CsvFileSource), Is.False);
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
