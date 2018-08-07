using Common.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed.Repository
{
   public class UserRepository:IUserRepository
    {
        public List<string> GetUsers(Dictionary<string, List<string>> userDictionary)
        {
            var user = "";
            var follower = "";
            List<string> userList = new List<string>();

            foreach (var userKey in userDictionary)
            {
                user = userKey.Key;
                if (!userList.Contains(user.Trim()) && !String.IsNullOrWhiteSpace(user))
                {
                    userList.Add(user.Trim());
                }
                foreach (var userValue in userKey.Value)
                {
                    follower = userValue.Trim();
                    if (!userList.Contains(follower.Trim()) && !String.IsNullOrWhiteSpace(follower))
                    {
                        userList.Add(follower.Trim());
                    }
                }
            }
            //order the list of users by ascending order
            return userList.OrderBy(x => x).ToList();
        }
        public Dictionary<string, List<string>> GetUsersAndTheirFollowers()
        {
            try
            {
                var user = "";
                var follower = "";
                var delimeterString = "follows";
                var delimeter = ',';

                List<string> userList = new List<string>();
                Dictionary<string, List<string>> user_follower = new Dictionary<string, List<string>>();
                string fileName = "user.txt";
                string[] lines = FileUtility.ReadFile(fileName);

                foreach (var line in lines)
                {
                    //split the lines with the "follows" string
                    string[] userFollowerList = line.Split(new[] { delimeterString }, StringSplitOptions.None);

                    follower = userFollowerList[0].Trim();
                    user = userFollowerList[1].Trim();

                    string[] users = user.Split(delimeter);

                    if (users.Length > 1)
                    {
                        foreach (var item in users)
                        {
                            List<string> followers = new List<string>();
                            followers.Add(follower);
                            if (!user_follower.ContainsKey(item.Trim()))
                            {
                                user_follower.Add(item.Trim(), followers);
                            }
                            //check if the key exists and value doesn't,trim any trailing spaces
                            if (user_follower.ContainsKey(item.Trim()))
                            {
                                foreach (var userFollower in user_follower)
                                {
                                    if (!userFollower.Value.Contains(follower))
                                    {
                                        user_follower[item.Trim()].Add(follower);
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        List<string> followerList = new List<string>();
                        followerList.Add(follower);
                        if (!user_follower.ContainsKey(user))
                        {

                            user_follower.Add(user, followerList);

                        }
                        // if key already exist but the value doesnt update the dictionary with new value
                        if (user_follower.ContainsKey(user) && !user_follower.ContainsValue(followerList))
                        {
                            user_follower[user].Add(follower);

                        }

                    }
                }
                return user_follower;
            }
            catch (Exception)
            {

                throw;
            }
         
        }
        public  void AddFollowerToUser(string follower, string selectedUser)
        {
            try
            {
                var fileName = "user.txt";
                var delimeterString = "follows";
                var delimeter = ',';

                var usersAndFollowers = GetUsersAndTheirFollowers();
                foreach (var item in usersAndFollowers)
                {
                    var user = item.Key;
                    var followers = item.Value;
                  

                    if(user == selectedUser)
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine(follower +" "+ delimeterString+" " + user);

                        FileUtility.UpdateFile(fileName, sb.ToString());
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RemoveFollowerFromUser(string selectedFollower, string selectedUser)
        {
            try
            {
                var fileName = "user.txt";
                var delimeterString = "follows";
                var usersAndFollowers = GetUsersAndTheirFollowers();
                foreach (var item in usersAndFollowers)
                {
                    var user = item.Key;
                    var followers = item.Value;
                    foreach (var f in followers)
                    {
                        if(f==selectedFollower)
                        {
                            followers.Remove(selectedFollower);
                            var sb = new StringBuilder();
                            sb.AppendLine(f + " " + delimeterString + " " + user);
                            FileUtility.UpdateFile(fileName, sb.ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Dictionary<string, List<string>> GetUserTweets()
        {
            try
            {
                Dictionary<string, List<string>> user_tweets = new Dictionary<string, List<string>>();
                var delimeter = '>';
                string fileName = "tweet.txt";
                string[] lines = FileUtility.ReadFile(fileName);

                foreach (var line in lines)
                {
                    string[] tweetList = line.Split(delimeter);

                    List<string> userTweetList = new List<string>();
                    if (!user_tweets.ContainsKey(tweetList[0]))
                    {
                        userTweetList.Add(tweetList[1]);
                        user_tweets.Add(tweetList[0], userTweetList);
                    }
                    if (user_tweets.ContainsKey(tweetList[0]) && !user_tweets.ContainsValue(userTweetList))
                    {
                        user_tweets[tweetList[0]].Add(tweetList[1]);
                    }
                }
                return user_tweets;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
