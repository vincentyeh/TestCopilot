using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

class WebTagExtractor
{
    static async Task Main(string[] args)
    {
        // 輸入網址與要擷取的 tag 名稱
        Console.Write("請輸入網址: ");
        string url = Console.ReadLine();
        Console.Write("請輸入要擷取的 tag (例如 div): ");
        string tag = Console.ReadLine();

        var httpClient = new HttpClient();
        string html = await httpClient.GetStringAsync(url);

        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);

        var nodes = htmlDoc.DocumentNode.SelectNodes($"//{tag}");
        if (nodes != null)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node.OuterHtml);
                Console.WriteLine("-----");
            }
        }
        else
        {
            Console.WriteLine($"找不到任何 <{tag}> tag。");
        }
    }
}
