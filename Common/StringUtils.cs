using System;

namespace CodingChallenge.Common
{
    public static class StringUtils
    {
        public static bool BeginsWithA(this string value)
        {
            return value.StartsWith("a", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
