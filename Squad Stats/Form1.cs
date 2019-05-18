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
        string squadStatsDir = @"C:\squadstats";
        public Form1()
        {
            InitializeComponent();
        }

        private void RequestStatsButton_Click(object sender, EventArgs e)
        {
            var playerSelector = new playerSelectForm(request, excel);
            try
            {
                playerSelector.ShowDialog();
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show("Some value hasn't been set or was unset. Probably due to a retarded programmer tbh...\n\nError:\n" + ex, "Null Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ObjectDisposedException ex)
            {
                MessageBox.Show("No matches found.\nIn order to export matches, save (ctrl + s) the csgostats.gg webpage of your analyzed match to the folder \"" + squadStatsDir + "\\\"\n\n" +
                    "Pro Tip: When saving, save it as type \"Webpage, HTML Only\".", "No Matches Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Generic Error\nI just couldn't be f*ucked to specify every single error yet. WIP\n\nError:\n" + ex, "Generic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
