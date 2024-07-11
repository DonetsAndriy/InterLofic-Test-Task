namespace SoftServe.TAF.Framework.Core.Exceptions;

public class WebUITestException : TestAutomationException
{
    public WebUITestException(string message) : base(message) { }
    public WebUITestException(string message, Exception innerException) : base(message, innerException) { }
}
