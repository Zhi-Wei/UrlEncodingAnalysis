using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;
using CsvHelper;
using Flurl;
using Microsoft.Security.Application;
using UrlEncodingAnalysis.CsvMaps;
using UrlEncodingAnalysis.Models;

namespace UrlEncodingAnalysis
{
    /// <summary>
    /// 主程式。
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// HttpUtility.UrlEncode 名稱。
        /// </summary>
        private static readonly string _httpUtilityUrlEncodeName =
            GetMethodFullName(HttpUtility.UrlEncode);

        /// <summary>
        /// HttpUtility.UrlEncodeUnicode 名稱。
        /// </summary>
        private static readonly string _httpUtilityUrlEncodeUnicodeName =
            GetMethodFullName(HttpUtility.UrlEncodeUnicode);

        /// <summary>
        /// HttpUtility.UrlPathEncode 名稱。
        /// </summary>
        private static readonly string _httpUtilityUrlPathEncodeName =
            GetMethodFullName(HttpUtility.UrlPathEncode);

        /// <summary>
        /// WebUtility.UrlEncode 名稱。
        /// </summary>
        private static readonly string _webUtilityUrlEncodeName =
            GetMethodFullName(WebUtility.UrlEncode);

        /// <summary>
        /// Uri.EscapeDataString 名稱。
        /// </summary>
        private static readonly string _uriEscapeDataStringName =
            GetMethodFullName(Uri.EscapeDataString);

        /// <summary>
        /// Uri.EscapeUriString 名稱。
        /// </summary>
        private static readonly string _uriEscapeUriStringName =
            GetMethodFullName(Uri.EscapeUriString);

        /// <summary>
        /// UrlEncoder.Encode 名稱。
        /// </summary>
        private static readonly string _urlEncoderEncodeName =
            GetMethodFullName(typeof(UrlEncoder).GetMethods().First(m => m.Name == nameof(UrlEncoder.Encode)));

        /// <summary>
        /// Url.Encode 名稱。
        /// </summary>
        private static readonly string _urlEncodeName =
            GetMethodFullName(typeof(Url).GetMethod(nameof(Url.Encode)));

        /// <summary>
        /// Url.EncodeIllegalCharacters 名稱。
        /// </summary>
        private static readonly string _urlEncodeIllegalCharactersName =
            GetMethodFullName(typeof(Url).GetMethod(nameof(Url.EncodeIllegalCharacters)));

        /// <summary>
        /// HttpUtility.HtmlAttributeEncode 名稱。
        /// </summary>
        private static readonly string _httpUtilityHtmlAttributeEncodeName =
            GetMethodFullName(HttpUtility.HtmlAttributeEncode);

        /// <summary>
        /// HttpUtility.HtmlEncode 名稱。
        /// </summary>
        private static readonly string _httpUtilityHtmlEncodeName =
            GetMethodFullName(HttpUtility.HtmlEncode);

        /// <summary>
        /// HttpUtility.JavaScriptStringEncode 名稱。
        /// </summary>
        private static readonly string _httpUtilityJavaScriptStringEncodeName =
            GetMethodFullName(HttpUtility.JavaScriptStringEncode);

        /// <summary>
        /// WebUtility.HtmlEncode 名稱。
        /// </summary>
        private static readonly string _webUtilityHtmlEncodeName =
            GetMethodFullName(WebUtility.HtmlEncode);

        /// <summary>
        /// HtmlEncoder.Encode 名稱。
        /// </summary>
        private static readonly string _htmlEncoderEncodeName =
            GetMethodFullName(typeof(HtmlEncoder).GetMethods().First(m => m.Name == nameof(HtmlEncoder.Encode)));

        /// <summary>
        /// JavaScriptEncoder.Encode 名稱。
        /// </summary>
        private static readonly string _javaScriptEncoderEncodeName =
            GetMethodFullName(typeof(JavaScriptEncoder).GetMethods().First(m => m.Name == nameof(JavaScriptEncoder.Encode)));

        /// <summary>
        /// Sanitizer.GetSafeHtmlFragment 名稱。
        /// </summary>
        private static readonly string _sanitizerGetSafeHtmlFragmentName =
            GetMethodFullName(Sanitizer.GetSafeHtmlFragment);

        /// <summary>
        /// 主方法。
        /// </summary>
        /// <param name="args">傳入參數集合。</param>
        private static void Main(string[] args)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("開始。");
            Console.ForegroundColor = originalColor;

            var testChars = Enumerable.Range(0, char.MaxValue + 1).Select(i => (char)i);
            var testFuncs = new Dictionary<string, Func<string, string>>
            {
                #region -- URL Encode --

                // using System.Web;
                { _httpUtilityUrlEncodeName, str => HttpUtility.UrlEncode(str) },
                { _httpUtilityUrlEncodeUnicodeName, str => HttpUtility.UrlEncodeUnicode(str) }, // Obsolete.
                { _httpUtilityUrlPathEncodeName, str => HttpUtility.UrlPathEncode(str) },

                // using System.Net;
                { _webUtilityUrlEncodeName, str => WebUtility.UrlEncode(str) },

                // using System;
                { _uriEscapeDataStringName, str => Uri.EscapeDataString(str) },
                { _uriEscapeUriStringName, str => Uri.EscapeUriString(str) },

                // PM> Install-Package System.Text.Encodings.Web
                // using System.Text.Encodings.Web;
                { _urlEncoderEncodeName, str => UrlEncoder.Default.Encode(str) },

                // PM> Install-Package Flurl
                // using Flurl;
                { _urlEncodeName, str => Url.Encode(str) },
                { _urlEncodeIllegalCharactersName, str => Url.EncodeIllegalCharacters(str) },

                #endregion -- URL Encode --

                #region -- Html & JavaScript Encode --

                // using System.Web;
                { _httpUtilityHtmlAttributeEncodeName, str => HttpUtility.HtmlAttributeEncode(str) },
                { _httpUtilityHtmlEncodeName, str => HttpUtility.HtmlEncode(str) },
                { _httpUtilityJavaScriptStringEncodeName, str => HttpUtility.JavaScriptStringEncode(str) },

                // using System.Net;
                { _webUtilityHtmlEncodeName, str => WebUtility.HtmlEncode(str) },

                // PM> Install-Package System.Text.Encodings.Web
                // using System.Text.Encodings.Web;
                { _htmlEncoderEncodeName, str => HtmlEncoder.Default.Encode(str) },
                { _javaScriptEncoderEncodeName, str => JavaScriptEncoder.Default.Encode(str) },

                // PM> Install-Package AntiXSS
                // using Microsoft.Security.Application;
                { _sanitizerGetSafeHtmlFragmentName, str => Sanitizer.GetSafeHtmlFragment(str) },

                #endregion -- Html & JavaScript Encode --
            };

            var testData = GetTestData(testChars, testFuncs);
            var testResults = GetTestResult(testData);

            var filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}Data\TestResults.csv";
            GenerateCsvFile(testResults, filePath);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("結束。");
            Console.ForegroundColor = originalColor;
        }

        /// <summary>
        /// 取得方法全名。
        /// </summary>
        /// <param name="func">方法委派。</param>
        /// <returns>方法全名。</returns>
        private static string GetMethodFullName(Func<string, string> func)
        {
            var name = $"{func.Method.ReflectedType.Name}.{func.Method.Name}";

            return name;
        }

        /// <summary>
        /// 取得方法全名。
        /// </summary>
        /// <param name="method">方法資訊。</param>
        /// <returns>方法全名。</returns>
        private static string GetMethodFullName(MethodInfo method)
        {
            var name = $"{method.ReflectedType.Name}.{method.Name}";

            return name;
        }

        /// <summary>
        /// 取得測試資料集合。
        /// </summary>
        /// <param name="testChars">測試字元集合。</param>
        /// <param name="testFuncs">測試方法集合。</param>
        /// <returns>測試資料集合。</returns>
        private static IEnumerable<Data> GetTestData(
            IEnumerable<char> testChars, IDictionary<string, Func<string, string>> testFuncs)
        {
            var testData = new List<Data>();

            foreach (var inputChar in testChars)
            {
                var inputString = inputChar.ToString();
                var inputHexadecimal = string.Format("0x{0:X4}", ((ushort)inputChar));

                foreach (var func in testFuncs)
                {
                    string output;

                    try
                    {
                        output = func.Value(inputString);
                    }
                    catch (Exception ex)
                    {
                        output = ex.GetType().Name;
                    }

                    testData.Add(new Data
                    {
                        Input = inputString,
                        Hexadecimal = inputHexadecimal,
                        MethodName = func.Key,
                        Output = output
                    });
                }
            }

            return testData;
        }

        /// <summary>
        /// 取得測試結果集合。
        /// </summary>
        /// <param name="testData">測試資料。</param>
        /// <returns>測試結果集合。</returns>
        private static IEnumerable<Result> GetTestResult(IEnumerable<Data> testData)
        {
            var testResult = testData.GroupBy(data => new { data.Input, data.Hexadecimal })
                .Select(group => new Result
                {
                    Input = group.Key.Input,
                    Hexadecimal = group.Key.Hexadecimal,
                    HttpUtilityUrlEncodeOutput = group.First(d => d.MethodName == _httpUtilityUrlEncodeName).Output,
                    HttpUtilityUrlEncodeUnicodeOutput = group.First(d => d.MethodName == _httpUtilityUrlEncodeUnicodeName).Output,
                    HttpUtilityUrlPathEncodeOutput = group.First(d => d.MethodName == _httpUtilityUrlPathEncodeName).Output,
                    WebUtilityUrlEncodeOutput = group.First(d => d.MethodName == _webUtilityUrlEncodeName).Output,
                    UriEscapeDataStringOutput = group.First(d => d.MethodName == _uriEscapeDataStringName).Output,
                    UriEscapeUriStringOutput = group.First(d => d.MethodName == _uriEscapeUriStringName).Output,
                    UrlEncoderEncodeOutput = group.First(d => d.MethodName == _urlEncoderEncodeName).Output,
                    UrlEncodeOutput = group.First(d => d.MethodName == _urlEncodeName).Output,
                    UrlEncodeIllegalCharactersOutput = group.First(d => d.MethodName == _urlEncodeIllegalCharactersName).Output,
                    HttpUtilityHtmlAttributeEncodeOutput = group.First(d => d.MethodName == _httpUtilityHtmlAttributeEncodeName).Output,
                    HttpUtilityHtmlEncodeOutput = group.First(d => d.MethodName == _httpUtilityHtmlEncodeName).Output,
                    HttpUtilityJavaScriptStringEncodeOutput = group.First(d => d.MethodName == _httpUtilityJavaScriptStringEncodeName).Output,
                    WebUtilityHtmlEncodeOutput = group.First(d => d.MethodName == _webUtilityHtmlEncodeName).Output,
                    HtmlEncoderEncodeOutput = group.First(d => d.MethodName == _htmlEncoderEncodeName).Output,
                    JavaScriptEncoderEncodeOutput = group.First(d => d.MethodName == _javaScriptEncoderEncodeName).Output,
                    SanitizerGetSafeHtmlFragmentOutput = group.First(d => d.MethodName == _sanitizerGetSafeHtmlFragmentName).Output,
                });

            return testResult;
        }

        /// <summary>
        /// 產生測試結果 CSV 檔案。
        /// </summary>
        /// <param name="testResults">測試結果集合。</param>
        /// <param name="filePath">檔案路徑。</param>
        private static void GenerateCsvFile(IEnumerable<Result> testResults, string filePath)
        {
            var file = new FileInfo(filePath);

            if (file.Exists == false)
            {
                file.Directory.Create();
            }

            using (var streamWriter = new StreamWriter(file.FullName, false, Encoding.Unicode))
            using (var csvWriter = new CsvWriter(streamWriter))
            {
                csvWriter.Configuration.RegisterClassMap<ResultMap>();
                csvWriter.WriteRecords(testResults);
            }
        }
    }
}