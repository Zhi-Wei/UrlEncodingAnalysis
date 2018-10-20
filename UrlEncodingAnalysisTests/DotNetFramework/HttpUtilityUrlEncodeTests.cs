using System.Web;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UrlEncodingAnalysisTests.DotNetFramework
{
    /// <summary>
    /// HttpUtility 類別 URL 編碼的測試類別。
    /// </summary>
    [TestClass]
    public class HttpUtilityUrlEncodeTests
    {
        #region -- RFC 3986 保留字 --

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的冒號時_必須編碼為百分號3A()
        {
            // Arrange
            var input = ":";
            var expected = "%3A";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的正斜線時_必須編碼為百分號2F()
        {
            // Arrange
            var input = "/";
            var expected = "%2F";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的問號時_必須編碼為百分號3F()
        {
            // Arrange
            var input = "?";
            var expected = "%3F";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的井字號時_必須編碼為百分號23()
        {
            // Arrange
            var input = "#";
            var expected = "%23";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的左中括號時_必須編碼為百分號5B()
        {
            // Arrange
            var input = "[";
            var expected = "%5B";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的右中括號時_必須編碼為百分號5D()
        {
            // Arrange
            var input = "]";
            var expected = "%5D";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的At號時_必須編碼為百分號40()
        {
            // Arrange
            var input = "@";
            var expected = "%40";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的驚嘆號時_必須編碼為百分號21()
        {
            // Arrange
            var input = "!";
            var expected = "%21";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的金錢符號時_必須編碼為百分號24()
        {
            // Arrange
            var input = "$";
            var expected = "%24";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的和號時_必須編碼為百分號26()
        {
            // Arrange
            var input = "&";
            var expected = "%26";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的撇號時_必須編碼為百分號27()
        {
            // Arrange
            var input = "'";
            var expected = "%27";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的左小括號時_必須編碼為百分號28()
        {
            // Arrange
            var input = "(";
            var expected = "%28";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的右小括號時_必須編碼為百分號29()
        {
            // Arrange
            var input = ")";
            var expected = "%29";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的星號時_必須編碼為百分號2A()
        {
            // Arrange
            var input = "*";
            var expected = "%2A";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的加號時_必須編碼為百分號2B()
        {
            // Arrange
            var input = "+";
            var expected = "%2B";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的逗號時_必須編碼為百分號2C()
        {
            // Arrange
            var input = ",";
            var expected = "%2C";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的分號時_必須編碼為百分號3B()
        {
            // Arrange
            var input = ";";
            var expected = "%3B";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory(nameof(HttpUtility))]
        [TestProperty(nameof(HttpUtility), nameof(HttpUtility.UrlEncode))]
        public void 當輸入為RFC3986保留字的等號時_必須編碼為百分號3D()
        {
            // Arrange
            var input = "=";
            var expected = "%3D";

            // Act
            var actual = HttpUtility.UrlEncode(input);

            // Assert
            actual.Should().Be(expected);
        }

        #endregion -- RFC 3986 保留字 --
    }
}