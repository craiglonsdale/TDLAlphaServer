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
using System.Drawing.Text;

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
        private bool m_customerFolderChosen;

        public m_serverStarter()
        {
            LoadCustomFont();
            InitializeComponent();
            ApplyCustomFonts(this.Controls);
              
            m_playerConnected.Text = String.Format("{0}/{1}", 0, (int)m_playerNumber.Value);

            m_upTimeTimer = new System.Windows.Forms.Timer();
            m_upTimeTimer.Enabled = false;
            m_upTimeTimer.Interval = 1000;
            m_upTimeTimer.Tick += new EventHandler(m_upTimeTimer_Tick);
            m_upTimeTimer.Tick += new EventHandler(CheckServerResponsivness);
            m_customerFolderChosen = false;
        }

        /// <summary>
        /// Updates the timer for the world Up-Time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CheckServerResponsivness(object sender, EventArgs e)
        {
            if (!m_tdlServer.ServerResponding)
            {
                KillServer();
                StartServer();
            }
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

        /// <summary>
        /// Called when the server is started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_startServer_Click(object sender, EventArgs e)
        {
            try
            {
                StartServer();
            }
            catch(Exception ex)
            {
                MessageBox.Show("TDLServerLog.txt file currently in use.\nPlease close it and try again.");
            }

        }

        /// <summary>
        /// Starts the server using the UI components values to generate command line arguments.
        /// </summary>
        private void StartServer()
        {
            m_startServer.Enabled = false;
            m_stopServer.Enabled = true;

            m_upTimeTimer.Enabled = true;
            m_upTimeTimer.Start();

            //Disbles the section hold the server options
            m_options.Enabled = false;

            m_tdlServer = new TDLServer(this)
            {
                ServerName = m_serverName.Text,
                ServerType = m_serverType.Controls.OfType<RadioButton>().Where(r => r.Checked == true).FirstOrDefault().Text.ToLower(),
                MaxPlayers = (int)m_playerNumber.Value,
                Visibility = m_serverVisibility.Controls.OfType<RadioButton>().Where(r => r.Checked == true).FirstOrDefault().Text.ToLower()
            };

            if (m_customerFolderChosen)
            {
                m_tdlServer.CustomWorldSaveDir = m_saveDirectory.Text;
            }

            if (m_serverPassword.Text != String.Empty)
            {
                m_tdlServer.ServerPassword = m_serverPassword.Text;
            }

            if (m_adminPassword.Text != String.Empty)
            {
                m_tdlServer.AdminPassword = m_adminPassword.Text;
            }

            if (m_debugLog.Checked)
            {
                m_tdlServer.DebugMode = true;
            }

            m_tdlServer.Start();

            //For Debugging
            //this.Text += m_tdlServer.ServerArguments;

            m_chatLogFileNotifier = new LogFileNotifier(m_tdlServer.ChatLogFile, m_chatLog);
            m_serverLogFileNotifier = new LogFileNotifier(m_tdlServer.ServerLogFile, m_serverOutput);

            //Updates the Server information and chat log on the GUI when the files are updated.
            m_chatLog.DataBindings.Add("Text", m_chatLogFileNotifier, "FileContent");
            m_serverOutput.DataBindings.Add("Text", m_serverLogFileNotifier, "FileContent");
        }


        /// <summary>
        /// Handles the events of processCompleted & processCanceled
        /// </summary>
        private void processCompletedOrCanceled(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            //btnOk.Enabled = true;
        }

        /// <summary>
        /// Handles when the number of players in the server changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_playerNumber_ValueChanged(object sender, EventArgs e)
        {
            m_playerConnected.Text = String.Format("{0}/{1}", 0 , (int)m_playerNumber.Value);
        }

        /// <summary>
        /// Updates the GUI when set as a public server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_publicServer_CheckedChanged(object sender, EventArgs e)
        {
            m_playerNumber.Enabled = true;
        }

        /// <summary>
        /// Updates the GUI when set as a solo server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_soloOption_CheckedChanged(object sender, EventArgs e)
        {
            m_playerNumber.Value = 1;
        }

        /// <summary>
        /// Closes off the TDL Server when we close this application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_serverStarter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_tdlServer != null)
                m_tdlServer.Dispose();
        }

        /// <summary>
        /// Stops the server and resets back to a fresh state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_stopServer_Click(object sender, EventArgs e)
        {
            KillServer();
            ResetUI();
        }

        /// <summary>
        /// Kills the server, but doesn't alter UI.
        /// </summary>
        private void KillServer()
        {
            //Destroy old server and set to null, ready for a new server
            if (m_tdlServer != null)
            {
                m_tdlServer.Dispose();
                m_tdlServer = null;
            }

            m_startServer.Enabled = true;
            m_stopServer.Enabled = false;

            m_chatLog.Clear();
            m_serverOutput.Clear();
            m_chatLog.DataBindings.Clear();
            m_serverOutput.DataBindings.Clear();
        }

        /// <summary>
        /// Resets the UI components.
        /// </summary>
        private void ResetUI()
        {
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

            m_serverPassword.Clear();
            m_adminPassword.Clear();

            m_saveDirectory.Text = "Default Directory";
            m_customerFolderChosen = false;
        }

        /// <summary>
        /// Called when the data in the Server Output text box changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_serverOutput_TextChanged(object sender, EventArgs e)
        {
            m_serverOutput.SelectionStart = m_serverOutput.TextLength;
            m_serverOutput.ScrollToCaret();
            
            //Can't think of a better place to update this code yet
            m_zombieKills.Text = m_tdlServer.ZombieKillCount.ToString();
            m_playerDeaths.Text = m_tdlServer.PlayerDeathCount.ToString();
            m_playerConnected.Text = String.Format("{0}/{1}", m_tdlServer.ConnectedPlayers.Count.ToString(), m_tdlServer.MaxPlayers.ToString());

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

        /// <summary>
        /// Called when the chat log text changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_chatLog_TextChanged(object sender, EventArgs e)
        {
            m_chatLog.SelectionStart = m_chatLog.TextLength;
            m_chatLog.ScrollToCaret();
        }

        /// <summary>
        /// Opens player GUI when the player name is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_playerList_DoubleClick(object sender, EventArgs e)
        {
            if (m_playerList.SelectedItem != null)
            {
                if (m_playerList.SelectedItem.ToString().Length != 0)
                {
                    var selectedPlayer = m_tdlServer.ConnectedPlayers.Single(player => player.PlayerName == m_playerList.SelectedItem.ToString());
                    MessageBox.Show(String.Format("Player: {0}\nUserID: {1}\nDeaths: {2}\n Kills: {3}",
                                                    selectedPlayer.PlayerName,
                                                    selectedPlayer.UserID,
                                                    selectedPlayer.Deaths,
                                                    selectedPlayer.ZombieKills));
                }
            }
        }

        /// <summary>
        /// Updates the folder where the log files will be saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_saveFolder_Click(object sender, EventArgs e)
        {
            var browser = new FolderBrowserDialog();
            DialogResult result = browser.ShowDialog();

            if (result == DialogResult.OK)
            {
                m_saveDirectory.Text = browser.SelectedPath;
                m_customerFolderChosen = true;
            }

        }
    }
}
