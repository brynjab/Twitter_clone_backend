using System.ComponentModel.DataAnnotations;

namespace Twitter_clone_backend.Models
{
    public class User
    {
        public User()
        {
            Tweets = new List<Tweet>();
        }

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string TwitterHandle { get; set; }
        [Required]
        public string ProfilePhotoURL { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public int Following { get; set; }
        [Required]
        public int Followers { get; set; }
        public List<Tweet> Tweets { get; set; }
        
    }
}
