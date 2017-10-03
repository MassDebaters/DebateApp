using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class DebatePost
    {
        
        
        public string CommentText { get; set; }
        public string TimeStamp { get; set; }
        public int UserID { get; set; }
        public int MaxLength { get; set; }
        public string Team { get; set; }
        
        
        public Dictionary<String, String> Sources { get; set; }
        public int DebateID { get; set; }
        public DebatePost(string s, User u)
        {
            CommentText = s;
            UserID = u.UserID;
            TimeStamp = DateTime.Now.ToString();
        }
        public virtual bool Validate()
        {
            return CommentText.Length <= MaxLength;
        }
    }
}
