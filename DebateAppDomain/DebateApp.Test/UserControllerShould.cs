using DebateAppDomainAPI.Controllers;
using DebateAppDomainAPI.Models;
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
        public UserControllerShould(ITestOutputHelper Output)
        {
            _output = Output;
            dbh = new DBHelper();
            UCUT = new UserController();
        }

        [Fact]
        public void CreateACasualDebate()
        {

        }
    }
}
