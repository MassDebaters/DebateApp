using DebateApp.Domain;

using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DebateApp.Test
{
    public class DebateShould
    {
        private readonly ITestOutputHelper _output;
        private Casual dut;
        private User uut1;
        private User uut2;
        private User uut3;
        public DebateShould(ITestOutputHelper Output)
        {
            
            uut1 = new User(100, "Tiggo", 100);
            uut2 = new User(101, "Bitties", 100);
            uut3 = new User(102, "Biggo", 100);
            dut = new Casual(uut1, "Test", "Tests", "Test opening Post");
            _output = Output;
        }
        [Fact]
        public void StartTheDebate()
        {
            var dut_joined = uut2.JoinDebate(dut, new DebatePost("heeeerg", uut2.UserID), true);
            
            dut_joined.StartDebate();
            Assert.NotEmpty(dut_joined.Round);
            Assert.True(dut_joined.Round[0].Active);
            Assert.Equal(dut_joined.Round[0].CurrentTurn, 1);
            Assert.Equal(dut_joined.Pot, 10);
        }
        [Fact]
        public void GotoNextRound()
        {
            var dut_joined = uut2.JoinDebate(dut, new DebatePost("heeeerg", uut2.UserID), true);

            dut_joined.StartDebate();

            var dut_posted = uut2.Post("FUCK YOU!", dut_joined);
            dut_posted.CheckNextRound();
            Thread.Sleep(10000);
            dut_posted.CheckNextRound();
            Assert.Equal(1, dut_posted.Round.Count);
            Thread.Sleep(51000);
            dut_posted.CheckNextRound();
            Assert.Equal(2, dut_posted.Round.Count);
            Assert.Equal(dut_posted.CurrentPotShareL, 5);
            Assert.Equal(dut_posted.CurrentPotShareR, 5);
            var dut_posted2 = uut1.Post("NO FUCK YOU!", dut_posted);
            var dut_posted3 = uut2.Post("Aw shit", dut_posted2);
            var dut_audience = uut3.ViewDebate(dut_posted3);
            var dut_allvoted = uut3.Vote(dut_audience, true);

            dut_allvoted.CheckNextRound();
            Assert.Equal(dut_allvoted.Round.Count, 3);
            Assert.Equal(dut_allvoted.CurrentPotShareR, .25 * 14);
            Assert.Equal(dut_allvoted.CurrentPotShareL, .75 * 14);

        }
    }
}
