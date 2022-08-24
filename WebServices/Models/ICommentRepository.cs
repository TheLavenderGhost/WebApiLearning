using System.Collections.Generic;

namespace WebServices.Models {

    public interface ICommentRepository {

        IEnumerable<Comment> GetAll();
        Comment Add(Comment comment);
        bool Vote(VoteParams voteParams);
    }
}
