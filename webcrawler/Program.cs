// See https://aka.ms/new-console-template for more information
using webcrawler;


var crawler = new WebCrawler();
var urls = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index2.html", -1);

foreach (var url in urls)
{
    Console.WriteLine(url);
}

