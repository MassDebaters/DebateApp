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
        public double ShareL = 0.5;
        public double ShareR = 0.5;
        public int CurrentTurn = 0;
        public bool Active = false;
        public RoundState(RoundState PreviousRound)
        {
            ShareL = PreviousRound.ShareL;
            ShareR = PreviousRound.ShareR;
            CurrentTurn = PreviousRound.CurrentTurn + 1;
            Active = true;
        }
        public RoundState() { }

        internal void CalculateSwings()
        {
            try
            {
                var totalVotes = VotesL + VotesR;
                var SwingL = VotesL / totalVotes;
                ShareL = ShareL + (ShareL * (SwingL * ShareL));
                ShareR = 1 - ShareL;
            }
            catch (Exception)
            {
                var SwingL = 0;
                ShareL = ShareL + (SwingL * ShareL);
                ShareR = 1 - ShareL;
            }

        }

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
