#region Using Directives

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

#endregion

namespace StockDataScraper.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        ///     Returns a replacement string if the source string is null, empty, or contains nothing but whtiespace characters
        /// </summary>
        /// <param name="source">The source string to check against</param>
        /// <param name="replacement">The replacement string should the check come back true</param>
        /// <returns>The replacement string if true, otherwise the source string</returns>
        public static string IfNullOrWhiteSpace(this string source, string replacement)
        {
            if (string.IsNullOrWhiteSpace(source))
                return replacement;

            return source;
        }

        /// <summary>
        ///     Returns a replacement string if the source string is equal to any of the specified strings
        /// </summary>
        /// <param name="source">The source string to check against</param>
        /// <param name="replacement">The replacement string should the check come back true</param>
        /// <param name="input">The values to compare the source string against</param>
        /// <returns>The replacement string if the source string equals any of the input strings, otherwise the source string</returns>
        public static string IfEquals(this string source, string[] input, string replacement)
        {
            if (input.Any(a => a.Equals(source)))
                return replacement;

            return source;
        }

        /// <summary>
        ///     Converts a string into a nullable integer
        /// </summary>
        /// <param name="source">The source string containing the number</param>
        /// <returns>An integer representing the source string</returns>
        public static int? ToNullableInt(this string source)
        {
            int? result;
            if (string.IsNullOrWhiteSpace(source))
            {
                result = null;
            }
            else
            {
                int j;
                if (int.TryParse(source, out j))
                    result = j;
                else
                    result = null;
            }

            return result;
        }

        /// <summary>
        ///     Converts a string decimalo a nullable decimaleger
        /// </summary>
        /// <param name="source">The source string containing the number</param>
        /// <returns>An decimaleger representing the source string</returns>
        public static decimal? ToNullableDecimal(this string source)
        {
            decimal? result;
            if (string.IsNullOrWhiteSpace(source))
            {
                result = null;
            }
            else
            {
                decimal j;
                if (decimal.TryParse(source, out j))
                    result = j;
                else
                    result = null;
            }

            return result;
        }

        public static string CleanResponseString(this string source)
        {
            if (source.IsNullOrWhiteSpace())
                return source;

            while (source.Contains("\t"))
                source = source.Replace("\t", "");

            while (Regex.IsMatch(source, @"\n\s*?\n"))
                source = Regex.Replace(source, @"\n\s*?\n", "\n");

            while (Regex.IsMatch(source, @"\r"))
                source = Regex.Replace(source, @"\r", "");

            while (Regex.IsMatch(source, @"\n"))
                source = Regex.Replace(source, @"\n", "");

            while (Regex.IsMatch(source, @"<head(.*?|[\s\r\n]*?)*?</head>"))
                source = Regex.Replace(source, @"<head(.*?|[\s\r\n]*?)*?</head>", "");

            while (Regex.IsMatch(source, @"<script(.*?|[\s\r\n]*?)*?</script>"))
                source = Regex.Replace(source, @"<script(.*?|[\s\r\n]*?)*?</script>", "");

            while (Regex.IsMatch(source, @"<style(.*?|[\s\r\n]*?)*?</style>"))
                source = Regex.Replace(source, @"<style(.*?|[\s\r\n]*?)*?</style>", "");

            while (Regex.IsMatch(source, @"<!--(.*?|[\s\r\n]*?)*?-->"))
                source = Regex.Replace(source, @"<!--(.*?|[\s\r\n]*?)*?-->", "");

            while (source.Contains("  "))
                source = source.Replace("  ", " ");

            source = source.Trim();

            return source;
        }

        public static IEnumerable<string> SplitCSV(this string source)
        {
            using (
                var parser = new TextFieldParser(new StringReader(source))
                {
                    HasFieldsEnclosedInQuotes = true,
                    TextFieldType = FieldType.Delimited,
                    Delimiters = new[] {","},
                    TrimWhiteSpace = true
                })
            {
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    if (fields == null || !fields.Any())
                        continue;

                    foreach (var field in fields)
                        yield return field;
                }

                parser.Close();
            }
        }
    }
}