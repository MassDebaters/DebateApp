using DebateApp.Domain;
using DebateApp.db;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DebateApp.Test
{
    public class DebateShould
    {
        private readonly ITestOutputHelper _output;
        public DebateShould(ITestOutputHelper Output)
        {
            _output = Output;
        }
        [Fact]
        public void AddADebateToTheFileSystem()
        {
            var dut = new Casual(4);
            var dut2 = new Casual(5);
            var dbh = new Casual(6);
            
            var addedjson = dbh.SaveDebate(dut);
            _output.WriteLine(addedjson);
            dbh.SaveDebate(dut2);
            
        }
    }
}
