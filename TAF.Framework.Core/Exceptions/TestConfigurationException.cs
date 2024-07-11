namespace SoftServe.TAF.Framework.Core.Exceptions;

public class TestConfigurationException : TestAutomationException
{
    public TestConfigurationException(string message) : base(message) { }
    public TestConfigurationException(string message, Exception innerException) : base(message, innerException) { }
}
