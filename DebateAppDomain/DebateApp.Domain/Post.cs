using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public abstract class Post
    {
        public int PostID { get; set; }
        public string CommentText { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserID { get; set; }
        public int MaxLength { get; set; }

    }
}
