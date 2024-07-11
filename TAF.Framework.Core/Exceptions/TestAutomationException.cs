namespace SoftServe.TAF.Framework.Core.Exceptions;

public abstract class TestAutomationException : Exception
{
    public TestAutomationException(string message) : base(message) { }
    public TestAutomationException(string message, Exception innerException) : base(message, innerException) { }
}
