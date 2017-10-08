using DebateApp.Domain;

using System;
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
    }
}
