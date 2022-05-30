using Microsoft.EntityFrameworkCore;
using Twitter_clone_backend.Data.Interfaces;
using Twitter_clone_backend.Models;
using Twitter_clone_backend.Models.DTO;

namespace Twitter_clone_backend.Data.Repository
{
    public class TwitterRepository : IRepository
    {
        private readonly TwitterDBContext _dbContext;

        public TwitterRepository()
        {
            _dbContext = new TwitterDBContext();
        }


        public async Task CreateTweetAsync(Tweet tweet)
        {
            using(var db = _dbContext)
            {
                await db.Tweets.AddAsync(tweet);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateReplyAsync(int TweetId, Tweet Reply)
        {
            using (var db = _dbContext)
            {
                Tweet tweetToReply = await db.Tweets.FirstOrDefaultAsync(x => x.Id == TweetId);
                tweetToReply.Replies.Add(Reply);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateUserAsync(User user)
        {
            using(var db = _dbContext)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteTweetAsync(int id)
        {
            Tweet tweetToDelete;

            using(var db = _dbContext)
            {
                tweetToDelete = db.Tweets.FirstOrDefault(x => x.Id == id);
                if (tweetToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Tweets.Remove(tweetToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            User userToDelete;

            using(var db = _dbContext)
            {
                userToDelete = db.Users.FirstOrDefault(x => x.Id == id);

                if(userToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Users.Remove(userToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }


        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            List<User> users;

            using(var db = _dbContext)
            {
                users = await db.Users.ToListAsync();
            }

            List<UserDTO> listToReturn = new List<UserDTO>();

            foreach(User u in users)
            {
                UserDTO userToAdd = new UserDTO();

                userToAdd.Id = u.Id;
                userToAdd.UserName = u.UserName;
                userToAdd.TwitterHandle = u.TwitterHandle;
                userToAdd.ProfilePhotoURL = u.ProfilePhotoURL;
                userToAdd.Location = u.Location;
                userToAdd.Birthday = u.Birthday;
                userToAdd.Following = u.Following;
                userToAdd.Followers = u.Followers;
                userToAdd.Tweets = u.Tweets;

                listToReturn.Add(userToAdd);
            }
            return listToReturn;
        }

        public async Task<List<TweetDTO>> GetAllTweetsAsync()
        {
            List<Tweet> tweets;

            using (var db = _dbContext)
            {
                tweets = await db.Tweets.Include(u => u.User).ToListAsync();
            }

            List<TweetDTO> listToReturn = new List<TweetDTO>();

            foreach (Tweet t in tweets)
            {
                TweetDTO tweetToAdd = new TweetDTO();
                tweetToAdd.Id = t.Id;
                tweetToAdd.User = t.User;
                tweetToAdd.Text = t.Text;
                tweetToAdd.Image = t.Image;
                tweetToAdd.Retweets = t.Retweets;
                tweetToAdd.Replies = t.Replies;
                tweetToAdd.Likes = t.Likes;
                tweetToAdd.PostedTime = t.PostedTime;

                listToReturn.Add(tweetToAdd);
            }
            return listToReturn;
        }
        public async Task<TweetDTO> GetTweetByIdAsync(int id)
        {
            Tweet t;

            using(var db = _dbContext)
            {
                t = await db.Tweets.Include(r => r.Replies).Include(u => u.User).FirstOrDefaultAsync(x => x.Id == id);
            }

            TweetDTO tweetToReturn = new TweetDTO();

            tweetToReturn.Id = t.Id;
            tweetToReturn.User = t.User;
            tweetToReturn.Text = t.Text;
            tweetToReturn.Image = t.Image;
            tweetToReturn.Likes = t.Likes;
            tweetToReturn.Retweets = t.Retweets;
            tweetToReturn.PostedTime = t.PostedTime;
            tweetToReturn.Replies = t.Replies;

            return tweetToReturn;
        }

        public async Task<UserDTO> GetUserByHandleAsync(string handle)
        {
            User u;

            using(var db = _dbContext)
            {
                u = await db.Users.Include(t => t.Tweets).FirstOrDefaultAsync(x => x.TwitterHandle == handle);
            }
            UserDTO userToReturn = new UserDTO();
            userToReturn.Id = u.Id;
            userToReturn.UserName = u.UserName;
            userToReturn.TwitterHandle = u.TwitterHandle;
            userToReturn.ProfilePhotoURL = u.ProfilePhotoURL;
            userToReturn.Location = u.Location;
            userToReturn.Birthday = u.Birthday;
            userToReturn.Following = u.Following;
            userToReturn.Followers = u.Followers;
            userToReturn.Tweets = u.Tweets;

            return userToReturn;
        }

        public async Task<Tweet> UpdateTweetAsync(int id, Tweet tweet)
        {
            using(var db = _dbContext)
            {
                Tweet tweetToUpdate = await db.Tweets.FirstOrDefaultAsync(x => x.Id == id);  
                if(tweetToUpdate == null)
                {
                    return null;
                }
                //tweetToUpdate.Text = tweet.Text;
                //tweetToUpdate.Image = tweet.Image;
                tweetToUpdate.Likes = tweet.Likes;
                //tweetToUpdate.Retweets = tweet.Retweets;
                //tweetToUpdate.PostedTime = tweet.PostedTime;

                await db.SaveChangesAsync();
                return tweetToUpdate;
            }
            
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            using(var db = _dbContext)
            {
                User userToUpdate = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
                if(userToUpdate == null)
                {
                    return null;
                }
                userToUpdate.UserName = user.UserName;
                userToUpdate.TwitterHandle = user.TwitterHandle;
                userToUpdate.ProfilePhotoURL = user.ProfilePhotoURL;
                userToUpdate.Location = user.Location;
                userToUpdate.Birthday = user.Birthday;
                userToUpdate.Following = user.Following;
                userToUpdate.Followers = user.Followers;

                await db.SaveChangesAsync();
                return userToUpdate;
            }
        }
    }
}
