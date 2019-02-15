using AppEntity;
using AppContract;
using AppService;
using System;

namespace AppService
{
    public class UnitService : IUnitService
    {
        private readonly EntityContext _context;
        public UnitService(EntityContext context)
        {
            _context = context ?? throw new ArgumentException("db context can not be null");
        }
        private IArticleDAL _article;
        public ICategoryDAL _category;
        public IArticleCategoryDAL _articleCategory;
        public ICommentDAL _comment;
        public IUserDAL _user;

        public IArticleDAL Article
        {
            get
            {
                return _article ?? (_article = new ArticleDAL(_context));
            }
        }
        public ICategoryDAL Category
        {
            get
            {
                return _category ?? (_category = new CategoryDAL(_context));
            }
        }
        public IArticleCategoryDAL ArticleCategory
        {
            get
            {
                return _articleCategory ?? (_articleCategory = new ArticleCategoryDAL(_context));
            }
        }
        public ICommentDAL Comment
        {
            get
            {
                return _comment ?? (_comment = new CommentDAL(_context));
            }
        }
        public IUserDAL User
        {
            get
            {
                return _user ?? (_user = new UserDAL(_context));
            }
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}