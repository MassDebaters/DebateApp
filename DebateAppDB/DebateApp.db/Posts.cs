using System;
using System.Collections.Generic;

namespace DebateApp.db
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public int TimeStamp { get; set; }

        public Accounts Account { get; set; }
    }
}
