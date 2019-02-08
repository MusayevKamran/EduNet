﻿using AppEntity.Models.Enum;
using System;
using System.Collections.Generic;

namespace AppEntity.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public int Row { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public List<ArticleImages> Images { get; set; }

        public string Like { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public List<ArticleCategory> ArticleCategory { get; set; } 

        public PostCategory PostCategory { get; set; }

        public ICollection<Comment> Comment { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
