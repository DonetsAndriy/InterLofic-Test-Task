namespace SoftServe.TAF.Framework.Core.Utils;

public static class Randomization
{
    private static readonly Lazy<Random> instanceHolder = new(() => new Random(Guid.NewGuid().GetHashCode()));

    public static Random Random => instanceHolder.Value;
}

