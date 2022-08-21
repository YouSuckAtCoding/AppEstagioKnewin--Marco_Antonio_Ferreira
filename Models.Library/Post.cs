using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Library
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }

    }
}
