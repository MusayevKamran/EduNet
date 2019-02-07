using System;

namespace EntityData.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public Article Article { get; set; }

        public AppUser AppUser { get; set; }
    }
}
