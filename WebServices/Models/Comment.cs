namespace WebServices.Models
{
    public class Comment {

        public int Id { get; set; }

        public string Text { get; set; }
        public string Author { get; set; }

        public int UpvotesNumber { get; set; }    
        public int DownvotesNumber { get; set; }    
    }
}