using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feed.Repository
{
  public interface IUserRepository
    {
        List<string> GetUsers(Dictionary<string, List<string>> userFollower);
        Dictionary<string, List<string>> GetUsersAndTheirFollowers();
        Dictionary<string, List<string>> GetUserTweets();
        void AddFollowerToUser(string follower, string user);
        void RemoveFollowerFromUser(string follower, string user);
    }
}
