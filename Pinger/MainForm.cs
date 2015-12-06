using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinger
{
    public partial class MainForm : Form
    {
        private PingTool tool = new PingTool();
        private int interval = 60;
        private Pings pings = new Pings();
        private int counter = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        
        // Start pinging
        private void btnRun_Click(object sender, EventArgs e)
        {
            interval = Convert.ToInt32(numInterval.Value) * 1000;
            timerStatusUpdate.Start();
            toolStripProgressBar1.Maximum = Convert.ToInt32(numInterval.Value);
            btnRun.Enabled = false;
            btnStop.Enabled = true;
            toolStripStatusLabel1.Text = "Running";
            
            // Force first ping immediatly
            this.ExecutePing();
        }

        // Show File Save dialog
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            
        }

        // Save ping results to file
        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            pings.SaveToFile(saveFileDialog.FileName);
        }

        // Stop pinging
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = true;
            btnStop.Enabled = false;
            timerStatusUpdate.Stop();
            toolStripStatusLabel1.Text = "Ready";
            toolStripProgressBar1.Value = 0;
        }

        // Update Progress bar and ping
        private void timerStatusUpdate_Tick(object sender, EventArgs e)
        {
            if (toolStripProgressBar1.Maximum == counter)
            {
                this.ExecutePing();
                counter = 0;
            } else
            {
                counter++;
                toolStripProgressBar1.Value = counter;
            }
            
        }

        // Ping
        private void ExecutePing()
        {
            PingResult ping = new PingResult();
            ping = tool.DoPing(txtHost.Text, Convert.ToInt32(numAttempts.Value), pings);
            txtShell.AppendText(ping + "\r\n");
        }
    }
}
