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
        public double ShareL = 0;
        public double ShareR = 0;
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

        internal void CalculateSwings(int totalrounds)
        {
            try
            {
                var weight = 1 / totalrounds;
                var totalVotes = VotesL + VotesR;
                var SwingL = VotesL / totalVotes;
                var SwingR = VotesR / totalVotes;
                ShareL += weight * SwingL;
                ShareR = weight * SwingR;
            }
            catch (Exception)
            {

            }

        }

        internal void Vote(bool team)
        {
            if(team)
            {
                VotesR += 1;
               
            }
            if(!team)
            {
                VotesL += 1;
                
            }
        }


    }
}
