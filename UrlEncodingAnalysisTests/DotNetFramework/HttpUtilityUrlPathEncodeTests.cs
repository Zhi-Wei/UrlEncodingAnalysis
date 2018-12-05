using System;
using System.Linq;
using System.Web;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UrlEncodingAnalysisTests.DotNetFramework
{
    /// <summary>
    /// HttpUtility 類別 UrlPathEncode 方法的測試類別。
    /// </summary>
    [TestClass]
    public class HttpUtilityUrlPathEncodeTests
    {
        #region -- RFC 3986 保留字 --

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的冒號時_必須編碼為百分號3A()
        {
            // Arrange
            var input = ":";
            var expected = "%3A";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的正斜線時_必須編碼為百分號2F()
        {
            // Arrange
            var input = "/";
            var expected = "%2F";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的問號時_必須編碼為百分號3F()
        {
            // Arrange
            var input = "?";
            var expected = "%3F";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的井字號時_必須編碼為百分號23()
        {
            // Arrange
            var input = "#";
            var expected = "%23";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的左中括號時_必須編碼為百分號5B()
        {
            // Arrange
            var input = "[";
            var expected = "%5B";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的右中括號時_必須編碼為百分號5D()
        {
            // Arrange
            var input = "]";
            var expected = "%5D";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的At號時_必須編碼為百分號40()
        {
            // Arrange
            var input = "@";
            var expected = "%40";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的驚嘆號時_必須編碼為百分號21()
        {
            // Arrange
            var input = "!";
            var expected = "%21";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的金錢符號時_必須編碼為百分號24()
        {
            // Arrange
            var input = "$";
            var expected = "%24";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的和號時_必須編碼為百分號26()
        {
            // Arrange
            var input = "&";
            var expected = "%26";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的撇號時_必須編碼為百分號27()
        {
            // Arrange
            var input = "'";
            var expected = "%27";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的左小括號時_必須編碼為百分號28()
        {
            // Arrange
            var input = "(";
            var expected = "%28";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的右小括號時_必須編碼為百分號29()
        {
            // Arrange
            var input = ")";
            var expected = "%29";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的星號時_必須編碼為百分號2A()
        {
            // Arrange
            var input = "*";
            var expected = "%2A";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的加號時_必須編碼為百分號2B()
        {
            // Arrange
            var input = "+";
            var expected = "%2B";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的逗號時_必須編碼為百分號2C()
        {
            // Arrange
            var input = ",";
            var expected = "%2C";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的分號時_必須編碼為百分號3B()
        {
            // Arrange
            var input = ";";
            var expected = "%3B";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986保留字的等號時_必須編碼為百分號3D()
        {
            // Arrange
            var input = "=";
            var expected = "%3D";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        #endregion -- RFC 3986 保留字 --

        #region -- RFC 3986 未保留字 --

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986未保留字的大寫英文字母時_必須無編碼()
        {
            // Arrange
            var input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986未保留字的小寫英文字母時_必須無編碼()
        {
            // Arrange
            var input = "abcdefghijklmnopqrstuvwxyz";
            var expected = "abcdefghijklmnopqrstuvwxyz";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986未保留字的十進制數字時_必須無編碼()
        {
            // Arrange
            var input = "0123456789";
            var expected = "0123456789";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986未保留字的連字暨減號時_必須無編碼()
        {
            // Arrange
            var input = "-";
            var expected = "-";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986未保留字的句號時_必須無編碼()
        {
            // Arrange
            var input = ".";
            var expected = ".";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986未保留字的底線時_必須無編碼()
        {
            // Arrange
            var input = "_";
            var expected = "_";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986未保留字的波浪號時_必須無編碼()
        {
            // Arrange
            var input = "~";
            var expected = "~";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        #endregion -- RFC 3986 未保留字 --

        #region -- 其他 --

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為RFC3986的空格時_必須編碼為百分號20()
        {
            // Arrange
            var input = " ";
            var expected = "%20";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為長度65520的字串時_必須無拋出例外()
        {
            // Arrange
            var input = string.Join("", Enumerable.Repeat("A", 65520));

            // Act
            Action act = () => HttpUtility.UrlPathEncode(input);

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為任何的字元字串時_必須無拋出例外()
        {
            // Arrange
            var allChars = Enumerable.Range(0, char.MaxValue + 1).Select(i => (char)i).ToList();

            // Act
            Action act = () => allChars.ForEach(c => HttpUtility.UrlPathEncode(c.ToString()));

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為任何的字元字串時_必須共65536字元皆無拋出例外()
        {
            // Arrange
            double noExceptionChars = 0;
            int maxChars = char.MaxValue + 1;
            var allChars = Enumerable.Range(0, maxChars).Select(i => (char)i).ToList();

            // Act
            allChars.ForEach(c =>
            {
                try
                {
                    HttpUtility.UrlPathEncode(c.ToString());
                }
                catch (Exception)
                {
                    return;
                }

                noExceptionChars++;
            });

            // Assert
            double passRate = (noExceptionChars / maxChars) * 100;
            Console.WriteLine($"無拋出例外比例：{passRate.ToString()}%。");

            noExceptionChars.Should().Be(maxChars);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlPathEncode))]
        public void 當輸入為百分號編碼的字串時_必須無重複編碼()
        {
            // Arrange
            var input = "%20";
            var expected = "%20";

            // Act
            var actual = HttpUtility.UrlPathEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        #endregion -- 其他 --
    }
}