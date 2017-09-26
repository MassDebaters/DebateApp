using DebateApp.Domain;
using DebateApp.db;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DebateApp.Test
{
    public class DBHelperShould
    {
        private readonly ITestOutputHelper _output;
        public DBHelperShould(ITestOutputHelper Output)
        {
            _output = Output;
        }
        [Fact]
        public void AddADebateToTheFileSystem()
        {
            var dut = new Casual(4);
            var dut2 = new Casual(5);
            var dbh = new Casual(6);
            
            dbh.AddDebate(dut);
            _output.WriteLine(dbh.message);
            dbh.AddDebate(dut2);
            
        }
    }
}
