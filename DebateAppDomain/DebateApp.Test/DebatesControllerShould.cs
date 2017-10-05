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
        private DebateModel dmut;
        private Debate dut;
        private User uut;
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
                        
            Assert.True(actual.d.DebateCategory == "Grown Up Problems");
        }
    }
}
