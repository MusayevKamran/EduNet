using System;


namespace AppContract
{
    public interface IUnitService : IDisposable
    {
        IArticleDAL Article { get; }
        ICategoryDAL Category { get; }
        IArticleCategoryDAL ArticleCategory { get; }
        ICommentDAL Comment { get; }
        IUserDAL User { get; }

        int SaveChanges();
    }
}
