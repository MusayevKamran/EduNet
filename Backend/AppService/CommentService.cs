using AppEntity;
using AppEntity.Models;
using AppEntity.Models.Interface;

namespace AppService
{
    public class CommentService : GenericService<Comment>, IComment
    {
        public CommentService(EntityContext context) : base(context)
        { }

        public EntityContext context
        {
            get { return _context as EntityContext; }
        }
    }
}
