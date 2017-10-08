using System;
using System.Collections.Generic;

namespace DebateApp.Domain
{
    public class Team
    {

        public DebatePost Opener { get; set; }
        public int TeamLimit { get; set; }
        public List<User> Members = new List<User>();
        public int RoundsWon = 0;
        public double WinningsShare = 0.5;
        public Team(int Max)
        {
            TeamLimit = Max;
        }
        public bool ReadyToStart
        {
            get
            {
                return (Opener != null) &&
                       (Members.Count == TeamLimit);
            }
        }

        internal bool IsNotFull()
        {
            return Members.Count < TeamLimit;
        }
    }
}