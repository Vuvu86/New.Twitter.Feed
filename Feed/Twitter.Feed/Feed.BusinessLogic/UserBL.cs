using System;
using Feed.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feed.BusinessLogic
{
   public class UserBL:IUserBL
    {
        private readonly IUserRepository UserRepository;

        public UserBL(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public List<string> GetUsers()
        {
            try
            {
                var userFollower = GetUsersAndTheirFollowers();
                return  UserRepository.GetUsers(userFollower);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public Dictionary<string, List<string>> GetUsersAndTheirFollowers()
        {
            try
            {
                return  UserRepository.GetUsersAndTheirFollowers();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public  void AddFollowerToUser(string follower, string user)
        {
            try
            {
                 UserRepository.AddFollowerToUser(follower, user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RemoveFollowerFromUser(string follower, string user)
        {
            try
            {
                UserRepository.RemoveFollowerFromUser(follower, user);
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
                return UserRepository.GetUserTweets();
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }
    }
}
