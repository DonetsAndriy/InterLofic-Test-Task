namespace SoftServe.TAF.Framework.Core.Strings;

public static class StringExtensions
{
    public static T ToEnum<T>(this string input) where T : struct =>
        Enum.Parse<T>(input, true);
}
