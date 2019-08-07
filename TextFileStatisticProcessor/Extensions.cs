namespace TextFileStatisticProcessor
{
    internal static class Extensions
    {
        /// <summary>
        /// Checks whether in the string there are one or more supported substrings
        /// </summary>
        /// <param name="haystack">string</param>
        /// <param name="needles">field of substrings</param>
        /// <returns>True or false</returns>
        internal static bool ContainsAny(this string haystack, string[] needles)
        {
            foreach (string needle in needles)
            {
                if (haystack.Contains(needle))
                    return true;
            }
            return false;
        }
    }
}
