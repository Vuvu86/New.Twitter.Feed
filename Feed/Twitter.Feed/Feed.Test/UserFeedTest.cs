using Feed.BusinessLogic;
using Feed.Repository;
using System;
using Xunit;

namespace Feed.Test
{
    public class UserFeedTest
    {
        [Fact]
        public void TestGetUsersAndTheirFollowers()
        {
            try
            {
                IUserRepository userRepository = new UserRepository();
                IUserBL userBL = new UserBL(userRepository);

                var result = new UserBL(userRepository).GetUsersAndTheirFollowers();
                Assert.NotEmpty(result);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        [Fact]
        public void TestUserTweets()
        {
            try
            {
                IUserRepository userRepository = new UserRepository();
                IUserBL userBL = new UserBL(userRepository);

                var result = new UserBL(userRepository).GetUserTweets();
                Assert.NotEmpty(result);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
