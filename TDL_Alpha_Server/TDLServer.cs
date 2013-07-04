//Copyright (C) 2013 Craig Lonsdale
//Permission is hereby granted, free of charge, to any person obtaining a copy of 
//this software and associated documentation files (the "Software"), to deal in the 
//Software without restriction, including without limitation the rights to use, copy,
//modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
//and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial 
//portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
//LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
//SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TDL_Alpha_Server
{
    
    internal class StateObject
    {
        //Client Socket.
        public Socket WorkSocket = null;

        //Size of buffer to recieve;
        public const int BUFFER_SIZE = 256;

        //Recieve Buffer
        public byte[] Buffer = new byte[BUFFER_SIZE];

        //Recieved data string
        public StringBuilder sb = new StringBuilder();
    }

    /// <summary>
    /// OBject representing the TDL Server
    /// </summary>
    public class TDLServer : IDisposable
    {
        private ProcessCaller m_processCaller = null;
        private String m_serverArguments = String.Empty;
        private String m_saveFolder = String.Empty;
        private bool m_worldSeedFound = false;
        private long m_previousFileLength = 0;
        
        //Timer for looks at the server logs and updating
        private System.Threading.Timer m_timer;

        public TDLServer(ISynchronizeInvoke guiApp)
        {
            //Override old TDL Log file with empty text
            File.WriteAllText("TDLServerLog.txt", String.Empty);

            //Get the Server exe
            String TDLServerApp = @Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TDLServerMain.exe";

            m_processCaller = new ProcessCaller(guiApp);
            m_processCaller.FileName = TDLServerApp;
            ConnectedPlayers = new List<TDLPlayer>();
            CustomWorldSaveDir = String.Empty;
            AdminPassword = String.Empty;
            ServerPassword = String.Empty;
            ServerArguments = String.Empty;
        }

        /// <summary>
        /// Arguments ther server is running with.
        /// </summary>
        public String ServerArguments {get; private set;}

        /// <summary>
        /// Name of the server
        /// </summary>
        public String ServerName {get; set;}

        /// <summary>
        /// Type of server to run
        /// Dedicated or Listen
        /// </summary>
        public String ServerType {get; set;}

        /// <summary>
        /// Visibility of the server
        /// Public, Protected or Private
        /// </summary>
        public String Visibility {get; set;}

        /// <summary>
        /// Maximum number of players to join the server
        /// </summary>
        public int MaxPlayers {get; set;}

        /// <summary>
        /// Number of zombies killed in this server.
        /// </summary>
        public int ZombieKillCount{get; private set;}
        
        /// <summary>
        /// Number of players currently connected to the server.
        /// </summary>
        public int ConnectedPlayersCount
        {
            get
            {
                return ConnectedPlayers.Count;
            }
        }
        
        /// <summary>
        /// NUmber of times players have died on this server.
        /// </summary>
        public int PlayerDeathCount{get; private set;}

        /// <summary>
        /// The unique Seed Number of this world.
        /// </summary>
        public String WorldSeed{get; private set;}

        /// <summary>
        /// List of all players connected to the server.
        /// </summary>
        public List<TDLPlayer> ConnectedPlayers{get; private set;}

        /// <summary>
        /// The Path to the chat log file.
        /// </summary>
        public String ChatLogFile {get; private set;}

        /// <summary>
        /// The Path to the server log file.
        /// </summary>
        public String ServerLogFile {get; private set;}

        /// <summary>
        /// The Path to a customer world save directory.
        /// If Empty the default will be used.
        /// </summary>
        public String CustomWorldSaveDir {get; set;}

        /// <summary>
        /// The Administrator password for the server.
        /// If Empty the default will be used.
        /// </summary>
        public String AdminPassword {get; set;}

        /// <summary>
        /// The password for entering the server.
        /// If Empty there will be no server password.
        /// </summary>
        public String ServerPassword {get; set;}

        /// <summary>
        /// Enables/Disables Debugging mode for the server.
        /// </summary>
        public bool DebugMode { get; set;}

        /// <summary>
        /// Is the internal TDL server responding
        /// </summary>
        public bool ServerResponding
        {
            get{return m_processCaller.IsProcessResponsive;}
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        public void Start()
        {
            ServerArguments = @BuildCmdLineArgs();
            m_processCaller.Arguments = ServerArguments;
            m_processCaller.Start();
            m_saveFolder = String.Format("{0}_{1}", "TDLServer", DateTime.Now.ToLocalTime().ToFileTime());
            m_timer = new System.Threading.Timer(new TimerCallback(ParseLogContents), null, 0, 1000);

            Directory.CreateDirectory(m_saveFolder);

            ServerLogFile = String.Format(@"{0}\{1}", m_saveFolder, "TDLServerLog.txt");
            ChatLogFile = String.Format(@"{0}\{1}", m_saveFolder, "TDLChatLog.txt");

            File.Create(ServerLogFile).Close();
            File.Create(ChatLogFile).Close();
        }

        /// <summary>
        /// BUilds the server cammand line arguments based on infomation in the GUI.
        /// </summary>
        /// <returns>Command LIne Arguments</returns>
        private String BuildCmdLineArgs()
        {
            var commandLineArgs = new StringBuilder();
            
            //These default ones will always be included
            commandLineArgs.Append(String.Format(" --{0} --maxplayers={1} --gamemode={2} --servername=\"{3}\"", ServerType, MaxPlayers, Visibility, ServerName));
        
            //These following ones are optional
            //Custom location to save the world files
            if (CustomWorldSaveDir != String.Empty)
            {
                commandLineArgs.Append(String.Format(" --filepath=\"{0}\"", CustomWorldSaveDir));
            }

            //Server Entry Password
            if (ServerPassword != string.Empty)
            {
                commandLineArgs.Append(String.Format(" --password={0}", ServerPassword));
            }

            //Administrator Password
            if (AdminPassword != String.Empty)
            {
                //commandLineArgs.Append(String.Format(" --adminpass={0}", AdminPassword));
                ReplaceStringInFileContaining(@"\content\ServerConfig.tsc", "administratorPassword", "administratorPassword" + AdminPassword);
            }

            if (DebugMode)
            {
                commandLineArgs.Append(String.Format(" --debug", ServerPassword));
            }
            return commandLineArgs.ToString();
        }
        
        /// <summary>
        /// Writes the given chat log entry to the Chat Log created for this instance of the server.
        /// </summary>
        /// <param name="newChatLogEntry">Entry to write to the log</param>
        public void UpdateChatLog(string newChatLogEntry)
        {
            if (m_saveFolder != String.Empty)
            { 
                File.AppendAllText(ChatLogFile, newChatLogEntry);
            }
        }

        /// <summary>
        /// Writes the given server log entry to the Server Log created for this instance of the server.
        /// </summary>
        /// <param name="newServerLogEntry">Entry to write to the log</param>
        public void UpdateServerLog(string newServerLogEntry)
        {
            if (m_saveFolder != String.Empty)
            {
                File.AppendAllText(ServerLogFile, newServerLogEntry);
            }
        }

        /// <summary>
        /// Tell the server instance to stop.
        /// </summary>
        public void Dispose()
        {
            if (m_processCaller != null)
                m_processCaller.CancelAndWait();
        }

        /// <summary>
        /// Parses the latest contents in the log file.
        /// </summary>
        /// <param name="obj"></param>
        public void ParseLogContents(object obj)
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

                    UpdateServerLog(String.Format("{0} - {1}: {2} \r",
                                     DateTime.Now.ToLocalTime().ToShortDateString(),
                                     DateTime.Now.ToLocalTime().ToShortTimeString(),
                                     s));
                }

            }
        }

        private void FindUserJoined(string s)
        {

            /*Set net key table 414331190638781069 Player Avidan joined the game.*/
            string searchPattern = @"PlayerJoin: [0-9]+ '\b[a-zA-Z0-9_-]+\b'";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                //Create a new user and add them to the user list
                var splitString = match.ToString().Split(' ');

                var user = new TDLPlayer()
                {
                    UserID = splitString[1],
                    PlayerName = splitString[2].Replace("'", "")
                };
                ConnectedPlayers.Add(user);
            }
        }

        /// <summary>
        /// Looks through the given String for the values related to the world seed ID
        /// </summary>
        /// <param name="s">String to parse</param>
        private void FindWorldSeed(string s)
        {
            string searchPattern = @"Scenario seeds: (\b[0-9]+\b)";
            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                var splitString = match.ToString().Split(' ');
                WorldSeed = splitString[2];
                m_worldSeedFound = true;
            }
        }

        /// <summary>
        /// Looks through the given String for any values related to chat messages.
        /// </summary>
        /// <param name="s">String to parse.</param>
        private void FindChat(string s)
        {
            string searchPattern = @"\b[a-zA-Z0-9_-]+\b: .*";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                var splitString = match.ToString().Split(':');

                //Find if this is actually a player talking :|
                if (ConnectedPlayers.Any(player => String.Compare(player.PlayerName, splitString[0], ignoreCase: true) == 0))
                {
                    UpdateChatLog(String.Format("({0} - {1}) {2} : {3}\r",
                                     DateTime.Now.ToLocalTime().ToShortDateString(),
                                     DateTime.Now.ToLocalTime().ToShortTimeString(),
                                      splitString[0],
                                      splitString[1]));
                }

            }
        }

        /// <summary>
        /// Looks through the given String for any values related to users disconnecting.
        /// </summary>
        /// <param name="s">String to parse.</param>
        private void FindUserDisconnected(string s)
        {
            string searchPattern = @"PlayerLeft: \b[a-zA-Z0-9_-]+\b";//[0-9]+";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                var splitString = match.ToString().Split(' ');

                if (ConnectedPlayersCount > 0)
                {
                    ConnectedPlayers.Remove(ConnectedPlayers.Single(player => player.PlayerName == splitString[1]));
                }
            }
        }

        /// <summary>
        /// Looks through the given String for any values related to zombies dying.
        /// </summary>
        /// <param name="s">String to parse.</param>
        private void FindDeadZombies(string s)
        {
            string searchPattern = @"ZombieDied";//, inc count [0-9]+";

            //Not supported ATM
            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                //var splitString = match.ToString().Split(' ');
                ZombieKillCount++; // = Int32.Parse(splitString[4]);
            }
        }

        /// <summary>
        /// Looks through the given String for any values related to a player dying.
        /// </summary>
        /// <param name="s">String to parse.</param>
        private void FindUserDied(string s)
        {
            string searchPattern = @"PlayerDied: [0-9]+";

            var matches = Regex.Matches(s, searchPattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                var splitString = match.ToString().Split(' ');
                ConnectedPlayers.Single(player => player.UserID == splitString[1]).Deaths++;
                PlayerDeathCount++;
            }
        }

        /// <summary>
        /// Replaces a given string in a file with another.
        /// </summary>
        /// <param name="filePath">Path to the folder to update</param>
        /// <param name="contains">The string to replace.</param>
        /// <param name="replaceWith">The string to replace the 'contains' param with.</param>
        private void ReplaceStringInFileContaining(String filePath, String contains, String replaceWith)
        {
            var stringBuilder = new StringBuilder();

            var fileContents = File.ReadAllLines(filePath);

            foreach(var line in fileContents)
            {
                if (line.Contains(contains))
                {
                    stringBuilder.Append(replaceWith + "\r\n");
                }
                else
                {
                    stringBuilder.Append(line + "\r\n");
                }
            }

            File.WriteAllText(filePath, stringBuilder.ToString());
        }
    }
}
