using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDL_Alpha_Server
{
    public class PlayerPosition
    {
        public float X;
        public float Y;
        public float Z;
    }

    public class TDLPlayer
    {
        public String UserID { get; set; }
        public String PlayerName { get; set; }
        public int Deaths { get; set; }
        public int ZombieKills { get; set; }
        public PlayerPosition Position { get; set; }
    }
}
