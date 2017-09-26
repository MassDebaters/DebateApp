using DebateApp.Domain;
using DebateApp.db;
using System;
using Xunit;

namespace DebateApp.Test
{
    public class DBHelperShould
    {
        [Fact]
        public void AddADebateToTheFileSystem()
        {
            var dut = new Casual(4);
            var dut2 = new Casual(5);
            var dbh = new DBHelper();
            dbh.AddDebate2(dut);
            
        }
    }
}
