using System.Collections.Generic;
using System.Linq;

namespace WebServices.Models
{
    public class CommentRepository : ICommentRepository {
        private List<Comment> _data = new List<Comment> {
            new Comment {Id = 1,  Text = "Testowy komentarz", Author = "Admin", UpvotesNumber = 0, DownvotesNumber = 1},
            new Comment {Id = 2,  Text = "Jest super!", Author = "Anonimowy Gość", UpvotesNumber = 5, DownvotesNumber = 0},
            new Comment {Id = 3,  Text = "Podbijam świat...", Author = "Adventure", UpvotesNumber = 2, DownvotesNumber = 2},
        };

        private static ICommentRepository _repo = new CommentRepository();

        public static ICommentRepository GetRepository() {
            return _repo;
        }

        public IEnumerable<Comment> GetAll() {
            return _data;
        }

        public Comment Add(Comment comment) {
            comment.Id = _data.Count + 1;
            _data.Add(comment);
            return comment;
        }

        public bool Upvote(int id) => Vote(id, true);

        public bool Downvote(int id) => Vote(id, false);

        private bool Vote(int id, bool isUpvote)
        {
            var comment = Get(id);
            if (comment == null)
            {
                return false;
            }

            if (isUpvote)
            {
                comment.UpvotesNumber += 1;
            }
            else
            {
                comment.DownvotesNumber += 1;
            }
            return true;
        }
        private Comment Get(int id) {
            return _data.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}