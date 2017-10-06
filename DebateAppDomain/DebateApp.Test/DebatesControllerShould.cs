using DebateApp.Domain;
using DebateAppDomainAPI.Models;
using DebateAppDomainAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DebateAppDomain.Test
{
    public class DebatesControllerShould
    {
        private readonly ITestOutputHelper _output;
        private DBHelper dbh;
        private DebatesController dbcut;
        public DebatesControllerShould(ITestOutputHelper Output)
        {
            _output = Output;
            dbh = new DBHelper();
            dbcut = new DebatesController();
        }

        [Fact]
        public void CreateACasualDebate()
        {
            var ccm = new CreateCasualModel()
            {
                UserID = 2,
                Category = "Grown Up Problems",
                Opener = "Not yet...",
                Topic = "Are we any good at this?"
            };
            var actual = dbcut.CreateCasual(ccm);
            _output.WriteLine(actual.d.Debate_ID.ToString());
            Assert.IsType<DebateModel>(actual);            
            Assert.True(actual.d.DebateCategory == "Grown Up Problems");
            Assert.Equal(actual.d.Teams[0].Members[0].UserID, 2);
            Assert.Equal(actual.d.DebateTopic, "Are we any good at this?");
        }
        [Fact]
        public void ViewAllDebates()
        {
            var actual = dbcut.GetAllDebate();
            foreach(DebateModel d in actual)
            {
                _output.WriteLine(d.d.Debate_ID.ToString());
            }
            
            
        }



    }
}
