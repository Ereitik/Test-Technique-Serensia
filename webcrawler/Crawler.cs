using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace webcrawler
{
    public class WebCrawler : IAmTheTest
    {
        private HashSet<string> mails = new HashSet<string>();
        private Queue<string> urls = new Queue<string>();
        private HashSet<string> urlsHash = new HashSet<string>();

        public List<string> getEmailsInPageAndChidlPage(IWebBrowser browser, string url, int maximumDepth)
        {
            urlsHash.Add(url);

            var html = browser.GetHtml(url);

            XmlDocument document = new XmlDocument();

            document.LoadXml(html);

            var hrefs = document.GetElementsByTagName("a");

            foreach (XmlNode href in hrefs)
            {
                if (href.OuterXml.Contains("mailto"))
                {
                    mails.Add(Regex.Match(href.OuterXml.ToString(), "(?<=mailto:)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}").Value);
                }
                else
                {
                    urls.Enqueue(Regex.Match(href.OuterXml.ToString(), "(?<=\")[^\"]*(?=\")").Value);
                }

            }

            if (maximumDepth != -1)
            {
                maximumDepth = maximumDepth - 1;

                if (maximumDepth == -1)
                {
                    return mails.ToList();
                }
            }

            var nextUrl = urls.Dequeue();
            if (!urlsHash.Contains(nextUrl))
            {
                urlsHash.Add(nextUrl);
            }
            else
            {
                if (urls.Count == 0)
                {
                    return mails.ToList();
                }
                nextUrl = urls.Dequeue();
            }


            getEmailsInPageAndChidlPage(browser, nextUrl, maximumDepth);

            return mails.ToList();
        }
    }

    public class WebBrowser : IWebBrowser
    {
        public string GetHtml(string url)
        {
            return File.ReadAllText(url);
        }
    }
}
