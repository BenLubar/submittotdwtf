using System;
using System.Text.RegularExpressions;
using EnvDTE;
using EnvDTE80;

namespace SubmitToWTF
{
    internal static partial class Util
    {
        /// <summary>
        /// Removes leading tabs from a block of text.
        /// </summary>
        /// <param name="text">Text containing tabs to remove.</param>
        /// <param name="tabSize">Size of tabs in characters.</param>
        /// <returns>Block of text with tabs removed.</returns>
        public static string RemoveTabs(string text, int tabSize)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var tabReplacement = new string('\t', tabSize);

            text = Regex.Replace(text, @"^\s+", m => m.Value.Replace("\t", tabReplacement), RegexOptions.Multiline);

            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            int? minIndex = null;

            foreach (var line in lines)
            {
                if (!Util.IsEmptyOrWhitespace(line))
                {
                    int leadingSpaces = GetLeadingSpaces(line);
                    if (minIndex == null || (int)minIndex > leadingSpaces)
                        minIndex = leadingSpaces;
                }
            }

            if (minIndex != null && (int)minIndex > 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!Util.IsEmptyOrWhitespace(lines[i]))
                        lines[i] = lines[i].Substring((int)minIndex);
                    else
                        lines[i] = string.Empty;
                }
            }

            return string.Join(Environment.NewLine, lines);
        }
        /// <summary>
        /// Returns the size of a tab character in spaces.
        /// </summary>
        /// <param name="dte">Current DTE instance.</param>
        /// <param name="doc">Document being edited.</param>
        /// <returns>Number of spaces in a tab for the specified document.</returns>
        public static int GetTabSize(DTE2 dte, Document doc)
        {
            var languageName = string.Empty;
            if (doc.ProjectItem != null && doc.ProjectItem.ContainingProject != null && doc.ProjectItem.ContainingProject.CodeModel != null)
                languageName = GetLanguageName(doc.ProjectItem.ContainingProject.CodeModel.Language);

            int tabSize = 4;

            try
            {
                var properties = dte.get_Properties("TextEditor", languageName);
                tabSize = Convert.ToInt32(properties.Item("TabSize").Value);
            }
            catch
            {
            }

            return tabSize;
        }

        /// <summary>
        /// Returns the number of leading spaces at the start of a line.
        /// </summary>
        /// <param name="s">Line of text.</param>
        /// <returns>Number of leading spaces on the line.</returns>
        private static int GetLeadingSpaces(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s, i))
                    return i;
            }

            return s.Length;
        }
        /// <summary>
        /// Returns a language name suitable for reading language preferences.
        /// </summary>
        /// <param name="languageId">The language ID.</param>
        /// <returns>The language name.</returns>
        private static string GetLanguageName(string languageId)
        {
            switch (languageId)
            {
                case CodeModelLanguageConstants.vsCMLanguageCSharp:
                default:
                    return "CSharp";

                case CodeModelLanguageConstants.vsCMLanguageVB:
                    return "VB";

                case CodeModelLanguageConstants.vsCMLanguageVC:
                    return "VC";

                case CodeModelLanguageConstants.vsCMLanguageMC:
                    return "MC";

                case CodeModelLanguageConstants2.vsCMLanguageJSharp:
                    return "JSharp";
            }
        }
    }
}
