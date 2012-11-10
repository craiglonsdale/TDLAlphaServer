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
            this.m_options = new System.Windows.Forms.GroupBox();
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
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_serverVisibility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_playerNumber)).BeginInit();
            this.m_serverType.SuspendLayout();
            this.m_options.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_serverNameLabel
            // 
            this.m_serverNameLabel.AutoSize = true;
            this.m_serverNameLabel.Location = new System.Drawing.Point(6, 16);
            this.m_serverNameLabel.Name = "m_serverNameLabel";
            this.m_serverNameLabel.Size = new System.Drawing.Size(72, 13);
            this.m_serverNameLabel.TabIndex = 0;
            this.m_serverNameLabel.Text = "Server Name:";
            // 
            // m_maxPlayers
            // 
            this.m_maxPlayers.AutoSize = true;
            this.m_maxPlayers.Location = new System.Drawing.Point(7, 46);
            this.m_maxPlayers.Name = "m_maxPlayers";
            this.m_maxPlayers.Size = new System.Drawing.Size(67, 13);
            this.m_maxPlayers.TabIndex = 1;
            this.m_maxPlayers.Text = "Max Players:";
            // 
            // m_soloOption
            // 
            this.m_soloOption.AutoSize = true;
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
            this.m_protectedOption.Location = new System.Drawing.Point(6, 43);
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
            this.m_serverVisibility.Location = new System.Drawing.Point(5, 70);
            this.m_serverVisibility.Name = "m_serverVisibility";
            this.m_serverVisibility.Size = new System.Drawing.Size(210, 89);
            this.m_serverVisibility.TabIndex = 5;
            this.m_serverVisibility.TabStop = false;
            this.m_serverVisibility.Text = "Visibililty";
            // 
            // m_serverName
            // 
            this.m_serverName.Location = new System.Drawing.Point(80, 16);
            this.m_serverName.Name = "m_serverName";
            this.m_serverName.Size = new System.Drawing.Size(135, 20);
            this.m_serverName.TabIndex = 6;
            this.m_serverName.Text = "AvidanIsRad";
            // 
            // m_playerNumber
            // 
            this.m_playerNumber.Location = new System.Drawing.Point(80, 44);
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
            this.m_startServer.Location = new System.Drawing.Point(13, 252);
            this.m_startServer.Name = "m_startServer";
            this.m_startServer.Size = new System.Drawing.Size(75, 23);
            this.m_startServer.TabIndex = 8;
            this.m_startServer.Text = "Start Server";
            this.m_startServer.UseVisualStyleBackColor = true;
            this.m_startServer.Click += new System.EventHandler(this.m_startServer_Click);
            // 
            // m_serverType
            // 
            this.m_serverType.Controls.Add(this.m_listenType);
            this.m_serverType.Controls.Add(this.m_dedicatedType);
            this.m_serverType.Location = new System.Drawing.Point(5, 165);
            this.m_serverType.Name = "m_serverType";
            this.m_serverType.Size = new System.Drawing.Size(210, 64);
            this.m_serverType.TabIndex = 9;
            this.m_serverType.TabStop = false;
            this.m_serverType.Text = "Server Type";
            // 
            // m_listenType
            // 
            this.m_listenType.AutoSize = true;
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
            this.m_dedicatedType.Location = new System.Drawing.Point(7, 20);
            this.m_dedicatedType.Name = "m_dedicatedType";
            this.m_dedicatedType.Size = new System.Drawing.Size(74, 17);
            this.m_dedicatedType.TabIndex = 0;
            this.m_dedicatedType.TabStop = true;
            this.m_dedicatedType.Text = "Dedicated";
            this.m_dedicatedType.UseVisualStyleBackColor = true;
            // 
            // m_options
            // 
            this.m_options.Controls.Add(this.m_serverNameLabel);
            this.m_options.Controls.Add(this.m_serverType);
            this.m_options.Controls.Add(this.m_maxPlayers);
            this.m_options.Controls.Add(this.m_serverVisibility);
            this.m_options.Controls.Add(this.m_playerNumber);
            this.m_options.Controls.Add(this.m_serverName);
            this.m_options.Location = new System.Drawing.Point(13, 12);
            this.m_options.Name = "m_options";
            this.m_options.Size = new System.Drawing.Size(221, 234);
            this.m_options.TabIndex = 10;
            this.m_options.TabStop = false;
            // 
            // m_stopServer
            // 
            this.m_stopServer.Location = new System.Drawing.Point(159, 252);
            this.m_stopServer.Name = "m_stopServer";
            this.m_stopServer.Size = new System.Drawing.Size(75, 23);
            this.m_stopServer.TabIndex = 10;
            this.m_stopServer.Text = "Stop Server";
            this.m_stopServer.UseVisualStyleBackColor = true;
            this.m_stopServer.Click += new System.EventHandler(this.m_stopServer_Click);
            // 
            // m_serverOutput
            // 
            this.m_serverOutput.Location = new System.Drawing.Point(240, 19);
            this.m_serverOutput.Name = "m_serverOutput";
            this.m_serverOutput.ReadOnly = true;
            this.m_serverOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_serverOutput.Size = new System.Drawing.Size(457, 277);
            this.m_serverOutput.TabIndex = 11;
            this.m_serverOutput.Text = "";
            this.m_serverOutput.TextChanged += new System.EventHandler(this.m_serverOutput_TextChanged);
            // 
            // m_playerList
            // 
            this.m_playerList.FormattingEnabled = true;
            this.m_playerList.Location = new System.Drawing.Point(703, 19);
            this.m_playerList.Name = "m_playerList";
            this.m_playerList.Size = new System.Drawing.Size(160, 277);
            this.m_playerList.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Zombie Kills:";
            // 
            // m_zombieKills
            // 
            this.m_zombieKills.AutoSize = true;
            this.m_zombieKills.Location = new System.Drawing.Point(121, 21);
            this.m_zombieKills.Name = "m_zombieKills";
            this.m_zombieKills.Size = new System.Drawing.Size(13, 13);
            this.m_zombieKills.TabIndex = 14;
            this.m_zombieKills.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Connected Players:";
            // 
            // m_playerConnected
            // 
            this.m_playerConnected.AutoSize = true;
            this.m_playerConnected.Location = new System.Drawing.Point(121, 51);
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
            this.m_playerDeaths.Location = new System.Drawing.Point(121, 36);
            this.m_playerDeaths.Name = "m_playerDeaths";
            this.m_playerDeaths.Size = new System.Drawing.Size(13, 13);
            this.m_playerDeaths.TabIndex = 18;
            this.m_playerDeaths.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "World Seed:";
            // 
            // m_worldSeed
            // 
            this.m_worldSeed.AutoSize = true;
            this.m_worldSeed.Location = new System.Drawing.Point(117, 82);
            this.m_worldSeed.Name = "m_worldSeed";
            this.m_worldSeed.Size = new System.Drawing.Size(25, 13);
            this.m_worldSeed.TabIndex = 20;
            this.m_worldSeed.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "World Uptime:";
            // 
            // m_upTime
            // 
            this.m_upTime.AutoSize = true;
            this.m_upTime.Location = new System.Drawing.Point(117, 97);
            this.m_upTime.Name = "m_upTime";
            this.m_upTime.Size = new System.Drawing.Size(49, 13);
            this.m_upTime.TabIndex = 22;
            this.m_upTime.Text = "00:00:00";
            // 
            // m_chatLog
            // 
            this.m_chatLog.Location = new System.Drawing.Point(241, 323);
            this.m_chatLog.Name = "m_chatLog";
            this.m_chatLog.ReadOnly = true;
            this.m_chatLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_chatLog.Size = new System.Drawing.Size(621, 157);
            this.m_chatLog.TabIndex = 23;
            this.m_chatLog.Text = "";
            this.m_chatLog.TextChanged += new System.EventHandler(this.m_chatLog_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Chat:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_zombieKills);
            this.groupBox2.Controls.Add(this.m_upTime);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_playerConnected);
            this.groupBox2.Controls.Add(this.m_worldSeed);
            this.groupBox2.Controls.Add(this.m_playerDeaths);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 156);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // m_serverStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 488);
            this.Controls.Add(this.m_stopServer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_chatLog);
            this.Controls.Add(this.m_playerList);
            this.Controls.Add(this.m_startServer);
            this.Controls.Add(this.m_serverOutput);
            this.Controls.Add(this.m_options);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "m_serverStarter";
            this.Text = "The Dead Linger Alpha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.m_serverStarter_FormClosing);
            this.m_serverVisibility.ResumeLayout(false);
            this.m_serverVisibility.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_playerNumber)).EndInit();
            this.m_serverType.ResumeLayout(false);
            this.m_serverType.PerformLayout();
            this.m_options.ResumeLayout(false);
            this.m_options.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox m_options;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_stopServer;

    }
}

