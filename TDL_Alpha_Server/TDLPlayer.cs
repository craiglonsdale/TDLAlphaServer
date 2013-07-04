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

namespace TDL_Alpha_Server
{
    /// <summary>
    /// Player position
    /// </summary>
    public struct PlayerPosition
    {
        public float X;
        public float Y;
        public float Z;
    }

    /// <summary>
    /// Information about an individual player.
    /// </summary>
    public class TDLPlayer
    {
        /// <summary>
        /// ID given by the Server application for the user.
        /// </summary>
        public String UserID { get; set; }

        /// <summary>
        /// Player name given by the Server application for the user.
        /// </summary>
        public String PlayerName { get; set; }

        /// <summary>
        /// NUmber of death for the player.
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        /// Number of zombies the player has killed.
        /// </summary>
        public int ZombieKills { get; set; }

        /// <summary>
        /// PLayers current position.
        /// </summary>
        public PlayerPosition Position { get; set; }
    }
}
