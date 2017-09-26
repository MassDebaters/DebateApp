using System.Linq;

namespace DebateApp.db 
{
  public class UserHelper : DBHelper 
  {

    public Accounts Account(string name, string password)
    {
      Accounts account = dbHelper.Accounts.SingleOrDefault(un => un.Username == name && un.Password == password);
      if (account == null)
      {
        return null;
      }

      return account;
    }
  }
}