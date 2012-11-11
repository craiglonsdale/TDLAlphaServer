using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace TDL_Alpha_Server
{

    public partial class m_serverStarter : Form
    {
        private System.Windows.Forms.Timer m_upTimeTimer;
        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        private LogFileNotifier m_serverLogFileNotifier;
        private LogFileNotifier m_chatLogFileNotifier;
        private TDLServer m_tdlServer;

        public m_serverStarter()
        {
            InitializeComponent();
            m_playerConnected.Text = String.Format("{0}/{1}", 0, (int)m_playerNumber.Value);

            m_upTimeTimer = new System.Windows.Forms.Timer();
            m_upTimeTimer.Enabled = false;
            m_upTimeTimer.Interval = 1000;
            m_upTimeTimer.Tick += new EventHandler(m_upTimeTimer_Tick);
        }

        /// <summary>
        /// Updates the timer for the world Up-Time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_upTimeTimer_Tick(object sender, EventArgs e)
        {
            if (seconds < 59)
            {
                seconds++;
            }
            else
            {
                seconds = 0;
                if (minutes < 59)
                {
                    minutes++;
                }
                else
                {
                    minutes = 0;
                    hours++;
                }
            }

            m_upTime.Text = String.Format("{0}:{1}:{2}", hours.ToString(), minutes.ToString(), seconds.ToString());
        }

        private void m_startServer_Click(object sender, EventArgs e)
        {
            m_startServer.Enabled = false;
            m_stopServer.Enabled = true;

            m_upTimeTimer.Enabled = true;
            m_upTimeTimer.Start();

            try
            {
                //Disbles the section hold the server options
                m_options.Enabled = false;

                m_tdlServer = new TDLServer(this)
                {
                    
                    ServerName = m_serverName.Text,
                    ServerType = m_serverType.Controls.OfType<RadioButton>().Where(r => r.Checked == true).FirstOrDefault().Text.ToLower(),
                    MaxPlayers = (int)m_playerNumber.Value,
                    Visibility = m_serverVisibility.Controls.OfType<RadioButton>().Where(r => r.Checked == true).FirstOrDefault().Text.ToLower()
                };

                m_tdlServer.Start();
                m_chatLogFileNotifier = new LogFileNotifier(m_tdlServer.ChatLogFile, m_chatLog);
                m_serverLogFileNotifier = new LogFileNotifier(m_tdlServer.ServerLogFile, m_serverOutput);

                m_chatLog.DataBindings.Add("Text", m_chatLogFileNotifier, "FileContent");
                m_serverOutput.DataBindings.Add("Text", m_serverLogFileNotifier, "FileContent"); 
            }
            catch(Exception ex)
            {
                MessageBox.Show("TDLServerLog.txt file currently in use.\nPlease close it and try again.");
            }

        }


        /// <summary>
        /// Handles the events of processCompleted & processCanceled
        /// </summary>
        private void processCompletedOrCanceled(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            //btnOk.Enabled = true;
        }

        private void m_playerNumber_ValueChanged(object sender, EventArgs e)
        {
            m_playerConnected.Text = String.Format("{0}/{1}", 0 , (int)m_playerNumber.Value);
        }

        private void m_publicServer_CheckedChanged(object sender, EventArgs e)
        {
            m_playerNumber.Enabled = true;
        }

        private void m_soloOption_CheckedChanged(object sender, EventArgs e)
        {
            m_playerNumber.Value = 1;
        }

        private void m_serverStarter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_tdlServer != null)
                m_tdlServer.Dispose();
        }

        private void m_stopServer_Click(object sender, EventArgs e)
        {
            m_startServer.Enabled = true;
            m_stopServer.Enabled = false;

            m_chatLog.Clear();
            m_serverOutput.Clear();
            m_chatLog.DataBindings.Clear();
            m_serverOutput.DataBindings.Clear();

            //Destroy old server and set to null, ready for a new server
            if (m_tdlServer != null)
            { 
                m_tdlServer.Dispose();
                m_tdlServer = null;
            }

            //Set things back to default, ready to run again...
            m_options.Enabled = true;
            m_playerList.Items.Clear();
            m_upTime.Text = "00:00:00";
            m_upTimeTimer.Stop();
            m_upTimeTimer.Enabled = false;
            m_zombieKills.Text = "0";
            m_playerDeaths.Text = "0";
            m_playerConnected.Text = "0";
            m_worldSeed.Text = String.Empty;
        }

        private void m_serverOutput_TextChanged(object sender, EventArgs e)
        {
            m_serverOutput.SelectionStart = m_serverOutput.TextLength;
            m_serverOutput.ScrollToCaret();
            
            //Can't htink of a better place to update this code yet
            m_zombieKills.Text = m_tdlServer.ZombieKillCount.ToString();
            m_playerDeaths.Text = m_tdlServer.PlayerDeathCount.ToString();
            m_playerConnected.Text = m_tdlServer.ConnectedPlayersCount.ToString();

            //If we have a mismatch count between how many players the server says it has an how many the GUI says it has we update
            //the list accordingly
            if (m_playerList.Items.Count != m_tdlServer.ConnectedPlayers.Count)
            {
                m_playerList.Items.Clear(); 
                m_playerList.Items.AddRange(m_tdlServer.ConnectedPlayers.Select(player => player.PlayerName).ToArray());
            }

            if (m_worldSeed.Text == String.Empty)
            {
                m_worldSeed.Text = m_tdlServer.WorldSeed;
            }
        }

        private void m_chatLog_TextChanged(object sender, EventArgs e)
        {
            m_chatLog.SelectionStart = m_chatLog.TextLength;
            m_chatLog.ScrollToCaret();
        }
    }
}
