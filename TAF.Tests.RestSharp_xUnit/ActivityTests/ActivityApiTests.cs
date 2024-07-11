using SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Endpoints;
using SoftServe.TAF.Framework.Core.Configuration;
using SoftServe.TAF.Framework.WebAPI.RestSharp;

namespace TAF.Tests.RestSharp_xUnit.ActivityTests
{
    public class ActivityApiTests
    {
        private readonly RestManager _restManager;
        private readonly ActivityEndpoint _activityEndpoint;
        private readonly dynamic _config;

        public ActivityApiTests()
        {
            _config = ConfigurationReader.GetConfiguration("appsettings.json");
            _restManager = new RestManager();
            _restManager.Init(_config["Environments:TARegressionEnvUrl"], "/");

            _activityEndpoint = new ActivityEndpoint();
            _activityEndpoint.Init(_restManager.Execution);
        }

        [Fact]
        public async Task GetActivities_ShouldReturn30ActivitiesAndNoneDueYesterday()
        {
            var activities = await _activityEndpoint.GetAllActivities();
            Assert.Equal(30, activities.Count);
            Assert.DoesNotContain(activities, a => a.DueDate.Date == DateTime.Today.AddDays(-1));
        }
    }
}
