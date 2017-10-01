using DebateApp.Domain;
using DebateAppDomainAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DebateAppDomain.Test
{
    public class DebateModelShould
    {
        private readonly ITestOutputHelper _output;
        private DebateModel dmut;
        private Debate dut;
        private User uut;
        private DBHelper dbh;
        public DebateModelShould(ITestOutputHelper Output)
        {
            _output = Output;
            uut = new TestUser();
            dut = new Casual(uut,"Are we any good at this?", "Grown Up Problems", "Not yet...");
            dmut = new DebateModel(dut);
            dbh = new DBHelper();
        }
        [Fact]
        public void SendOutASerializedCasualDebate()
        {
            _output.WriteLine(dbh.DBCreateDebate(dmut));
        }
    }
}
