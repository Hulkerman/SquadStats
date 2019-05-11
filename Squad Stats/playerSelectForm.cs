using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Squad_Stats
{
    public partial class playerSelectForm : Form
    {
        List<string> m_playerList = new List<string>();
        string[,] m_scoreArray = new string[10, 32];
        SquadExcel excel;
        public playerSelectForm(Request request, SquadExcel _excel)
        {
            InitializeComponent();
            excel = _excel;
            m_playerList.Add("");
            m_playerList.AddRange(request.getPlayerList());
            m_scoreArray = request.getScoreArray();
            foreach (ComboBox playerBox in this.grp_playerCombos.Controls.OfType<ComboBox>())
            {
                playerBox.Items.AddRange(m_playerList.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ComboBox playerBox in this.grp_playerCombos.Controls.OfType<ComboBox>())
            {
                if (playerBox.SelectedIndex >= 1)
                {
                    Console.WriteLine("\nplayer selected: " + m_playerList[playerBox.SelectedIndex]);
                    Console.WriteLine("Kills: " + m_scoreArray[playerBox.SelectedIndex - 1, 0]);
                }
            }
            excel.enterTrainStats();
        }
    }
}
