using System.Collections.Generic;

namespace DebateApp.Domain
{
    public class Team
    {

        public DebatePost Opener { get; set; }
        public int TeamCount { get; set; }
        public List<User> Members { get; set; }
        public bool ReadyToStart
        {
            get
            {
                return (Opener != null) &&
                       (Members.Count == TeamCount);
            }
        }

    }
}