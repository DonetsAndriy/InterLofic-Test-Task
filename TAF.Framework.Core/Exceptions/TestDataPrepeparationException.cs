namespace SoftServe.TAF.Framework.Core.Exceptions;

public class TestDataException : TestAutomationException
{
    public TestDataException(string message) : base(message) { }
    public TestDataException(string message, Exception innerException) : base(message, innerException) { }
}
