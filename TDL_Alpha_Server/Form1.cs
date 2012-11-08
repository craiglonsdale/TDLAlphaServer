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

        private List<TDLPlayer> m_tdlPlayerList;
        private TDLServer m_tdlServer;

        private bool m_worldSeedFound = false;
        
        private System.Threading.Timer m_timer;
        private int m_zombieKillCount = 0;
        private int m_playersConnectedCount = 0;
        private int m_playerDeathCount = 0;

        public m_serverStarter()
        {
            InitializeComponent();
            this.m_playerConnected.Text = String.Format("{0}/{1}", m_playersConnectedCount, (int)m_playerNumber.Value);

            m_tdlPlayerList = new List<TDLPlayer>();

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

                m_timer = new System.Threading.Timer(new TimerCallback(DoSomething), null, 0, 1000);
            }
            catch(Exception ex)
            {
                MessageBox.Show("TDLServerLog.txt file currently in use.\nPlease close it and try again.");
            }

        }

        private long m_previousFileLength = 0;
        private void DoSomething(object obj)
        {
            using (FileStream fs = File.Open("TDLServerLog.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (fs.Length > m_previousFileLength && fs.Length != 0)
                { 
                    int seekDist = (int)fs.Length - (int)m_previousFileLength;

                    // Seek 1024 bytes from the end of the file
                    fs.Seek(-seekDist, SeekOrigin.End);
                    // read 1024 bytes
                    byte[] bytes = new byte[seekDist];
                    fs.Read(bytes, 0, seekDist);

                    m_previousFileLength = fs.Length;

                    // Convert bytes to string
                    string s = Encoding.Default.GetString(bytes);

                    if (!m_worldSeedFound)
                    {
                        FindWorldSeed(s);
                    }

                    //Finds if a user joined
                    FindUserJoined(s);
                    FindUserDisconnected(s);
                    FindDeadZombies(s);
                    FindUserDied(s);
                    FindChat(s);

                    this.m_serverOutput.AppendText(String.Format("{0}:{1}:{2} \t {3} \r", hours.ToString(), minutes.ToString(), seconds.ToString(), s));
                    this.m_serverOutput.ScrollToCaret();
                }

            }

            if (m_previousFileLength > 10000)
            {
                File.WriteAllText("TDLServerLog.txt", String.Empty);
                m_previousFileLength = 0;
            }
        }

        private void FindUserJoined(string s)
        {

            /*Set net key table 414331190638781069 Player Avidan joined the game.*/
            string searchPattern = @"(\b[0-9]+\b)\r\r\nPlayer (\b[a-zA-Z0-9_-]+\b) joined the game.";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                //Create a new user and add them to the user list
                var splitString = match.ToString().Split(new [] {' ','\r', '\n'});

                var user = new TDLPlayer()
                {
                    UserID = splitString[0],
                    PlayerName = splitString[4]
                };
                m_tdlPlayerList.Add(user);
                this.m_playerList.Items.Add(user.PlayerName);
                this.m_playerConnected.Text = String.Format("{0}/{1}", ++m_playersConnectedCount, m_tdlServer.MaxPlayers);
            }
        }

        private void FindWorldSeed(string s)
        {
            string searchPattern = @"Scenario seeds: (\b[0-9]+\b)";
            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                var splitString = match.ToString().Split(' ');
                this.m_worldSeed.Text = splitString[2];
                m_worldSeedFound = true;
            }
        }

        private void FindChat(string s)
        {
            string searchPattern = @"^\(Tm: 0, Scp: 0\): (.*) \(([0-9]+)\)\r\r\n";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                var userGuid = Regex.Match(match.ToString(), @"\(([0-9]+)\)\r\r\n$").ToString();
                var textNoGuid = match.ToString().Replace(userGuid, "");
                var textNoPrefix = textNoGuid.Replace(@"(Tm: 0, Scp: 0):", "");

                //Remove brackets from the guid for searching
                userGuid = userGuid.Substring(1, userGuid.Length - 5);

                var username = m_tdlPlayerList.Find(player => player.UserID == userGuid).PlayerName;

                this.m_chatLog.AppendText(String.Format("{0}:{1}\r", username, textNoPrefix));
            }

            this.m_serverOutput.ScrollToCaret();
        }

        private void FindUserDisconnected(string s)
        {
            string searchPattern = @"A client has disconnected.";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                this.m_playerConnected.Text = String.Format("{0}/{1}", --m_playersConnectedCount, m_tdlServer.MaxPlayers);
            }
        }

        private void FindDeadZombies(string s)
        {
            string searchPattern = @"Zombie Died.";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                m_zombieKillCount++;
                this.m_zombieKills.Text = m_zombieKillCount.ToString();
            }
        }

        private void FindUserDied(string s)
        {
            string searchPattern = @"Player Died.";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                m_playerDeathCount++;
                this.m_playerDeaths.Text = m_playerDeathCount.ToString();
            }
        }


        /// <summary>
        /// Handles the events of processCompleted & processCanceled
        /// </summary>
        private void processCompletedOrCanceled(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            //this.btnOk.Enabled = true;
        }

        private void m_playerNumber_ValueChanged(object sender, EventArgs e)
        {
            this.m_playerConnected.Text = String.Format("{0}/{1}", m_playersConnectedCount, (int)m_playerNumber.Value);
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
            m_tdlServer.Dispose();
        }
    }
}
