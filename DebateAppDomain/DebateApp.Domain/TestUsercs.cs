using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class TestUser : User
    {
        public TestUser() : base()
        {
            UserID = 0;
            Username = "DarwinsBeard";
            Password = "Fogey";
            Astros = 100;
            YourDebates = new List<int>();

        }
    }
}
