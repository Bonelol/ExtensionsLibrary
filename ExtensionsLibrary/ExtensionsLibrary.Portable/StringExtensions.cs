using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExtensionsLibrary
{
    public static class StringExtensions
    {
        #region Methods

        public static string AddAnchor(this string text)
        {
            string result = Regex.Replace(text,
                @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?", m =>
                    String.Format("<a href='{0}'>{0}</a>", m.Value));

            return result;
        }

        public static string Ellipsize(this string text, int characterCount)
        {
            return text.Ellipsize(characterCount, "&#160;&#8230;");
        }

        public static string Ellipsize(this string text, int characterCount, string ellipsis, bool wordBoundary = false)
        {
            if (String.IsNullOrWhiteSpace(text))
                return "";

            if (characterCount < 0 || text.Length <= characterCount)
                return text;

            // search beginning of word
            var backup = characterCount;
            while (characterCount > 0 && !text[characterCount - 1].IsSpace())
            {
                characterCount--;
            }

            // search previous word
            while (characterCount > 0 && text[characterCount - 1].IsSpace())
            {
                characterCount--;
            }

            // if it was the last word, recover it, unless boundary is requested
            if (characterCount == 0 && !wordBoundary)
            {
                characterCount = backup;
            }

            var trimmed = text.Substring(0, characterCount);
            return trimmed + ellipsis;
        }

        /// <summary>
        ///     To ensure that a path is end with '\'
        /// </summary>
        /// <returns>string</returns>
        public static string EnsurePathSuffix(this string str)
        {
            return str.EndsWith(@"\") || str.EndsWith(@"\\") || str.EndsWith(@"/") ? str : str + @"\";
        }

        public static string Excerpt(this string markup, int length)
        {
            return markup.RemoveTags().Ellipsize(length);
        }

        public static string RemoveTags(this string html)
        {
            if (String.IsNullOrEmpty(html))
            {
                return String.Empty;
            }

            var result = new char[html.Length];

            var cursor = 0;
            var inside = false;

            foreach (char current in html)
            {
                switch (current)
                {
                    case '<':
                        inside = true;
                        continue;
                    case '>':
                        inside = false;
                        continue;
                }

                if (!inside)
                {
                    result[cursor++] = current;
                }
            }

            var stringResult = new string(result, 0, cursor);

            return stringResult;
        }

        /// <summary>
        /// If value is 'True' or '1' return true, otherwise return false.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string text)
        {
            if (text == null) return false;
            if (text.Trim() == "1") return true;

            bool result;
            bool.TryParse(text, out result);

            return result;
        }

        public static double ToDouble(this string text)
        {
            double result;
            Double.TryParse(text, out result);

            return result;
        }

        public static int ToInt32(this string text)
        {
            int result;
            Int32.TryParse(text, out result);

            return result;
        }

        public static float ToFloat(this string text)
        {
            float result;
            float.TryParse(text, out result);

            return result;
        }

        /// <summary>
        /// Attempt to parse a string to DateTime, default to local date time.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="asLocalDateTime"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string text, bool asLocalDateTime = true)
        {
            DateTime dateTime;
            DateTime.TryParse(text, null, asLocalDateTime ? DateTimeStyles.None : DateTimeStyles.AssumeLocal, out dateTime);

            return dateTime;
        }
        #endregion
    }
}