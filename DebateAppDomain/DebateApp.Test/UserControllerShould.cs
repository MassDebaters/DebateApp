using DebateApp.Domain;
using DebateAppDomainAPI.Controllers;
using DebateAppDomainAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DebateAppDomain.Test
{
    public class UserControllerShould
    {
        private readonly ITestOutputHelper _output;
        private DBHelper dbh;
        private UserController UCUT;
        private UserModel umut;
        private FormDataModels.CreateCasualModel ccm;
        private DebatesController dbcut;
        public UserControllerShould(ITestOutputHelper Output)
        {
            _output = Output;
            dbh = new DBHelper();
            UCUT = new UserController();
            dbcut = new DebatesController();
            ccm = new FormDataModels.CreateCasualModel()
            {
                UserID = 2,
                Category = "Grown Up Problems",
                Opener = "Not yet...",
                Topic = "Are we any good at this?"
            };
            umut = new UserModel()
            {
                Username = "Biggo",
                Password = "Titties"
            };
        }

        [Fact]
        public void CreateAUser()
        {
            dbh.DBDeleteUser(dbh.DBGetUser("Biggo").AccountId);
            var actual = UCUT.RegisterUser(umut);
            UserModel umut2 = new UserModel()
            {
                Username = "Greg",
                Password = "foo"
            };
            
            var check = UCUT.GetUser(actual.AccountId).Username;
            Assert.IsType<UserModel>(actual);
            Assert.Equal("Biggo", check);
            dbh.DBDeleteUser(dbh.DBGetUser("Biggo").AccountId);

            var actual2 = UCUT.RegisterUser(umut2);
            Assert.Null(actual2);
        }
        [Fact]
        public void JoinATeam()
        {
            UCUT.RegisterUser(umut);
            var id = dbcut.CreateCasual(ccm).d.Debate_ID;
            
            var simulatedJoinTeam = new FormDataModels.JoinDebateModel()
            {
                username = "Biggo",
                DebateID = id,
                Opener = "NO! NOOOOOOO"
            };
            
            UCUT.JoinTeam(simulatedJoinTeam);

            var actual = dbh.DBGetDebate(id).d.Teams[1];
            Assert.NotEmpty(actual.Members);
            Assert.Equal("Biggo", actual.Members[0].Username);
            Assert.Equal("NO! NOOOOOOO", actual.Opener.CommentText);
            dbh.DBDeleteDebate(id);
            _output.WriteLine(JsonConvert.SerializeObject(actual));
        }
        [Fact]
        public void CastAVote()
        {
            var dmut = dbcut.CreateCasual(ccm);
            var id = dmut.d.Debate_ID;
            var biggo = UCUT.RegisterUser(umut);
            dmut = UCUT.JoinAudience(new FormDataModels.UserDebateModel(id, "SteveHarvey2"));
            var simulatedJoinTeam = new FormDataModels.JoinDebateModel()
            {
                username = "Biggo",
                DebateID = id,
                Opener = "NO! NOOOOOOO"
            };
            dmut = UCUT.JoinTeam(simulatedJoinTeam);
            dmut = dbcut.StartDebate(dmut.d.Debate_ID);
            dmut = UCUT.Vote(new FormDataModels.VoteModel(20, id, true));

            Assert.True(dmut.d.ActiveRound().VotesR == 1);
        }
    }
}
