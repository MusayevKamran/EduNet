using AppContract;
using AppEntity;
using AppEntity.Models;

namespace AppService
{
    public class CommentDAL : Repository<Comment>, ICommentDAL
    {
        public CommentDAL(EntityContext context) : base(context)
        { }

        public EntityContext context
        {
            get { return _context as EntityContext; }
        }
    }
}
