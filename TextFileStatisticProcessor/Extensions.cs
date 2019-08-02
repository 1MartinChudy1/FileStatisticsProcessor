namespace TextFileStatisticProcessor
{
    internal static class Extensions
    {
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
