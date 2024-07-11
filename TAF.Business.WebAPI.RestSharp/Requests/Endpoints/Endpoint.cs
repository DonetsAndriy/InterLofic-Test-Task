using SoftServe.TAF.Framework.WebAPI.RestSharp;

namespace SoftServe.TAF.Business.WebAPI.RestSharp.Requests.Endpoints;

public abstract class Endpoint
{
    protected RequestExecutionStrategy Execution { get; set; }

    public abstract string GetRoute();

    public virtual void Init(RequestExecutionStrategy execution) =>
        Execution = execution;

    protected async Task<T> RequestAsync<T>(Method method, string resource, object body = null, Dictionary<string, string> headers = null)
    {
        var response = await Execution.ExecuteAsync(method, $"{GetRoute()}/{resource}", body, headers);
        return JsonConvert.DeserializeObject<T>(response.Content);
    }

    protected async Task<RestResponse> RequestAsync(Method method, string resource, object body = null, Dictionary<string, string> headers = null) =>
        await Execution.ExecuteAsync(method, $"{GetRoute()}/{resource}", body, headers);

    protected async Task<T> RequestAsync<T>(Method method, object body = null, Dictionary<string, string> headers = null)
    {
        var response = await Execution.ExecuteAsync(method, GetRoute(), body, headers);
        return JsonConvert.DeserializeObject<T>(response.Content);
    }

    protected async Task<RestResponse> RequestAsync(Method method, object body = null, Dictionary<string, string> headers = null) =>
        await Execution.ExecuteAsync(method, GetRoute(), body, headers);
}

