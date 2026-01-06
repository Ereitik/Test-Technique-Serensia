// See https://aka.ms/new-console-template for more information
using webcrawler;


var crawler = new WebCrawler();
var emails = crawler.getEmailsInPageAndChidlPage(new WebBrowser(), "../../../index2.html", 10);

foreach (var email in emails)
{
    Console.WriteLine(email);
}

