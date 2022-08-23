using System.Collections.Generic;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentRepository _commentRepository = CommentRepository.GetRepository();

        public IEnumerable<Comment> GetAllComments()
        {
            return _commentRepository.GetAll();
        }

        public Comment CreateComment(Comment comment)
        {
            return _commentRepository.Add(comment);
        }

        public bool Upvote(int id)
        {
            return _commentRepository.Upvote(id);
        }

        public bool Downvote(int id)
        {
            return _commentRepository.Downvote(id);
        }
    }
}
