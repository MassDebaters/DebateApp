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
        private FormDataModels.CreateCasualModel ccm;
        public DebatesControllerShould(ITestOutputHelper Output)
        {
            _output = Output;
            dbh = new DBHelper();
            dbcut = new DebatesController();
            ccm = new FormDataModels.CreateCasualModel()
            {
                UserID = 2,
                Category = "Grown Up Problems",
                Opener = "Not yet...",
                Topic = "Are we any good at this?"
            };
        }

        [Fact]
        public void CreateACasualDebate()
        {
            
            var actual = dbcut.CreateCasual(ccm);
            _output.WriteLine(actual.d.Debate_ID.ToString());
            Assert.IsType<DebateModel>(actual);            
            Assert.True(actual.d.DebateCategory == "Grown Up Problems");
            Assert.Equal(2, actual.d.Teams[0].Members[0].UserID);
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
            Assert.IsType<List<DebateModel>>(actual);
            
        }

        [Fact]
        public void DeleteADebate()
        {
            var id = dbcut.CreateCasual(ccm).d.Debate_ID;
            dbh.DBDeleteDebate(1);
        }



    }
}
