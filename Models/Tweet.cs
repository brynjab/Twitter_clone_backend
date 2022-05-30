using System.ComponentModel.DataAnnotations;

namespace Twitter_clone_backend.Models
{
    public class Tweet
    {
        public Tweet()
        {
            Replies = new List<Tweet>();
            PostedTime = DateTime.Now;
            IsLiked = false;
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(280)]
        public string Text { get; set; }
        public string? Image { get; set; }
        public int Likes { get; set; }
        public bool? IsLiked { get; set; }
        public int Retweets { get; set; }
        [Required]
        public DateTime PostedTime { get; set; }

        public List<Tweet> Replies { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
