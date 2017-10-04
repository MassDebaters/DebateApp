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
        private Debate dut;
        private User uut;
        private DBHelper dbh;
        public DbHelperShould(ITestOutputHelper Output)
        {
            _output = Output;
            uut = new TestUser();
            dut = new Casual(uut, "Are we any good at this?", "Grown Up Problems", "Not yet...");
            dmut = new DebateModel(dut);
            dbh = new DBHelper();
        }

        [Fact]
        public void BeAbleToRetrieveAUserModelByID()
        {
            var tst = dbh.DBGetUser(2);
            Assert.True(tst.Username == "Greg");
        }
    }
}
