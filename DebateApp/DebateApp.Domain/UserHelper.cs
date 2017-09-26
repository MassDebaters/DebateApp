using System.Linq;
using DebateApp.db;
using System;

namespace DebateApp.Domain 
{
  public class UserHelper : DBHelper 
  {

    public static User ReturnUser(string name, string password)
    {
      if(CheckPassword(name,password))
        return new User(name,password); 
      return null;
    }

    public static User CreateUser(string name, string password)
    {
      UserHelper helper = new UserHelper(); 
      bool uniqueUsername = helper.UniqueUsername(name);
      if(uniqueUsername){
        helper.AddAccount(name,password);
        Console.WriteLine("User: not null");
        return new User(name, password); // should work 
      }
      return null;
    }

    public static bool CheckPassword(string username, string password)
    {
      Accounts account = Account(username, password);
      if(account == null)
        return false; 
      return true;
    }

    /// This method returns null if no account found 
    public static Accounts Account(string name, string password)
    {
      UserHelper helper = new UserHelper();
      Accounts account = helper.dbHelper.Accounts.SingleOrDefault(un => un.Username == name && un.Password == password);
      return account;  
    }

  }
}