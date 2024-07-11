using System.Linq;

namespace SoftServe.TAF.Framework.WebAPI.RestSharp;

public class RequestContentManagementStrategy
{
    public virtual void AddJsonBody(RestRequest request, object body)
    {
        if (body is null) return;

        string bodyStr = body is string
            ? body.ToString()
            : JsonConvert.SerializeObject(body);

        request.AddBody(bodyStr, "application/json");
    }

    public virtual void AddHeaders(RestRequest request, Dictionary<string, string> headers)
    {
        if (headers != null && headers.Any())
            request.AddHeaders(headers);
    }
}

