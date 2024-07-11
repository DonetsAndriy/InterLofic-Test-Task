using System;
using Serilog;
using SoftServe.TAF.Framework.Core.Logging;

namespace SoftServe.TAF.Framework.Logging.Serilog
{
    public class SerilogFileLogger : ITestLogger
    {
        private readonly ILogger logger;

        public SerilogFileLogger(string logFileName)
        {
            logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File(logFileName, rollingInterval: RollingInterval.Day)
               .CreateLogger();
        }

        public void Debug(string line) => logger.Debug(line);
        public void Error(string line) => logger.Error(line);
        public void Info(string line) => logger.Information(line);
        public void Warn(string line) => logger.Warning(line);
    }
}
