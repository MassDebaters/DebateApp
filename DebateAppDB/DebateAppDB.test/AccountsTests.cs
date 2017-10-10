using DebateAppDB.dbRest;
using DebateAppDB.dbRest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace DebateAppDB.test
{
    public class AccountsTests
    {
        private readonly IConfiguration _Configuration;
        private readonly ITestOutputHelper output;
        private AccountModel account; 
        private Startup startUp;

        public AccountsTests(ITestOutputHelper outp)
        {
            output = outp;
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _Configuration = builder.Build();

            account = new AccountModel(_Configuration);
        }

        [Fact]
        public void GetAllAccounts()
        {
            output.WriteLine("in get all");
            var accounts = account.GetAllAccounts();

            var user = accounts.FindAll(u => string.Equals(u.Username, "Lenny"));

            Assert.NotEmpty(accounts);
            Assert.IsType<List<AccountModel>>(accounts);
            Assert.NotNull(user);
        }

        [Fact]
        public void GetAccountWithId()
        {
            var user = account.GetAccount(4);
            var expectedUsername = "Lenny";

            Assert.NotNull(user);
            Assert.IsType<AccountModel>(user);
            Assert.True(string.Equals(user.Username, expectedUsername));
        }

        [Fact]
        public void GetAccountWithUsername()
        {
            var user = account.GetAccount("Lenny");
            var expectedUsername = "Lenny";
            var wrongUsername = "lenny";

            Assert.NotNull(user);
            Assert.IsType<AccountModel>(user);
            Assert.True(string.Equals(user.Username, expectedUsername));
            Assert.False(string.Equals(user.Username, wrongUsername));
        }

        [Fact]
        public void AddAccount()
        {
            

            /*Assert.NotNull(user);
            Assert.IsType<AccountModel>(user);
            Assert.True(string.Equals(user.Username, expectedUsername));
            Assert.False(string.Equals(user.Username, wrongUsername));*/
        }

    }
}
