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
        public int CurrentTurn = 0;
        public bool Active = false;
        public RoundState(RoundState PreviousRound)
        {
            SwingL = PreviousRound.SwingL;
            SwingR = PreviousRound.SwingR;
            CurrentTurn = PreviousRound.CurrentTurn + 1;
            Active = true;
        }
        public RoundState() { }

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


    }
}
