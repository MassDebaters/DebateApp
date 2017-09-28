using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public abstract class Post
    {
        private static int idcounter = 0;//change this to pull from a persistent id counter later
        public int PostID { get; set; }
        public string CommentText { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserID { get; set; }
        public int MaxLength { get; set; }

        public Post()
        {
            PostID = idcounter;
            idcounter += 1;
        }
        public virtual bool Validate()
        {
            return CommentText.Length <= MaxLength;
        }
    }
}
