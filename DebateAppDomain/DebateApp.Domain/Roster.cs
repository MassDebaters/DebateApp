using System.Collections.Generic;

namespace DebateApp.Domain
{
    public class Roster
    {

        public DebatePost TeamLOpener { get; set; }
        public DebatePost TeamROpener { get; set; }
        public int TeamCount { get; set; }
        public List<User> TeamLMembers { get; set; }
        public List<User> TeamRMembers { get; set; }
        public bool SetupComplete { get; set; }
        public void ReadyToStart() 
            {
                    SetupComplete = (TeamLOpener != null && TeamROpener != null) &&
                                    (TeamLMembers.Count + TeamRMembers.Count == TeamCount * 2);
            }
        }

    }
}