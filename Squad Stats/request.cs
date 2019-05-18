using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Linq;
using System.Collections;

namespace Squad_Stats
{
    public class Request
    {
        List<string> m_matchList = new List<string>();
        List<object> m_matchPlayersList = new List<object>();
        string[,] m_scoreArray = new string[10, 34];
        int m_numberOfValues = 34;
        string squadStatsDir = @"C:\squadstats";

        public Request()
        {
            return;
        }

        public bool DoSetup()
        {
            Array.Clear(m_scoreArray,0,m_scoreArray.Length);
            m_matchList.Clear();
            m_matchPlayersList.Clear();
            if (!Directory.Exists(squadStatsDir))
                Directory.CreateDirectory(squadStatsDir);
            if (!Directory.Exists(squadStatsDir + @"\excel"))
                Directory.CreateDirectory(squadStatsDir + @"\excel");
            if (!Directory.Exists(squadStatsDir + @"\archive"))
                Directory.CreateDirectory(squadStatsDir + @"\archive");
            foreach (string file in Directory.GetFiles(squadStatsDir))
            {
                if (Path.GetExtension(file) == ".html")
                {
                    m_matchList.Add(file);
                }
            }
            if (m_matchList.Count == 0)
            {
                //MessageBox.Show("No matches found.\nIn order to export matches, save (ctrl + s) the csgostats.gg webpage of your analyzed match to the folder \"" + squadStatsDir + "\\\"\n\n" +
                //    "Pro Tip: When saving, save it as type \"Webpage, HTML Only\".", "No Matches Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public List<string> GetMatchListTrimmed()
        {
            List<string> matchListTrimmed = new List<string>();
            foreach (string match in m_matchList)
            {
                matchListTrimmed.Add(Path.GetFileName(match).Substring(27,Path.GetFileName(match).Length - 32));
            }
            return matchListTrimmed;
        }

        public List<object> GetMatchPlayersList()
        {
            return m_matchPlayersList;
        }
        public void GetCsgoStatsHtml()
        {
            int matchNumber = 0, statNumber = 0, playerNumber = 0;
            foreach (string htmlFile in m_matchList.ToList())
            {
                playerNumber = 0;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(htmlFile);
                var stats = doc.DocumentNode.SelectNodes("//a[@class='player-link']/span | //a[@class='player-link']/parent::td/following-sibling::td[1]/following-sibling::td");
                if (stats != null)
                {
                    statNumber = 0;
                    foreach (var stat in stats)
                    {
                        if (statNumber == m_numberOfValues)
                        {
                            playerNumber++;
                            statNumber = 0;
                        }
                        m_scoreArray[playerNumber, statNumber] = stat.InnerHtml.Trim();
                        statNumber++;
                    }
                }
                else
                {
                    MessageBox.Show("File \"" + htmlFile + "\" could not be read.\nAre you sure it's a proper html file from csgostats.gg?", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_matchList.Remove(htmlFile);
                    goto endForeach;
                }
                m_matchPlayersList.Add(m_scoreArray.Clone());
                matchNumber++;
                endForeach:;
            }
        }

        public List<object> GetSpecificScoreArrayList(int _matchNumber, List<int> _playerNumbers)
        {
            List<object> specificScoreArrayList = new List<object>();
            string[,] currentMatchScoreArray = m_matchPlayersList[_matchNumber] as string[,];
            string[] currentPlayerScoreArray = new string[currentMatchScoreArray.Length/10];

            foreach (int playerNumber in _playerNumbers)
            {
                for (int i = 0; i < currentMatchScoreArray.Length/10; i++)
                {
                    currentPlayerScoreArray[i] = currentMatchScoreArray[playerNumber, i];
                }
                specificScoreArrayList.Add(currentPlayerScoreArray.Clone());
            }
            return specificScoreArrayList;
        }

        public void MoveHtmlFileToArchive(int currentMapNumber)
        {
            File.Move(m_matchList[currentMapNumber], squadStatsDir + @"\archive\" +  Directory.GetFiles(squadStatsDir + @"\archive\").Length + "_" + GetMatchListTrimmed()[currentMapNumber] + ".html");
        }
    }
}
