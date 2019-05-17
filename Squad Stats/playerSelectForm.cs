using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Squad_Stats
{
    public partial class playerSelectForm : Form
    {
        List<string> m_playerList = new List<string>();
        List<string> m_MatchList = new List<string>();
        List<object> m_matchPlayersList = new List<object>();
        List<int> m_playerNumberList = new List<int>();
        Request request;
        SquadExcel excel;
        public playerSelectForm(Request _request, SquadExcel _excel)
        {
            InitializeComponent();
            request = _request;
            excel = _excel;
            m_MatchList = _request.GetMatchListTrimmed();
            m_matchPlayersList = _request.GetMatchPlayersList();

            this.cmb_match.Items.AddRange(m_MatchList.ToArray());
            excel.DoSetup();
        }

        private void btn_extract_Click(object sender, EventArgs e)
        {
            int playerBoxNumber = 0;
            List<int> m_playerPosList = new List<int>();
            foreach (ComboBox playerBox in this.grp_playerCombos.Controls.OfType<ComboBox>())
            {
                playerBoxNumber++;
                if (playerBox.SelectedIndex >= 0)
                {
                    m_playerNumberList.Add(playerBox.SelectedIndex);
                    m_playerPosList.Add(playerBoxNumber);
                }
            }
            if (m_playerNumberList.Count != 0)
            {
                excel.EnterStats(m_playerPosList, request.GetSpecificScoreArrayList(cmb_match.SelectedIndex, m_playerNumberList));
            }
        }

        private void Cmb_match_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_playerList.Clear();
            IEnumerable m_matchPlayersListConverted = m_matchPlayersList[cmb_match.SelectedIndex] as IEnumerable;
            int statCount = 0;
            foreach (string statName in m_matchPlayersListConverted)
            {
                if (statCount % 34 == 0)
                {
                    m_playerList.Add(statName);
                }
                statCount++;
            }
            foreach (ComboBox playerBox in this.grp_playerCombos.Controls.OfType<ComboBox>())
            {
                playerBox.Items.Clear();
                playerBox.Items.AddRange(m_playerList.ToArray());
            }
        }

        private void PlayerSelectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            excel.Quit();
        }
    }
}
