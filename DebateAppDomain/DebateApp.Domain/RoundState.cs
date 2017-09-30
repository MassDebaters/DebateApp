using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class RoundState
    {

        public List<DebatePost> Responses = new List<DebatePost>();
        public int VotesL = 0;
        public int VotesR = 0;
        public double SwingL = 0.5;
        public double SwingR = 0.5;
        public int CurrentTurn = 1;
        public bool Active = true;


        internal void Vote(bool team)
        {
            if(team)
            {
                VotesL += 1;
            }
            if(!team)
            {
                VotesR += 1;
            }
        }

        internal void RoundEnd(Debate d)
        {
            
        }
    }
}
