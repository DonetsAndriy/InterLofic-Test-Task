using SoftServe.TAF.Framework.Core.Utils;

namespace SoftServe.TAF.Framework.Core.Strings;

public static class StringGenerator
{
    public static string CreateRandomString(int length, params CharType[] types)
    {
        string sample = string.Empty;
        if (!types.Any()
         || types.Contains(CharType.Upper)) sample += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (types.Contains(CharType.Lower)) sample += "abcdefghijklmnopqrstuvwxyz";
        if (types.Contains(CharType.Digit)) sample += "1234567890";
        if (types.Contains(CharType.Special)) sample += "@#$%^&*)(}{:|><.,/?~";

        return new string(Enumerable.Repeat(sample, length)
                          .Select(s => s[Randomization.Random.Next(s.Length)]).ToArray());
    }
}

public enum CharType
{
    Upper,
    Lower,
    Digit,
    Special
}
