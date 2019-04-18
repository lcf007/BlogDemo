using BlogDemo.Core.Entites;
using System;

namespace BlogDemo.Core
{
    public class Post:Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime LastModified { get; set; }
    }
}
