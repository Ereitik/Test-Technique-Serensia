using webcrawler;

namespace WebCrawlerTest
{
    [TestClass]
    public sealed class WebCrawlerTest
    {
        private readonly WebCrawler crawler = new();

        [TestMethod]
        public void Index1Depth()
        {
            var emails = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index.html", 1);

            Assert.HasCount(2, emails);

            Assert.Contains("nullepart@mozilla.org", emails);
            Assert.Contains("ailleurs@mozilla.org", emails);
        }

        [TestMethod]
        public void Index2Depth()
        {
            var emails = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index.html", 2);

            Assert.HasCount(3, emails);

            Assert.Contains("nullepart@mozilla.org", emails);
            Assert.Contains("ailleurs@mozilla.org", emails);
            Assert.Contains("loin@mozilla.org", emails);
        }

        [TestMethod]
        public void IndexAllDepth()
        {
            var emails = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index.html", -1);

            Assert.HasCount(3, emails);

            Assert.Contains("nullepart@mozilla.org", emails);
            Assert.Contains("ailleurs@mozilla.org", emails);
            Assert.Contains("loin@mozilla.org", emails);
        }


        [TestMethod]
        public void Index210Depth()
        {
            var emails = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index2.html", 10);

            Assert.HasCount(6, emails);

            Assert.Contains("contact@site.com", emails);
            Assert.Contains("support@site.com", emails);
            Assert.Contains("info@site.com", emails);
            Assert.Contains("admin@site.com", emails);
            Assert.Contains("sales@site.com", emails);
            Assert.Contains("ceo@site.com", emails);
        }

        [TestMethod]
        public void Index21Depth()
        {
            var emails = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index2.html", 1);

            Assert.HasCount(2, emails);

            Assert.Contains("contact@site.com", emails);
            Assert.Contains("support@site.com", emails);

            Assert.DoesNotContain("info@site.com:", emails);
        }

        [TestMethod]
        public void Index2AllDepth()
        {
            var emails = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index2.html", -1);

            Assert.HasCount(6, emails);

            Assert.Contains("contact@site.com", emails);
            Assert.Contains("support@site.com", emails);
            Assert.Contains("info@site.com", emails);
            Assert.Contains("admin@site.com", emails);
            Assert.Contains("sales@site.com", emails);
            Assert.Contains("ceo@site.com", emails);
        }

        [TestMethod]
        public void Index22Depth()
        {
            var emails = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index2.html", 2);

            Assert.HasCount(3, emails);

            Assert.Contains("contact@site.com", emails);
            Assert.Contains("support@site.com", emails);
            Assert.Contains("info@site.com", emails);
        }
    }
}
