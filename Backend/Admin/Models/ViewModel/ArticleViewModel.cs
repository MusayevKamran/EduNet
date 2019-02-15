using System.Collections.Generic;
using AppEntity.Models;

namespace AppAdmin.ViewModel
{
    public class ArticleViewModel
    {
        public List<Category> Category { get; set; }

        public Article Article { get; set; }
    }
}