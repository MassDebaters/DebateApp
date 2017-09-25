using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class Notification
    {
        public int FromUser { get; set; }
        public int DebateID { get; set; }
        public string Text { get; set; }
    }
}
