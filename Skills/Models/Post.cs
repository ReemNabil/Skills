using System;
using System.Collections.Generic;
using System.Text;

namespace Skills.Models
{
    public class Post
    {

        private int userId;
        private int id;
        private string title;
        private string body;

        public int UserId { get => userId; set => userId = value; }
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Body { get => body; set => body = value; }
    }
}
