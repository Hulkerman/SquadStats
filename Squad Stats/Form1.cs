using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Squad_Stats
{
    public partial class Form1 : Form
    {
        Request request = new Request();
        SquadExcel excel = new SquadExcel();
        public Form1()
        {
            InitializeComponent();
            request.DoSetup();
        }

        private void RequestStatsButton_Click(object sender, EventArgs e)
        {
            request.GetCsgoStatsHtml();
            var playerSelector = new playerSelectForm(request, excel);
            playerSelector.ShowDialog();
        }
    }
}
