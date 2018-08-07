using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feed.BusinessLogic
{
    public interface IUserBL
    {
        List<string> GetUsers();
        Dictionary<string, List<string>> GetUsersAndTheirFollowers();
        Dictionary<string, List<string>> GetUserTweets();
        void AddFollowerToUser(string follower, string user);
        void RemoveFollowerFromUser(string follower, string user);
    }
}
