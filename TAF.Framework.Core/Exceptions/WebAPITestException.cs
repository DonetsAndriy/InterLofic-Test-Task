namespace SoftServe.TAF.Framework.Core.Exceptions;

public class WebAPITestException : TestAutomationException
{
    public WebAPITestException(string message) : base(message) { }
    public WebAPITestException(string message, Exception innerException) : base(message, innerException) { }
}
