namespace SoftServe.TAF.Framework.WebAPI.RestSharp;

public class RestManager
{
    public RestClient Client { get; protected set; }
    public RequestExecutionStrategy Execution { get; protected set; }
    public RequestAuthentication Auth { get; protected set; }
    public RequestContentManagementStrategy Content { get; protected set; }

    public virtual void Init(string hostUrl, string basePath)
    {
        Client = new RestClient(hostUrl + basePath);
        Auth = new RequestAuthentication()
        {
            Client = Client
        };
        Content = new RequestContentManagementStrategy();
        Execution = new RequestExecutionStrategy()
        {
            Client = Client,
            Content = Content
        };
    }
}
