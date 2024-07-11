using RestSharp.Authenticators;

namespace SoftServe.TAF.Framework.WebAPI.RestSharp;

public class RequestAuthentication
{
    public RestClient Client { get; set; }

    public virtual void SetBasicAuth(string username, string password) =>
        Client.Authenticator = new HttpBasicAuthenticator(username, password);

    public virtual void SetJwt(string token) =>
        Client.Authenticator = new JwtAuthenticator(token);

    public virtual void SetOAth1(string consumerKey, string consumerSecret, string accessToken, string tokenSecret) =>
        Client.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, accessToken, tokenSecret);
}
