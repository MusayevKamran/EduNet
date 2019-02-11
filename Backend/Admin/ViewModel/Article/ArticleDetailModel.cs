using AppEntity;
using AppEntity.Models;
using AppEntity.Models.Enum;
using AppEntity.Models.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAdmin.Models
{
    public class ArticleDetailModel
    {
        private readonly IUnitService _unitService;

        public ArticleDetailModel() { }

        public ArticleDetailModel(IUnitService unitService)
        {
            _unitService = unitService;
        }


        public int Id { get; set; }

        public string Title { get; set; }

        public int Row { get; set; }

        public string Content { get; set; }

        public Task<List<Category>> Category { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public PostCategory PostCategory { get; set; }
    }
}
