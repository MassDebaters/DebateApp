using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebateApp.db
{
    public class DBHelper
    {
        protected DebateAppDBContext dbHelper;
        private readonly IConfiguration _Configuration;

        public DBHelper(IConfiguration configuration)
        {
            _Configuration = configuration;
            dbHelper = new DebateAppDBContext(_Configuration);
        }

        public void AddAccount(string username, string password)
        {
            dbHelper.Accounts.Add(new Accounts() { Username = username, Password = password });
            dbHelper.SaveChanges();
        }

        public void AddPost(int accId, int time)
        {
            dbHelper.Posts.Add(new Posts() { AccountId = accId, TimeStamp = time });
        }

        public void DeleteAccount(int id)
        {
            var account = dbHelper.Accounts.Find(id);

            if(account != null)
            {
                dbHelper.Accounts.Remove(account);
                dbHelper.SaveChanges();
            }
        }

        public void DeletePost(int id)
        {
            var post = dbHelper.Posts.Find(id);

            if (post != null)
            {
                dbHelper.Posts.Remove(post);
            }
        }

        public bool UniqueUsername(string username)
        {
            var userName = dbHelper.Accounts.Where(un => un.Username == username);

            if(userName.Count() == 0 && username.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Accounts> GetAllAccounts()
        {
            return dbHelper.Accounts.ToList();
        }
        
        public Accounts GetAccount(int id)
        {
            return dbHelper.Accounts.Find(id);
        }
    }
}
