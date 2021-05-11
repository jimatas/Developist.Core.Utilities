// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

namespace Developist.Core.Utilities.Tests
{
    internal static class Helpers
    {
        public static string UntilFirstPeriod(this string text, bool includePeriod = false)
        {
            var period = text.IndexOf('.');
            return period >= 0 ? text.Substring(0, period + (includePeriod ? 1 : 0)) : text;
        }
    }
}
