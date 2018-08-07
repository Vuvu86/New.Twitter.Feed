using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feed.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Get.User.Follower.Controllers
{
    [Route("api/[controller]")]
    public class UserFollowerController : ControllerBase
    {
        private readonly IUserBL UserBL;

        public UserFollowerController(IUserBL userBL)
        {
            UserBL = userBL;
        }
        [HttpGet("Users_And_Their_Followers")]
        public async Task<IActionResult>UserFollower()
        {
            try
            {
                var userFollower =  UserBL.GetUsersAndTheirFollowers();
                if(userFollower==null)
                {
                    return NotFound("No users and followers were found.");
                }
                return Ok(userFollower);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("Add_Follower_To_User")]
        public async Task<IActionResult>AddFollowerToUser([FromHeader] string follower = null, [FromHeader] string user = null)
        {
            try
            {
                UserBL.AddFollowerToUser(follower, user);
                return Ok($"Successfully added follower:{follower} to user:{user}");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("Remove_Follower_From_User")]
        public async Task<IActionResult>RemoveFollowerFromUser([FromHeader]string follower = null,[FromHeader] string user = null)
        {
            try
            {
                UserBL.RemoveFollowerFromUser(follower, user);
                return Ok($"Successfully removed follower:{follower} from user:{user}");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("Users")]
        public async Task<IActionResult>Users()
        {
            try
            {
                var users =  UserBL.GetUsers();
                if(users== null)
                {
                    return NotFound("Users not found.");
                }
                return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("User_Tweets")]
        public async Task<IActionResult>UserTweets()
        {
            try
            {
                var userTweets =   UserBL.GetUserTweets();
                if(userTweets == null)
                {
                    return NotFound("No tweets were found.");
                }
                return Ok(userTweets);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}