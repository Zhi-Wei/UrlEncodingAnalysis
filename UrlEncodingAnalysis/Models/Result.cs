namespace UrlEncodingAnalysis.Models
{
    /// <summary>
    /// 結果類別。
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 輸入。
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// 十六進制。
        /// </summary>
        public string Hexadecimal { get; set; }

        /// <summary>
        /// HttpUtility.UrlEncode 輸出。
        /// </summary>
        public string HttpUtilityUrlEncodeOutput { get; set; }

        /// <summary>
        /// HttpUtility.UrlEncodeUnicode 輸出。
        /// </summary>
        public string HttpUtilityUrlEncodeUnicodeOutput { get; set; }

        /// <summary>
        /// HttpUtility.UrlPathEncode 輸出。
        /// </summary>
        public string HttpUtilityUrlPathEncodeOutput { get; set; }

        /// <summary>
        /// WebUtility.UrlEncode 輸出。
        /// </summary>
        public string WebUtilityUrlEncodeOutput { get; set; }

        /// <summary>
        /// Uri.EscapeDataString 輸出。
        /// </summary>
        public string UriEscapeDataStringOutput { get; set; }

        /// <summary>
        /// Uri.EscapeUriString 輸出。
        /// </summary>
        public string UriEscapeUriStringOutput { get; set; }

        /// <summary>
        /// UrlEncoder.Encode 輸出。
        /// </summary>
        public string UrlEncoderEncodeOutput { get; set; }

        /// <summary>
        /// Url.Encode 輸出。
        /// </summary>
        public string UrlEncodeOutput { get; set; }

        /// <summary>
        /// Url.EncodeIllegalCharacters 輸出。
        /// </summary>
        public string UrlEncodeIllegalCharactersOutput { get; set; }

        /// <summary>
        /// HttpUtility.HtmlAttributeEncode 輸出。
        /// </summary>
        public string HttpUtilityHtmlAttributeEncodeOutput { get; set; }

        /// <summary>
        /// HttpUtility.HtmlEncode 輸出。
        /// </summary>
        public string HttpUtilityHtmlEncodeOutput { get; set; }

        /// <summary>
        /// HttpUtility.JavaScriptStringEncode 輸出。
        /// </summary>
        public string HttpUtilityJavaScriptStringEncodeOutput { get; set; }

        /// <summary>
        /// WebUtility.HtmlEncode 輸出。
        /// </summary>
        public string WebUtilityHtmlEncodeOutput { get; set; }

        /// <summary>
        /// HtmlEncoder.Encode 輸出。
        /// </summary>
        public string HtmlEncoderEncodeOutput { get; set; }

        /// <summary>
        /// JavaScriptEncoder.Encode 輸出。
        /// </summary>
        public string JavaScriptEncoderEncodeOutput { get; set; }

        /// <summary>
        /// Sanitizer.GetSafeHtmlFragment 輸出。
        /// </summary>
        public string SanitizerGetSafeHtmlFragmentOutput { get; set; }
    }
}