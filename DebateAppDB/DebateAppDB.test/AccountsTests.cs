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

        [Fact]
        public void GetAstros()
        {
            var user = account.GetAccount(1);
            var actualAstros = account.GetAstros(user.AccountId);
            var expectedAstros = 5;

            Assert.IsType<int>(actualAstros);
            Assert.Equal(actualAstros, expectedAstros);
        }

        [Fact]
        public void AddAstros()
        {
            var newUser = new Accounts() { Username = "UnitTest", Password = "test", Role = "User", Astros = 1 };

            account.AddAccount(newUser);

            var user = account.GetAccount("UnitTest");

            account.AddAstros(user.AccountId, 5);

            var actualAstros = account.GetAstros(user.AccountId);
            var expectedAstros = 6;

            Assert.IsType<int>(actualAstros);
            Assert.True(actualAstros == expectedAstros);

            account.DeleteAccount(user.AccountId);
        }

        [Fact]
        public void CheckLogin()
        {
            var user = account.GetAccount(1);
            var actualUsername = user.Username;
            var actualPassword = "123";
            var goodLogin = account.CheckLogin(actualUsername, actualPassword);
            var badLogin = account.CheckLogin(actualUsername, "1234");

            Assert.IsType<bool>(goodLogin);
            Assert.IsType<bool>(badLogin);
            Assert.True(goodLogin);
            Assert.False(badLogin);
        }

        [Fact]
        public void UpdateUsername()
        {
            var newUser = new Accounts() { Username = "UnitTest", Password = "test", Role = "User", Astros = 1 };

            account.AddAccount(newUser);

            account.UpdateUsername(newUser.AccountId, "NewUnitTest");

            var actual = newUser.Username;
            var expected = "NewUnitTest";

            Assert.IsType<string>(actual);
            Assert.True(string.Equals(actual, expected));

            account.DeleteAccount(newUser.AccountId);
        }

        [Fact]
        public void UpdatePassword()
        {
            var newUser = new Accounts() { Username = "UnitTest", Password = "test", Role = "User", Astros = 1 };

            account.AddAccount(newUser);

            account.UpdatePassword(newUser.AccountId, "newTest");

            var actual = newUser.Password;
            var expected = "newTest";

            Assert.IsType<string>(actual);
            Assert.True(string.Equals(actual, expected));

            account.DeleteAccount(newUser.AccountId);
        }

        [Fact]
        public void UpdateRole()
        {
            var newUser = new Accounts() { Username = "UnitTest", Password = "test", Role = "User", Astros = 1 };

            account.AddAccount(newUser);

            account.UpdateRole(newUser.AccountId, "Admin");

            var actual = newUser.Role;
            var expected = "Admin";

            Assert.IsType<string>(actual);
            Assert.True(string.Equals(actual, expected));

            account.DeleteAccount(newUser.AccountId);
        }
    }
}
