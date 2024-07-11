using SoftServe.TAF.Framework.Core.Exceptions;

namespace SoftServe.TAF.Framework.WebAPI.RestSharp;

public class RequestExecutionStrategy
{
    public RestClient Client { get; set; }
    public RequestContentManagementStrategy Content { get; set; }

    public virtual async Task<RestResponse> ExecuteAsync(Method method, string resource, object body = null, Dictionary<string, string> headers = null, bool ignoreErrors = false)
    {
        var request = new RestRequest(resource, method);
        Content.AddJsonBody(request, body);
        Content.AddHeaders(request, headers);
        return await Client.ExecuteAsync(request);
    }

    public virtual async Task<TOut> CallAsync<TOut>(Method method, string resource, object body = null, Dictionary<string, string> headers = null)
    {
        var response = await ExecuteAsync(method, resource, body, headers, false);
        if (string.IsNullOrEmpty(response.Content)) throw new WebAPITestException("Response content is null or empty.");

        try
        {
            return JsonConvert.DeserializeObject<TOut>(response.Content);
        }
        catch (Exception ex)
        {
            throw new WebAPITestException($"Unable to parse Rest Response from resource: {resource}", ex);
        }
    }
}

