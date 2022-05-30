using Twitter_clone_backend.Models;
using Twitter_clone_backend.Models.DTO;

namespace Twitter_clone_backend.Data.Interfaces
{
    public interface IRepository
    {
        Task CreateTweetAsync(Tweet tweet);
        Task<List<TweetDTO>> GetAllTweetsAsync();
        Task<TweetDTO> GetTweetByIdAsync(int id);
        Task<Tweet> UpdateTweetAsync(int id, Tweet tweet);
        Task<bool> DeleteTweetAsync(int id);

        Task CreateUserAsync(User user);
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByHandleAsync(string handle);
        Task<User> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);

        Task CreateReplyAsync(int id, Tweet reply);

    }
}
