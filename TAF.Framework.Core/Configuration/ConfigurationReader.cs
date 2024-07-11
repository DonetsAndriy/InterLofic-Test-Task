using System.Collections.Concurrent;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SoftServe.TAF.Framework.Core.Configuration;

public static class ConfigurationReader
{
    private static readonly ConcurrentDictionary<string, IConfigurationRoot> configuration = new();

    public static IConfigurationRoot GetConfiguration(string fileName = "appsettings.json") =>
        configuration.GetOrAdd(fileName, (key) =>
                                new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
                                    .AddJsonFile(key, false)
                                    .Build()
                                    );
}
