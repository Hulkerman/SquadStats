using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using HtmlAgilityPack;

namespace Squad_Stats
{
    public class Request
    {
        List<string> m_playerList = new List<string>();
        string[,] m_scoreArray = new string[10, 32];
        public Request()
        {
            return;
        }

        public List<string> getPlayerList()
        {
            return m_playerList;
        }

        public string[,] getScoreArray()
        {
            return m_scoreArray;
        }
        public void getCsgoStatsHtml()
        {

            var path = "C:/SquadStats_html_files/test.html";
            var doc = new HtmlDocument();
            int numberOfValues = 33;

            doc.Load(path);
            var stats = doc.DocumentNode.SelectNodes("//a[@class='player-link']/span | //a[@class='player-link']/parent::td/following-sibling::td[1]/following-sibling::td");
            
            int statNumber = 0, playerNumber = -1;
            foreach (var stat in stats)
            {
                if (statNumber < numberOfValues){
                    Console.Write(stat.InnerHtml.Trim() + " ");
                    if (statNumber == 0)
                    {
                        playerNumber++;
                        m_playerList.Add(stat.InnerHtml.Trim());
                        Console.Write("\n");
                    }
                    else
                    {
                        m_scoreArray[playerNumber, statNumber - 1] = stat.InnerHtml.Trim();
                    }
                    statNumber++;
                }
                else
                {
                    statNumber = 0;
                    Console.Write("\n\n");
                }
            }

            Console.WriteLine("done!\n");
        }
    }
}
