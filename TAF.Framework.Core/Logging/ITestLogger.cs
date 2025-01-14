﻿namespace SoftServe.TAF.Framework.Core.Logging;

public interface ITestLogger
{
    void Info(string line);
    void Debug(string line);
    void Warn(string line);
    void Error(string line);
}
