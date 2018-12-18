using CsvHelper.Configuration;
using UrlEncodingAnalysis.Models;

namespace UrlEncodingAnalysis.CsvMaps
{
    /// <summary>
    /// 結果類別 CSV 映射設定。
    /// </summary>
    /// <seealso cref="CsvHelper.Configuration.ClassMap{UrlEncodingAnalysis.Models.Result}" />
    public class ResultMap : ClassMap<Result>
    {
        /// <summary>
        /// 初始化 <see cref="ResultMap"/> 類別新的實體。
        /// </summary>
        public ResultMap()
        {
            Map(r => r.Input).Name("Input").Index(0);
            Map(r => r.Hexadecimal).Name("Hexadecimal").Index(1);
            Map(r => r.HttpUtilityUrlEncodeOutput).Name("HttpUtility.UrlEncode").Index(2);
            Map(r => r.HttpUtilityUrlEncodeUnicodeOutput).Name("HttpUtility.UrlEncodeUnicode").Index(3);
            Map(r => r.HttpUtilityUrlPathEncodeOutput).Name("HttpUtility.UrlPathEncode").Index(4);
            Map(r => r.WebUtilityUrlEncodeOutput).Name("WebUtility.UrlEncode").Index(5);
            Map(r => r.UriEscapeDataStringOutput).Name("Uri.EscapeDataString").Index(6);
            Map(r => r.UriEscapeUriStringOutput).Name("Uri.EscapeUriString").Index(7);
            Map(r => r.UrlEncoderEncodeOutput).Name("UrlEncoder.Encode").Index(8);
            Map(r => r.UrlEncodeOutput).Name("Url.Encode").Index(9);
            Map(r => r.UrlEncodeIllegalCharactersOutput).Name("Url.EncodeIllegalCharacters").Index(10);
            Map(r => r.HttpUtilityHtmlAttributeEncodeOutput).Name("HttpUtility.HtmlAttributeEncode").Index(11);
            Map(r => r.HttpUtilityHtmlEncodeOutput).Name("HttpUtility.HtmlEncode").Index(12);
            Map(r => r.HttpUtilityJavaScriptStringEncodeOutput).Name("HttpUtility.JavaScriptStringEncode").Index(13);
            Map(r => r.WebUtilityHtmlEncodeOutput).Name("WebUtility.HtmlEncode").Index(14);
            Map(r => r.HtmlEncoderEncodeOutput).Name("HtmlEncoder.Encode").Index(15);
            Map(r => r.JavaScriptEncoderEncodeOutput).Name("JavaScriptEncoder.Encode").Index(16);
            Map(r => r.SanitizerGetSafeHtmlFragmentOutput).Name("Sanitizer.GetSafeHtmlFragment").Index(17);
        }
    }
}