using System;
using Molibar.Common.Web;
using Molibar.Infrastructure.Logging;
using Molibar.Infrastructure.Logging.ForTesting;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Helpers
{
    [TestFixture]
    public class UriHelperTest
    {
        private MemoryLoggerForTest _memoryLoggerForTest;

        [SetUp]
        public void SetUp()
        {
            _memoryLoggerForTest = new MemoryLoggerForTest();
            new Log(_memoryLoggerForTest);
        }

        [Test]
        public void ShouldBeAbleToCombineTwoHalvesOfAUrl_FirstPartEndingWithSlash_SecondPartBeginningWithSlash()
        {
            // Arrange
            var expected = "http://www.contoso.com/Active/Playing/Banana-Bandana-Ninja.aspx";
            var firstPart = "http://www.contoso.com/Active/";
            var lastPart = "/Playing/Banana-Bandana-Ninja.aspx";

            // Act
            var uri = UriHelper.Combine(firstPart, lastPart);

            // Assert
            Assert.That(uri.AbsoluteUri, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldBeAbleToCombineTwoHalvesOfAUrl_FirstPartNotEndingWithSlash_SecondPartBeginningWithSlash()
        {
            // Arrange
            var expected = "http://www.contoso.com/Active/Playing/Banana-Bandana-Ninja.aspx";
            var firstPart = "http://www.contoso.com/Active";
            var lastPart = "/Playing/Banana-Bandana-Ninja.aspx";

            // Act
            var uri = UriHelper.Combine(firstPart, lastPart);

            // Assert
            Assert.That(uri.AbsoluteUri, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldBeAbleToCombineTwoHalvesOfAUrl_FirstPartEndingWithSlash_SecondPartNotBeginningWithSlash()
        {
            // Arrange
            var expected = "http://www.contoso.com/Active/Playing/Banana-Bandana-Ninja.aspx";
            var firstPart = "http://www.contoso.com/Active/";
            var lastPart = "Playing/Banana-Bandana-Ninja.aspx";

            // Act
            var uri = UriHelper.Combine(firstPart, lastPart);

            // Assert
            Assert.That(uri.AbsoluteUri, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldBeAbleToCombineTwoHalvesOfAUrl_FirstPartNotEndingWithSlash_SecondPartNotBeginningWithSlash()
        {
            // Arrange
            var expected = "http://www.contoso.com/Active/Playing/Banana-Bandana-Ninja.aspx";
            var firstPart = "http://www.contoso.com/Active";
            var lastPart = "Playing/Banana-Bandana-Ninja.aspx";

            // Act
            var uri = UriHelper.Combine(firstPart, lastPart);

            // Assert
            Assert.That(uri.AbsoluteUri, Is.EqualTo(expected));
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ShouldThrowExceptionIf_firstPart_null()
        {
            // Arrange
            var expected = "http://www.contoso.com/Active/Playing/Banana-Bandana-Ninja.aspx";
            string firstPart = null;
            var lastPart = "Playing/Banana-Bandana-Ninja.aspx";

            // Act
            var uri = UriHelper.Combine(firstPart, lastPart);

            // Assert
            Assert.That(uri.AbsoluteUri, Is.EqualTo(expected));
        }


        [Test]
        [ExpectedException(typeof (ArgumentException),
            ExpectedMessage = "Null Uri object supplied. Please enter a valid Url", MatchType = MessageMatch.Exact)]
        public void GetDomainNullParameter()
        {
            UriHelper.GetDomain(null);
        }

        [Test]
        public void GetDomainNormalUrlWithCom()
        {
            Uri input = new Uri("http://www.leadmarket.com");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("www."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.com", result);
        }

        [Test]
        public void GetDomainNormalUrlWithCoUk()
        {
            Uri input = new Uri("http://www.leadmarket.co.uk");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".co.uk"));
            Assert.IsFalse(result.Contains("www."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.co.uk", result);
        }

        [Test]
        public void GetDomainNormalUrlWithComWithSubdomain()
        {
            Uri input = new Uri("http://admin.leadmarket.com");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("www."));
            Assert.IsFalse(result.Contains("admin."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.com", result);
        }

        [Test]
        public void GetDomainNormalUrlWithCoUkWithSubdomain()
        {
            Uri input = new Uri("http://admin.leadmarket.co.uk");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".co.uk"));
            Assert.IsFalse(result.Contains("www."));
            Assert.IsFalse(result.Contains("admin."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.co.uk", result);
        }

        [Test]
        public void GetDomainNormalUrlWithCoUkWithHttps()
        {
            Uri input = new Uri("https://www.leadmarket.com");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("www."));
            Assert.IsFalse(result.Contains("https://"));
            Assert.AreEqual("leadmarket.com", result);
        }

        [Test]
        public void GetDomainNormalUrlWithComWithLocal()
        {
            Uri input = new Uri("http://dev.leadmarket.com");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("dev."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.com", result);
        }

        [Test]
        public void GetDomainNormalUrlWithComWithSubdomainWithLocal()
        {
            Uri input = new Uri("http://dev.admin.leadmarket.com");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("dev."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.IsFalse(result.Contains("admin."));
            Assert.AreEqual("leadmarket.com", result);
        }

        [Test]
        public void GetDomainNormalUrlWithCoUkWithSubdomainWithLocal()
        {
            Uri input = new Uri("http://dev.admin.leadmarket.co.uk");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".co.uk"));
            Assert.IsFalse(result.Contains("dev."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.IsFalse(result.Contains("admin."));
            Assert.AreEqual("leadmarket.co.uk", result);
        }

        [Test]
        public void GetDomainNormalUrlWithPort()
        {
            Uri input = new Uri("http://www.leadmarket.com:443");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.com", result);
            Assert.IsFalse(result.Contains(":443"));
        }

        [Test]
        public void GetDomainNormalUrlWithSubdomainWithPort()
        {
            Uri input = new Uri("http://admin.leadmarket.com:443");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("http://"));
            Assert.IsFalse(result.Contains("admin."));
            Assert.AreEqual("leadmarket.com", result);
            Assert.IsFalse(result.Contains(":443"));
        }

        [Test]
        public void GetDomainNormalUrlWithSubdomainWithLocalWithPort()
        {
            Uri input = new Uri("http://dev.admin.leadmarket.com:443");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("dev."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.IsFalse(result.Contains("admin."));
            Assert.AreEqual("leadmarket.com", result);
            Assert.IsFalse(result.Contains(":443"));
        }

        [Test]
        public void GetDomainNormalUrlWithCoUkWithSubdomainWithPort()
        {
            Uri input = new Uri("http://dev.admin.leadmarket.co.uk:443");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".co.uk"));
            Assert.IsFalse(result.Contains("dev."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.IsFalse(result.Contains("admin."));
            Assert.AreEqual("leadmarket.co.uk", result);
            Assert.IsFalse(result.Contains(":443"));
        }

        [Test]
        public void GetDomainNormalUrlWithFolder()
        {
            Uri input = new Uri("http://www.leadmarket.com/folder/");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("www."));
            Assert.IsFalse(result.Contains("https://"));
            Assert.AreEqual("leadmarket.com", result);
            Assert.IsFalse(result.Contains("folder"));
        }

        [Test]
        public void GetDomainNormalUrlWithFile()
        {
            Uri input = new Uri("http://www.leadmarket.com/default.aspx");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("www."));
            Assert.IsFalse(result.Contains("https://"));
            Assert.AreEqual("leadmarket.com", result);
            Assert.IsFalse(result.Contains("default.aspx"));
        }

        [Test]
        public void GetDomainNormalUrlWithCoUkWithSubdomainWithPortWithFolder()
        {
            Uri input = new Uri("http://dev.admin.leadmarket.co.uk:443/folder/");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".co.uk"));
            Assert.IsFalse(result.Contains("dev."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.IsFalse(result.Contains("admin."));
            Assert.AreEqual("leadmarket.co.uk", result);
            Assert.IsFalse(result.Contains(":443"));
            Assert.IsFalse(result.Contains("default.aspx"));
        }

        [Test]
        public void GetDomainNormalUrlWithCoUkWithSubdomainWithPortWithFile()
        {
            Uri input = new Uri("http://dev.admin.leadmarket.co.uk:443/default.aspx");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".co.uk"));
            Assert.IsFalse(result.Contains("dev."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.IsFalse(result.Contains("admin."));
            Assert.AreEqual("leadmarket.co.uk", result);
            Assert.IsFalse(result.Contains(":443"));
            Assert.IsFalse(result.Contains("default.aspx"));
        }

        [Test]
        public void GetDomainNormalUrlNoWWWWithCom()
        {
            Uri input = new Uri("http://leadmarket.com");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.com", result);
        }

        [Test]
        public void GetDomainNormalUrlNoWWWWithCoUk()
        {
            Uri input = new Uri("http://leadmarket.co.uk");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".co.uk"));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.co.uk", result);
        }

        [Test]
        public void GetDomainNormalUrlForStage()
        {
            Uri input = new Uri("http://stage.leadmarket.com");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("stage."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.AreEqual("leadmarket.com", result);
        }

        [Test]
        public void GetDomainNormalUrlForStageWithSubdomain()
        {
            Uri input = new Uri("http://stage.admin.leadmarket.com");
            String result = UriHelper.GetDomain(input);

            Assert.IsNotNullOrEmpty(result);
            Assert.IsTrue(result.Contains("leadmarket"));
            Assert.IsTrue(result.Contains(".com"));
            Assert.IsFalse(result.Contains("stage."));
            Assert.IsFalse(result.Contains("http://"));
            Assert.IsFalse(result.Contains("admin."));
            Assert.AreEqual("leadmarket.com", result);
        }
    }
}