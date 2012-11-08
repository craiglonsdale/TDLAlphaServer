using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace TDL_Alpha_Server
{
    /// <summary>
    /// OBject representing the TDL Server
    /// </summary>
    public class TDLServer : IDisposable
    {
        private ProcessCaller m_processCaller = null;
        private String m_serverArguments = String.Empty;

        public TDLServer(ISynchronizeInvoke guiApp)
        {
            //Override old TDL Log file with empty text
            File.WriteAllText("TDLServerLog.txt", String.Empty);

            //Get the Server exe
            String TDLServerApp = @Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TDLServerMain.exe";

            m_processCaller = new ProcessCaller(guiApp);
            m_processCaller.FileName = TDLServerApp;
        }

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

        public void Start()
        {
            m_serverArguments = String.Format(" --{0} --maxplayers={1} --gamemode={2} --servername={3}", ServerType, MaxPlayers, Visibility, ServerName);
            m_processCaller.Arguments = m_serverArguments;
            m_processCaller.Start();

        }

        public void Dispose()
        {
            if (m_processCaller != null)
                m_processCaller.CancelAndWait();
        }
    }
}
