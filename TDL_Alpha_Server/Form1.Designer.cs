using System.Drawing.Text;
using System.IO;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace TDL_Alpha_Server
{
    partial class m_serverStarter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private PrivateFontCollection m_privateFontCollection;
        private Font m_labelFont; 
        private void LoadCustomFont()
        {
            m_privateFontCollection = new PrivateFontCollection();
            m_privateFontCollection.AddFontFile(Directory.GetCurrentDirectory() + "\\content\\Capture_it.ttf");
        
            m_labelFont = new Font(m_privateFontCollection.Families[0], 10.0f, FontStyle.Regular);
        }

        private void ApplyCustomFonts(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Font = m_labelFont;
                             
                if (control.Controls.Count > 0)
                    ApplyCustomFonts(control.Controls);
            }

        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_serverNameLabel = new System.Windows.Forms.Label();
            this.m_maxPlayers = new System.Windows.Forms.Label();
            this.m_soloOption = new System.Windows.Forms.RadioButton();
            this.m_protectedOption = new System.Windows.Forms.RadioButton();
            this.m_publicServer = new System.Windows.Forms.RadioButton();
            this.m_serverVisibility = new System.Windows.Forms.GroupBox();
            this.m_serverName = new System.Windows.Forms.TextBox();
            this.m_playerNumber = new System.Windows.Forms.NumericUpDown();
            this.m_startServer = new System.Windows.Forms.Button();
            this.m_serverType = new System.Windows.Forms.GroupBox();
            this.m_listenType = new System.Windows.Forms.RadioButton();
            this.m_dedicatedType = new System.Windows.Forms.RadioButton();
            this.m_stopServer = new System.Windows.Forms.Button();
            this.m_serverOutput = new System.Windows.Forms.RichTextBox();
            this.m_playerList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_zombieKills = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_playerConnected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_playerDeaths = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_worldSeed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_upTime = new System.Windows.Forms.Label();
            this.m_chatLog = new System.Windows.Forms.RichTextBox();
            this.m_chatLabel = new System.Windows.Forms.Label();
            this.m_gameStats = new System.Windows.Forms.GroupBox();
            this.m_options = new System.Windows.Forms.Panel();
            this.m_adminPassword = new System.Windows.Forms.TextBox();
            this.m_adminPasswordLabel = new System.Windows.Forms.Label();
            this.m_serverPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_debugLog = new System.Windows.Forms.CheckBox();
            this.m_noGUI = new System.Windows.Forms.CheckBox();
            this.m_hideAll = new System.Windows.Forms.CheckBox();
            this.m_ignoreCommands = new System.Windows.Forms.CheckBox();
            this.m_saveFolder = new System.Windows.Forms.Button();
            this.m_saveDirectory = new System.Windows.Forms.Label();
            this.m_serverVisibility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_playerNumber)).BeginInit();
            this.m_serverType.SuspendLayout();
            this.m_gameStats.SuspendLayout();
            this.m_options.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_serverNameLabel
            // 
            this.m_serverNameLabel.AutoSize = true;
            this.m_serverNameLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.m_serverNameLabel.Location = new System.Drawing.Point(5, 12);
            this.m_serverNameLabel.Name = "m_serverNameLabel";
            this.m_serverNameLabel.Size = new System.Drawing.Size(72, 13);
            this.m_serverNameLabel.TabIndex = 0;
            this.m_serverNameLabel.Text = "Server Name:";
            // 
            // m_maxPlayers
            // 
            this.m_maxPlayers.AutoSize = true;
            this.m_maxPlayers.ForeColor = System.Drawing.Color.DarkRed;
            this.m_maxPlayers.Location = new System.Drawing.Point(5, 87);
            this.m_maxPlayers.Name = "m_maxPlayers";
            this.m_maxPlayers.Size = new System.Drawing.Size(67, 13);
            this.m_maxPlayers.TabIndex = 1;
            this.m_maxPlayers.Text = "Max Players:";
            // 
            // m_soloOption
            // 
            this.m_soloOption.AutoSize = true;
            this.m_soloOption.ForeColor = System.Drawing.Color.DarkRed;
            this.m_soloOption.Location = new System.Drawing.Point(6, 20);
            this.m_soloOption.Name = "m_soloOption";
            this.m_soloOption.Size = new System.Drawing.Size(46, 17);
            this.m_soloOption.TabIndex = 2;
            this.m_soloOption.Text = "Solo";
            this.m_soloOption.UseVisualStyleBackColor = true;
            this.m_soloOption.CheckedChanged += new System.EventHandler(this.m_soloOption_CheckedChanged);
            // 
            // m_protectedOption
            // 
            this.m_protectedOption.AutoSize = true;
            this.m_protectedOption.ForeColor = System.Drawing.Color.DarkRed;
            this.m_protectedOption.Location = new System.Drawing.Point(4, 43);
            this.m_protectedOption.Name = "m_protectedOption";
            this.m_protectedOption.Size = new System.Drawing.Size(71, 17);
            this.m_protectedOption.TabIndex = 3;
            this.m_protectedOption.Text = "Protected";
            this.m_protectedOption.UseVisualStyleBackColor = true;
            // 
            // m_publicServer
            // 
            this.m_publicServer.AutoSize = true;
            this.m_publicServer.Checked = true;
            this.m_publicServer.ForeColor = System.Drawing.Color.DarkRed;
            this.m_publicServer.Location = new System.Drawing.Point(6, 67);
            this.m_publicServer.Name = "m_publicServer";
            this.m_publicServer.Size = new System.Drawing.Size(54, 17);
            this.m_publicServer.TabIndex = 4;
            this.m_publicServer.TabStop = true;
            this.m_publicServer.Text = "Public";
            this.m_publicServer.UseVisualStyleBackColor = true;
            this.m_publicServer.CheckedChanged += new System.EventHandler(this.m_publicServer_CheckedChanged);
            // 
            // m_serverVisibility
            // 
            this.m_serverVisibility.Controls.Add(this.m_protectedOption);
            this.m_serverVisibility.Controls.Add(this.m_publicServer);
            this.m_serverVisibility.Controls.Add(this.m_soloOption);
            this.m_serverVisibility.Location = new System.Drawing.Point(8, 142);
            this.m_serverVisibility.Name = "m_serverVisibility";
            this.m_serverVisibility.Size = new System.Drawing.Size(195, 89);
            this.m_serverVisibility.TabIndex = 5;
            this.m_serverVisibility.TabStop = false;
            this.m_serverVisibility.Text = "Visibililty";
            // 
            // m_serverName
            // 
            this.m_serverName.Location = new System.Drawing.Point(145, 9);
            this.m_serverName.Name = "m_serverName";
            this.m_serverName.Size = new System.Drawing.Size(90, 20);
            this.m_serverName.TabIndex = 6;
            this.m_serverName.Text = "AvidanIsRad";
            // 
            // m_playerNumber
            // 
            this.m_playerNumber.Location = new System.Drawing.Point(145, 84);
            this.m_playerNumber.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.m_playerNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_playerNumber.Name = "m_playerNumber";
            this.m_playerNumber.Size = new System.Drawing.Size(36, 20);
            this.m_playerNumber.TabIndex = 7;
            this.m_playerNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_playerNumber.ValueChanged += new System.EventHandler(this.m_playerNumber_ValueChanged);
            // 
            // m_startServer
            // 
            this.m_startServer.Location = new System.Drawing.Point(12, 252);
            this.m_startServer.Name = "m_startServer";
            this.m_startServer.Size = new System.Drawing.Size(61, 23);
            this.m_startServer.TabIndex = 8;
            this.m_startServer.Text = "Start";
            this.m_startServer.UseVisualStyleBackColor = true;
            this.m_startServer.Click += new System.EventHandler(this.m_startServer_Click);
            // 
            // m_serverType
            // 
            this.m_serverType.Controls.Add(this.m_listenType);
            this.m_serverType.Controls.Add(this.m_dedicatedType);
            this.m_serverType.Location = new System.Drawing.Point(213, 142);
            this.m_serverType.Name = "m_serverType";
            this.m_serverType.Size = new System.Drawing.Size(116, 89);
            this.m_serverType.TabIndex = 9;
            this.m_serverType.TabStop = false;
            this.m_serverType.Text = "Server Type";
            // 
            // m_listenType
            // 
            this.m_listenType.AutoSize = true;
            this.m_listenType.ForeColor = System.Drawing.Color.DarkRed;
            this.m_listenType.Location = new System.Drawing.Point(7, 41);
            this.m_listenType.Name = "m_listenType";
            this.m_listenType.Size = new System.Drawing.Size(53, 17);
            this.m_listenType.TabIndex = 1;
            this.m_listenType.Text = "Listen";
            this.m_listenType.UseVisualStyleBackColor = true;
            // 
            // m_dedicatedType
            // 
            this.m_dedicatedType.AutoSize = true;
            this.m_dedicatedType.Checked = true;
            this.m_dedicatedType.ForeColor = System.Drawing.Color.DarkRed;
            this.m_dedicatedType.Location = new System.Drawing.Point(7, 26);
            this.m_dedicatedType.Name = "m_dedicatedType";
            this.m_dedicatedType.Size = new System.Drawing.Size(74, 17);
            this.m_dedicatedType.TabIndex = 0;
            this.m_dedicatedType.TabStop = true;
            this.m_dedicatedType.Text = "Dedicated";
            this.m_dedicatedType.UseVisualStyleBackColor = true;
            // 
            // m_stopServer
            // 
            this.m_stopServer.Enabled = false;
            this.m_stopServer.Location = new System.Drawing.Point(79, 252);
            this.m_stopServer.Name = "m_stopServer";
            this.m_stopServer.Size = new System.Drawing.Size(60, 23);
            this.m_stopServer.TabIndex = 10;
            this.m_stopServer.Text = "Stop";
            this.m_stopServer.UseVisualStyleBackColor = true;
            this.m_stopServer.Click += new System.EventHandler(this.m_stopServer_Click);
            // 
            // m_serverOutput
            // 
            this.m_serverOutput.Location = new System.Drawing.Point(365, 12);
            this.m_serverOutput.Name = "m_serverOutput";
            this.m_serverOutput.ReadOnly = true;
            this.m_serverOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_serverOutput.Size = new System.Drawing.Size(692, 234);
            this.m_serverOutput.TabIndex = 11;
            this.m_serverOutput.Text = "";
            this.m_serverOutput.TextChanged += new System.EventHandler(this.m_serverOutput_TextChanged);
            // 
            // m_playerList
            // 
            this.m_playerList.FormattingEnabled = true;
            this.m_playerList.Location = new System.Drawing.Point(1063, 12);
            this.m_playerList.Name = "m_playerList";
            this.m_playerList.Size = new System.Drawing.Size(160, 238);
            this.m_playerList.TabIndex = 12;
            this.m_playerList.DoubleClick += new System.EventHandler(this.m_playerList_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Zombie Kills:";
            // 
            // m_zombieKills
            // 
            this.m_zombieKills.AutoSize = true;
            this.m_zombieKills.ForeColor = System.Drawing.Color.DarkRed;
            this.m_zombieKills.Location = new System.Drawing.Point(201, 21);
            this.m_zombieKills.Name = "m_zombieKills";
            this.m_zombieKills.Size = new System.Drawing.Size(13, 13);
            this.m_zombieKills.TabIndex = 14;
            this.m_zombieKills.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(19, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Connected Players:";
            // 
            // m_playerConnected
            // 
            this.m_playerConnected.AutoSize = true;
            this.m_playerConnected.ForeColor = System.Drawing.Color.DarkRed;
            this.m_playerConnected.Location = new System.Drawing.Point(201, 51);
            this.m_playerConnected.Name = "m_playerConnected";
            this.m_playerConnected.Size = new System.Drawing.Size(13, 13);
            this.m_playerConnected.TabIndex = 16;
            this.m_playerConnected.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Player Deaths:";
            // 
            // m_playerDeaths
            // 
            this.m_playerDeaths.AutoSize = true;
            this.m_playerDeaths.ForeColor = System.Drawing.Color.DarkRed;
            this.m_playerDeaths.Location = new System.Drawing.Point(201, 36);
            this.m_playerDeaths.Name = "m_playerDeaths";
            this.m_playerDeaths.Size = new System.Drawing.Size(13, 13);
            this.m_playerDeaths.TabIndex = 18;
            this.m_playerDeaths.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(19, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "World Seed:";
            // 
            // m_worldSeed
            // 
            this.m_worldSeed.AutoSize = true;
            this.m_worldSeed.ForeColor = System.Drawing.Color.DarkRed;
            this.m_worldSeed.Location = new System.Drawing.Point(201, 84);
            this.m_worldSeed.Name = "m_worldSeed";
            this.m_worldSeed.Size = new System.Drawing.Size(0, 13);
            this.m_worldSeed.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(19, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "World Uptime:";
            // 
            // m_upTime
            // 
            this.m_upTime.AutoSize = true;
            this.m_upTime.Location = new System.Drawing.Point(201, 97);
            this.m_upTime.Name = "m_upTime";
            this.m_upTime.Size = new System.Drawing.Size(49, 13);
            this.m_upTime.TabIndex = 22;
            this.m_upTime.Text = "00:00:00";
            // 
            // m_chatLog
            // 
            this.m_chatLog.Location = new System.Drawing.Point(365, 306);
            this.m_chatLog.Name = "m_chatLog";
            this.m_chatLog.ReadOnly = true;
            this.m_chatLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_chatLog.Size = new System.Drawing.Size(858, 266);
            this.m_chatLog.TabIndex = 23;
            this.m_chatLog.Text = "";
            this.m_chatLog.TextChanged += new System.EventHandler(this.m_chatLog_TextChanged);
            // 
            // m_chatLabel
            // 
            this.m_chatLabel.AutoSize = true;
            this.m_chatLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_chatLabel.ForeColor = System.Drawing.Color.Black;
            this.m_chatLabel.Location = new System.Drawing.Point(1183, 290);
            this.m_chatLabel.Name = "m_chatLabel";
            this.m_chatLabel.Size = new System.Drawing.Size(29, 13);
            this.m_chatLabel.TabIndex = 24;
            this.m_chatLabel.Text = "Chat";
            // 
            // m_gameStats
            // 
            this.m_gameStats.BackColor = System.Drawing.Color.Transparent;
            this.m_gameStats.Controls.Add(this.label3);
            this.m_gameStats.Controls.Add(this.label1);
            this.m_gameStats.Controls.Add(this.m_zombieKills);
            this.m_gameStats.Controls.Add(this.m_upTime);
            this.m_gameStats.Controls.Add(this.label2);
            this.m_gameStats.Controls.Add(this.label5);
            this.m_gameStats.Controls.Add(this.m_playerConnected);
            this.m_gameStats.Controls.Add(this.m_worldSeed);
            this.m_gameStats.Controls.Add(this.m_playerDeaths);
            this.m_gameStats.Controls.Add(this.label4);
            this.m_gameStats.ForeColor = System.Drawing.Color.DarkRed;
            this.m_gameStats.Location = new System.Drawing.Point(12, 306);
            this.m_gameStats.Name = "m_gameStats";
            this.m_gameStats.Size = new System.Drawing.Size(332, 266);
            this.m_gameStats.TabIndex = 25;
            this.m_gameStats.TabStop = false;
            // 
            // m_options
            // 
            this.m_options.BackColor = System.Drawing.Color.Transparent;
            this.m_options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_options.Controls.Add(this.m_adminPassword);
            this.m_options.Controls.Add(this.m_adminPasswordLabel);
            this.m_options.Controls.Add(this.m_serverPassword);
            this.m_options.Controls.Add(this.label6);
            this.m_options.Controls.Add(this.m_serverNameLabel);
            this.m_options.Controls.Add(this.m_serverName);
            this.m_options.Controls.Add(this.m_playerNumber);
            this.m_options.Controls.Add(this.m_serverType);
            this.m_options.Controls.Add(this.m_serverVisibility);
            this.m_options.Controls.Add(this.m_maxPlayers);
            this.m_options.Location = new System.Drawing.Point(13, 12);
            this.m_options.Name = "m_options";
            this.m_options.Size = new System.Drawing.Size(332, 234);
            this.m_options.TabIndex = 26;
            // 
            // m_adminPassword
            // 
            this.m_adminPassword.Location = new System.Drawing.Point(145, 58);
            this.m_adminPassword.Name = "m_adminPassword";
            this.m_adminPassword.Size = new System.Drawing.Size(90, 20);
            this.m_adminPassword.TabIndex = 13;
            // 
            // m_adminPasswordLabel
            // 
            this.m_adminPasswordLabel.AutoSize = true;
            this.m_adminPasswordLabel.ForeColor = System.Drawing.Color.Maroon;
            this.m_adminPasswordLabel.Location = new System.Drawing.Point(5, 61);
            this.m_adminPasswordLabel.Name = "m_adminPasswordLabel";
            this.m_adminPasswordLabel.Size = new System.Drawing.Size(88, 13);
            this.m_adminPasswordLabel.TabIndex = 12;
            this.m_adminPasswordLabel.Text = "Admin Password:";
            // 
            // m_serverPassword
            // 
            this.m_serverPassword.Location = new System.Drawing.Point(145, 34);
            this.m_serverPassword.Name = "m_serverPassword";
            this.m_serverPassword.Size = new System.Drawing.Size(90, 20);
            this.m_serverPassword.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(5, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Password:";
            // 
            // m_debugLog
            // 
            this.m_debugLog.AutoSize = true;
            this.m_debugLog.BackColor = System.Drawing.Color.Transparent;
            this.m_debugLog.ForeColor = System.Drawing.Color.Maroon;
            this.m_debugLog.Location = new System.Drawing.Point(1083, 578);
            this.m_debugLog.Name = "m_debugLog";
            this.m_debugLog.Size = new System.Drawing.Size(58, 17);
            this.m_debugLog.TabIndex = 27;
            this.m_debugLog.Text = "Debug";
            this.m_debugLog.UseVisualStyleBackColor = false;
            // 
            // m_noGUI
            // 
            this.m_noGUI.AutoSize = true;
            this.m_noGUI.BackColor = System.Drawing.Color.Transparent;
            this.m_noGUI.Enabled = false;
            this.m_noGUI.ForeColor = System.Drawing.Color.Maroon;
            this.m_noGUI.Location = new System.Drawing.Point(1083, 594);
            this.m_noGUI.Name = "m_noGUI";
            this.m_noGUI.Size = new System.Drawing.Size(59, 17);
            this.m_noGUI.TabIndex = 28;
            this.m_noGUI.Text = "No Gui";
            this.m_noGUI.UseVisualStyleBackColor = false;
            // 
            // m_hideAll
            // 
            this.m_hideAll.AutoSize = true;
            this.m_hideAll.BackColor = System.Drawing.Color.Transparent;
            this.m_hideAll.Enabled = false;
            this.m_hideAll.ForeColor = System.Drawing.Color.Maroon;
            this.m_hideAll.Location = new System.Drawing.Point(1083, 610);
            this.m_hideAll.Name = "m_hideAll";
            this.m_hideAll.Size = new System.Drawing.Size(62, 17);
            this.m_hideAll.TabIndex = 29;
            this.m_hideAll.Text = "Hide All";
            this.m_hideAll.UseVisualStyleBackColor = false;
            // 
            // m_ignoreCommands
            // 
            this.m_ignoreCommands.AutoSize = true;
            this.m_ignoreCommands.BackColor = System.Drawing.Color.Transparent;
            this.m_ignoreCommands.Enabled = false;
            this.m_ignoreCommands.ForeColor = System.Drawing.Color.Maroon;
            this.m_ignoreCommands.Location = new System.Drawing.Point(1083, 626);
            this.m_ignoreCommands.Name = "m_ignoreCommands";
            this.m_ignoreCommands.Size = new System.Drawing.Size(80, 17);
            this.m_ignoreCommands.TabIndex = 30;
            this.m_ignoreCommands.Text = "Ignore Cmd";
            this.m_ignoreCommands.UseVisualStyleBackColor = false;
            // 
            // m_saveFolder
            // 
            this.m_saveFolder.Location = new System.Drawing.Point(365, 615);
            this.m_saveFolder.Name = "m_saveFolder";
            this.m_saveFolder.Size = new System.Drawing.Size(114, 28);
            this.m_saveFolder.TabIndex = 31;
            this.m_saveFolder.Text = "Save Folder";
            this.m_saveFolder.UseVisualStyleBackColor = true;
            this.m_saveFolder.Click += new System.EventHandler(this.m_saveFolder_Click);
            // 
            // m_saveDirectory
            // 
            this.m_saveDirectory.AutoSize = true;
            this.m_saveDirectory.BackColor = System.Drawing.Color.Transparent;
            this.m_saveDirectory.Location = new System.Drawing.Point(495, 621);
            this.m_saveDirectory.Name = "m_saveDirectory";
            this.m_saveDirectory.Size = new System.Drawing.Size(86, 13);
            this.m_saveDirectory.TabIndex = 32;
            this.m_saveDirectory.Text = "Default Directory";
            // 
            // m_serverStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TDL_Alpha_Server.Properties.Resources.TestBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1235, 649);
            this.Controls.Add(this.m_saveDirectory);
            this.Controls.Add(this.m_saveFolder);
            this.Controls.Add(this.m_ignoreCommands);
            this.Controls.Add(this.m_hideAll);
            this.Controls.Add(this.m_noGUI);
            this.Controls.Add(this.m_debugLog);
            this.Controls.Add(this.m_options);
            this.Controls.Add(this.m_stopServer);
            this.Controls.Add(this.m_gameStats);
            this.Controls.Add(this.m_chatLabel);
            this.Controls.Add(this.m_chatLog);
            this.Controls.Add(this.m_playerList);
            this.Controls.Add(this.m_serverOutput);
            this.Controls.Add(this.m_startServer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "m_serverStarter";
            this.Text = "The Dead Linger Alpha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.m_serverStarter_FormClosing);
            this.m_serverVisibility.ResumeLayout(false);
            this.m_serverVisibility.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_playerNumber)).EndInit();
            this.m_serverType.ResumeLayout(false);
            this.m_serverType.PerformLayout();
            this.m_gameStats.ResumeLayout(false);
            this.m_gameStats.PerformLayout();
            this.m_options.ResumeLayout(false);
            this.m_options.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_serverNameLabel;
        private System.Windows.Forms.Label m_maxPlayers;
        private System.Windows.Forms.RadioButton m_soloOption;
        private System.Windows.Forms.RadioButton m_protectedOption;
        private System.Windows.Forms.RadioButton m_publicServer;
        private System.Windows.Forms.GroupBox m_serverVisibility;
        private System.Windows.Forms.TextBox m_serverName;
        private System.Windows.Forms.NumericUpDown m_playerNumber;
        private System.Windows.Forms.Button m_startServer;
        private System.Windows.Forms.GroupBox m_serverType;
        private System.Windows.Forms.RadioButton m_listenType;
        private System.Windows.Forms.RadioButton m_dedicatedType;
        private System.Windows.Forms.RichTextBox m_serverOutput;
        private System.Windows.Forms.ListBox m_playerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_zombieKills;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_playerConnected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_playerDeaths;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label m_worldSeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label m_upTime;
        private System.Windows.Forms.RichTextBox m_chatLog;
        private System.Windows.Forms.Label m_chatLabel;
        private System.Windows.Forms.GroupBox m_gameStats;
        private System.Windows.Forms.Button m_stopServer;
        private Panel m_options;
        private TextBox m_serverPassword;
        private Label label6;
        private Label m_adminPasswordLabel;
        private TextBox m_adminPassword;
        private CheckBox m_debugLog;
        private CheckBox m_noGUI;
        private CheckBox m_hideAll;
        private CheckBox m_ignoreCommands;
        private Button m_saveFolder;
        private Label m_saveDirectory;

    }
}

