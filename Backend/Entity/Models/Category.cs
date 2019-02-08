using System.Collections.Generic;


namespace AppEntity.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Row { get; set; }

        public int Count { get; set; }

        public bool IsNew { get; set; }

        public bool IsActive { get; set; }

        public List<ArticleCategory> ArticleCategory { get; set; } 
    }
}