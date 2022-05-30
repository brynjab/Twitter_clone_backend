using Microsoft.EntityFrameworkCore;
using Twitter_clone_backend.Models;

namespace Twitter_clone_backend.Data
{
    public class TwitterDBContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Twitter");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(t => t.TwitterHandle)
                .IsUnique();
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "Formula 1", TwitterHandle = "F1", Birthday = new DateTime(1950,05,13), Following = 79, Followers = 7800000, Location = "London", ProfilePhotoURL = "https://static-s.aa-cdn.net/img/ios/835022598/0927a357a0700023fce753ab37adf24a?v=1" });
            modelBuilder.Entity<Tweet>().HasData(new Tweet { Id = 1, PostedTime = DateTime.Now, Text = "The points scorers in Barcelona", Image = "https://pbs.twimg.com/media/FTXvYNSXoAAqJ8Q.jpg:large", Likes = 12700, Retweets = 2082, UserId = 1 });
            modelBuilder.Entity<Tweet>().HasData(new Tweet { Id = 2, PostedTime = DateTime.Now, Text = "We have a NEW Championship leader!", Image = "https://pbs.twimg.com/media/FTXunk6XoAIeBwQ?format=jpg&name=small", Likes = 13200, Retweets = 2342, UserId = 1 });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, UserName = "UberFacts", TwitterHandle = "UberFacts", Birthday = new DateTime(2009-12-01), Following = 1, Followers = 13600000, Location = "Earth", ProfilePhotoURL = "https://pbs.twimg.com/profile_images/1340165521992372226/zJ0Zo4rD_400x400.jpg" });
            modelBuilder.Entity<Tweet>().HasData(new Tweet { Id = 6, PostedTime = DateTime.Now, Text = "After the 'Teletubies' show ended, the landowner removed the hill used as the set and flooded the field due to the number of fans trespassing to see Teletubbieland", Image = "https://pbs.twimg.com/media/FTiiuh4XEAEtRQr?format=jpg&name=small", Likes = 1012, Retweets = 162, UserId = 2 });
            modelBuilder.Entity<Tweet>().HasData(new Tweet { Id = 7, PostedTime = DateTime.Now, Text = "In a bar, turning up the music can cause customers to talk less, resulting in them drinking more", Likes = 1862, Retweets = 211, UserId = 2});

            //modelBuilder.Entity<User>().HasData(new User { UserName = "", TwitterHandle = "", Birthday = new DateTime(), Following = ?, Followers = ?, Location = "", ProfilePhotoURL = "" });
            //modelBuilder.Entity<Tweet>().HasData(new Tweet { PostedTime = DateTime.Now, Text = "", Image = "", Likes = ?, Retweets = ?, UserId = ? });


        }
    }

    
}
