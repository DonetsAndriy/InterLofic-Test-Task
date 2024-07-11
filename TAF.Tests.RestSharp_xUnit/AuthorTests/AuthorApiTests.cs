using SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Endpoints;
using SoftServe.TAF.Framework.Core.Configuration;
using SoftServe.TAF.Framework.WebAPI.RestSharp;


namespace TAF.Tests.RestSharp_xUnit.AuthorTests
{
    public class AuthorApiTests
    {
        private readonly RestManager _restManager;
        private readonly AuthorEndpoint _authorEndpoint;
        private readonly dynamic _config;

        public AuthorApiTests()
        {
            _config = ConfigurationReader.GetConfiguration("appsettings.json");
            _restManager = new RestManager();
            _restManager.Init(_config["Environments:TARegressionEnvUrl"], "/");

            _authorEndpoint = new AuthorEndpoint();
            _authorEndpoint.Init(_restManager.Execution);
        }

        [Theory]
        [InlineData(0, "J.K.", "Rowling")]
        public async Task PostAuthor_ShouldReturnSameAsRequestBody(int id, string firstName, string lastName)
        {
            var newAuthor = await _authorEndpoint.PostAuthor(id, firstName, lastName);
            Assert.Equal(firstName, newAuthor.FirstName);
            Assert.Equal(lastName, newAuthor.LastName);
        }

        [Theory]
        [InlineData(0, "Hermione", "Granger")]
        public async Task DeleteAuthor_ShouldBeSuccessful(int id, string firstName, string lastName)
        {
            var newAuthor = await _authorEndpoint.PostAuthor(id, firstName, lastName);
            var response = await _authorEndpoint.DeleteAuthor(newAuthor.Id);
            Assert.True(response.IsSuccessful, "Request was not successful");
        }
    }
}
