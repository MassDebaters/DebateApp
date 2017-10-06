using DebateApp.Domain;
using DebateAppDomainAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DebateAppDomain.Test
{
    public class DbHelperShould
    {
        private readonly ITestOutputHelper _output;
        private DebateModel dmut;
        private User uut;
        private Debate dut;
        private DBHelper dbh;
        public DbHelperShould(ITestOutputHelper Output)
        {UserModel
            _output = Output;
            uut = new User(10, "Steve Harvey", 200);
            dut = new Casual(uut, "Are we any good at this?", "Grown Up Problems", "Not yet...");
            dmut = new DebateModel(dut);
            dbh = new DBHelper();
        }

        [Fact]
        public void BeAbleToRetrieveAUserModelByID()
        {
            var tst = dbh.DBGetUser(2);
            tst.Transfer();
            Assert.True(tst.Username == "Greg");
            Assert.True(tst.UserLogic.Username == "Greg");
        }
        [Fact]
        public void BeAbleToRetrieveADebateModelByID()
        {
            var tst = dbh.DBGetDebate(0);
            Assert.NotNull(tst.d);
            Assert.IsType<Debate>(tst.d);
        }
        [Fact]
        public void CreateAUser()
        {
            var actual = dbh.DBCreateUser(uut);
        }
    }
}
