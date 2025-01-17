﻿namespace SoftServe.TAF.Framework.Core.Utils;

public static class UriExtensions
{
    public static Uri Append(this Uri uri, params string[] paths)
    {
        return new Uri(paths.Aggregate(uri.AbsoluteUri,
            (current, path) => $"{current.TrimEnd('/')}/{path.TrimStart('/')}"));
    }
}

