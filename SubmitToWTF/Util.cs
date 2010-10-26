using System.Text.RegularExpressions;
using System;

namespace SubmitToWTF
{
    /// <summary>
    /// Utility methods.
    /// </summary>
    internal static partial class Util
    {
        /// <summary>
        /// Returns a value indicating whether a string is null, empty, or whitespace.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns>True if the string is null, empty, or whitespace; otherwise false.</returns>
        public static bool IsEmptyOrWhitespace(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            return !Regex.IsMatch(s, @"\S+", RegexOptions.Singleline);
        }
    }
}
