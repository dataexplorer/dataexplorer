using System;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.ScatterPlot
{
    [Binding]
    public class ScatterPlotSteps
    {
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
