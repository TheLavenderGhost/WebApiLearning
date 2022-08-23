using System.Collections.Generic;

namespace WebServices.Models {

    public interface ICommentRepository {

        IEnumerable<Comment> GetAll();

        Comment Add(Comment comment);

        bool Upvote(int id);

        bool Downvote(int id);
    }
}
