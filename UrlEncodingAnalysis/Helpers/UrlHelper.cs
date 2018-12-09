using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using Flurl;

namespace UrlEncodingAnalysis.Helpers
{
    /// <summary>
    /// URL 輔助程式。
    /// </summary>
    public class UrlHelper
    {
        /// <summary>
        /// High Surrogate 字元集合。
        /// </summary>
        private static readonly char[] HighSurrogateChars = GenerateHighSurrogateChars();

        /// <summary>
        /// 產生 High Surrogate 字元集合。
        /// </summary>
        /// <returns>High Surrogate 字元集合。</returns>
        private static char[] GenerateHighSurrogateChars()
        {
            int highSurrogateStart = 0xD800;
            int highSurrogateEnd = 0xDBFF;
            int highSurrogateCount = highSurrogateEnd - highSurrogateStart + 1;
            var highSurrogateChars =
                Enumerable.Range(highSurrogateStart, highSurrogateCount).Select(i => (char)i).ToArray();

            return highSurrogateChars;
        }

        /// <summary>
        /// URL 編碼。
        /// </summary>
        /// <param name="url">欲編碼的 URL。</param>
        /// <returns>編碼後的 URL。</returns>
        public static string UrlEncode(string url)
        {
            if (url == null)
            {
                return url;
            }

            var builder = new StringBuilder();

            foreach (var item in url)
            {
                if (HighSurrogateChars.Contains(item))
                {
                    builder.Append(UrlEncoder.Default.Encode(item.ToString()));

                    continue;
                }

                builder.Append(Url.Encode(item.ToString()));
            }

            return builder.ToString();
        }

        /// <summary>
        /// URL 解碼。
        /// </summary>
        /// <param name="encodedUrl">編碼後的 URL。</param>
        /// <returns>解碼後的 URL。</returns>
        public static string UrlDecode(string encodedUrl)
        {
            return Url.Decode(encodedUrl, false);
        }
    }
}