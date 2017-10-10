using DebateAppDB.dbRest.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace DebateAppDB.test
{
    public class AccountsTests
    {
        private readonly IConfiguration _Configuration;
        private AccountModel account;

        public AccountsTests(IConfiguration configuration)
        {

            _Configuration = configuration;
            account = new AccountModel(_Configuration);
        }

        [Fact]
        public void GetAllAccounts()
        {
            var accounts = account.GetAllAccounts();

            var user = accounts.FindAll(u => string.Equals(u.Username, "Lenny"));

            Assert.NotEmpty(accounts);
            Assert.IsType<List<AccountModel>>(accounts);
            Assert.NotNull(user);
        }

        [Fact]
        public void GetAccount()
        {
            var user = account.GetAccount(4);
            var expectedUsername = "Lenny";

            Assert.NotNull(user);
            Assert.IsType<AccountModel>(user);
            Assert.True(string.Equals(user.Username, expectedUsername));
        }

    }
}
