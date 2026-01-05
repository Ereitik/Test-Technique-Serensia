using System;
using System.Collections.Generic;
using System.Text;

namespace webcrawler
{
    public interface IAmTheTest
    {
       public List<string> getEmailsInPageAndChidlPage(IWebBrowser browser, string url, int maximumDepth);
    }

    public interface IWebBrowser
    {
        public string GetHtml(string url);
    }
}
