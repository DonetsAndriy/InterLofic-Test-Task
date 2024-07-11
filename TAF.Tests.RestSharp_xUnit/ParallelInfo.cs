using Xunit;

[assembly: CollectionBehavior(
    CollectionBehavior.CollectionPerClass, // Parallelize by different scopes
    DisableTestParallelization = false, // Run whole assembly in a single thread
    MaxParallelThreads = 4 // Default number of parallel test runners
)]
namespace SoftServe.TAF.Tests.Playwright_xUnit
{
    internal class ParallelInfo
    {
    }
}
