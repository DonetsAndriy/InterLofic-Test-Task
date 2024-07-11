using System;
using Serilog;
using SoftServe.TAF.Framework.Core.Logging;

namespace SoftServe.TAF.Framework.Logging.Serilog
{
    public class SerilogConsoleLogger : ITestLogger
    {
        private readonly ILogger logger;

        public SerilogConsoleLogger()
        {
            logger  = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .CreateLogger();
        }

        public void Debug(string line) => logger.Debug(line);
        public void Error(string line) => logger.Error(line);
        public void Info(string line) => logger.Information(line);
        public void Warn(string line) => logger.Warning(line);
    }
}
