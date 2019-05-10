using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace Squad_Stats
{
    public class Request
    {
        public Request()
        {

        }

        public void getCsgoStatsHtml(string csgoStatsUrl)
        {
            if (csgoStatsUrl == "")
                return;

            // TODO: Implement local html read

            //HtmlWeb web = new HtmlWeb();
            //var htmlDoc = web.Load(csgoStatsUrl);
            //var nodes = htmlDoc.DocumentNode.SelectNodes("//p");

            //foreach (var node in nodes) {
            //    Console.WriteLine("\nNode Name: " + node.Name + "\n" + node.OuterHtml);
            //}
        }
    }
}
