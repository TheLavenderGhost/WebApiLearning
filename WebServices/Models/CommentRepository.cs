using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages;

namespace WebServices.Models
{
    public class CommentRepository : ICommentRepository {
        private List<Comment> _data = new List<Comment> {
            new Comment {Id = 1,  Text = "Testowy komentarz", Author = "Admin", UpvotesNumber = 0, DownvotesNumber = 1},
            new Comment {Id = 2,  Text = "Jest super!", Author = "Anonimowy Gość", UpvotesNumber = 5, DownvotesNumber = 0},
            new Comment {Id = 3,  Text = "Podbijam świat niczym zdobywca najwyższych szczytów...", Author = "Adventure", UpvotesNumber = 2, DownvotesNumber = 2},
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
            if(comment.Author.IsEmpty() || comment.Text.IsEmpty())
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "Autor ani komentarz nie moga byc puste."
                };
                throw new HttpResponseException(response);
            }
            _data.Add(comment);
            return comment;
        }

        public bool Vote(VoteParams voteParams)
        {
            var comment = Get(voteParams.Id);
            if (comment == null)
            {
                return false;
            }

            if (voteParams.IsUpvote)
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