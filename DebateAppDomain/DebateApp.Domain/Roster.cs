using System.Collections.Generic;

namespace DebateApp.Domain
{
    public class Roster
    {

        public DebatePost TeamLOpener { get; set; }
        public DebatePost TeamROpener { get; set; }
        public int DebateID { get; set; }
        public int TeamCount { get { return GetDebate(DebateID).NumberOfPlayersPerTeam } }
        public Dictionary<bool, List<User>> TeamLMembers { get; set; }
        public Dictionary<bool, List<User>> TeamRMembers { get; set; }

        public bool ReadyToStart { get
            {
                return (TeamLOpener != null && TeamROpener != null) &&
                        (TeamLMembers.Count + TeamRMembers.Count == TeamCount * 2);
            }
        }

    }
}