using Common.Helper.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Display.Service
{
   public class Program
    {
        public static void Main(string[] args)
        {
             RunAll();
            Console.ReadLine();
        }
        public async static void RunAll()
        {
            try
            {
                
                var userFollowerApiHelper = new UserFollowerApiHelper();
                var tweetsDictionary = await userFollowerApiHelper.GetUserTweets();
                var userDictionary = await userFollowerApiHelper.GetUsersAndTheirFollowers();
                var userList = await userFollowerApiHelper.GetUsers();
                DiplayOutput(tweetsDictionary, userDictionary, userList);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
        public static void DiplayOutput(Dictionary<string, List<string>> tweetsDictionary, Dictionary<string, List<string>> userDictionary, List<string> userList)
        {
            var usersValue = "";
            var usersKey = "";
            var tweetMessage = "";
            foreach (var user in userList)
            {
                Console.WriteLine(user);
                Console.WriteLine();

                foreach (var tweet in tweetsDictionary)
                {
                    foreach (var tweetItem in tweet.Value)
                    {
                        tweetMessage = tweetItem;
                        foreach (var userKey in userDictionary)
                        {
                            usersKey = userKey.Key;
                            foreach (var userValue in userKey.Value)
                            {
                                usersValue = userValue;
                            }
                        }
                        if ((user == tweet.Key || user == usersKey || user == usersValue) && (user == tweet.Key || user == usersValue))
                        {
                            //if  tweet message is bigger than 140, use 140 else use the full length.
                            var tweets = tweetMessage.Substring(0, tweetMessage.Length > 140 ? 140 : tweetMessage.Length);
                            Console.WriteLine("\t@" + tweet.Key + ":" + " " + tweets);

                        }
                    }

                }

            }
            Console.ReadLine();
        }
    }
}
