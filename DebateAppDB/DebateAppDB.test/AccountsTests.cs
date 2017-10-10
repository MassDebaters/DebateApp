using DebateApp.db;
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
            var newUser = new Accounts() { Username = "UnitTest", Password = "test", Role = "User", Astros = 0 };

            account.AddAccount(newUser);

            var user = account.GetAccount("UnitTest");
            var expectedUsername = "UnitTest";
            var wrongUsername = "unitTest";

            Assert.NotNull(user);
            Assert.IsType<AccountModel>(user);
            Assert.True(string.Equals(user.Username, expectedUsername));
            Assert.False(string.Equals(user.Username, wrongUsername));

            account.DeleteAccount(user.AccountId);
        }

        [Fact]
        public void DeleteAccount()
        {
            var newUser = new Accounts() { Username = "UnitTest", Password = "test", Role = "User", Astros = 0 };

            account.AddAccount(newUser);
            
            AccountModel user = account.GetAccount("UnitTest");

            account.DeleteAccount(user.AccountId);

            var user2 = account.GetAccount("UnitTest");

            var wrongUsername = "UnitTest";

            Assert.Null(user2.Username);
            Assert.IsType<AccountModel>(user2);
            Assert.False(string.Equals(user2.Username, wrongUsername));
        }

        [Fact]
        public void UniqueUsername()
        {
            var NotUniqueUsername = "Lenny";
            var UniqueUsername = "lenny";
            var valueTrue = account.UniqueUsername(UniqueUsername);
            var valueFalse = account.UniqueUsername(NotUniqueUsername);

            Assert.IsType<bool>(valueTrue);
            Assert.IsType<bool>(valueFalse);
            Assert.True(valueTrue);
            Assert.False(valueFalse);
        }

    }
}
