using Newtonsoft.Json;
using Serilog;
using SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Endpoints;
using SoftServe.TAF.Framework.Core.Configuration;
using SoftServe.TAF.Framework.WebAPI.RestSharp;


namespace TAF.Tests.RestSharp_xUnit.BookTests
{
    public class BookApiTests
    {
        private readonly RestManager _restManager;
        private readonly BookEndpoint _bookEndpoint;
        private readonly dynamic _config;

        public BookApiTests()
        {
            _config = ConfigurationReader.GetConfiguration("appsettings.json");
            _restManager = new RestManager();
            _restManager.Init(_config["Environments:TARegressionEnvUrl"], "/");

            _bookEndpoint = new BookEndpoint();
            _bookEndpoint.Init(_restManager.Execution);
        }

        [Theory]
        [InlineData(1, "Harry Potter and the Philosopher's Stone", "First book of Harry Potter series", 223, "An excerpt from the book", "1997-06-26")]
        [InlineData(2, "Harry Potter and the Chamber of Secrets", "Second book of Harry Potter series", 251, "An excerpt from the book", "1998-07-02")]
        public async Task PutBook_ShouldReturnSameAsRequestBody(int id, string title, string description, int pageCount, string excerpt, DateTime publishDate)
        {
            var updatedBook = await _bookEndpoint.PutBook(id, title, description, pageCount, excerpt, publishDate);
            Assert.NotNull(updatedBook);
            if (updatedBook == null)
            {
                Log.Logger.Error("Update book failed, returned null.");
            }
            else
            {
                Log.Logger.Information($"Updated book: {JsonConvert.SerializeObject(updatedBook)}");
            }
            Assert.Equal(title, updatedBook.Title);
            Assert.Equal(description, updatedBook.Description);
            Assert.Equal(pageCount, updatedBook.PageCount);
            Assert.Equal(excerpt, updatedBook.Excerpt);
        }

        [Fact]
        public async Task GetBooks_ShouldReturnCorrectDetails()
        {
            for (int i = 1; i <= 10; i++)
            {
                var book = await _bookEndpoint.GetBook(i);
                Assert.NotNull(book);
                Assert.Equal(i, book.Id);
                Assert.Equal(i * 100, book.PageCount);

                if (book == null)
                {
                    Log.Logger.Error("Request failed", new { Url = $"api/v1/Books/{i}", Response = book });
                }
            }
        }
    }
}
