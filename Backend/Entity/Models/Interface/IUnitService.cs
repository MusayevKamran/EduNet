using System;


namespace EntityData.Models.Interface
{
    public interface IUnitService : IDisposable
    {
        IArticle Article { get; }
        ICategory Category { get; }
        IArticleCategory ArticleCategory { get; }
        IComment Comment { get; }
        IUser User { get; }

        int SaveChanges();
    }
}
