using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper.Api
{
    public class UserFollowerApiHelper:ApiHelper
    {
        public UserFollowerApiHelper() : base("http://localhost:6004/api/UserFollower") { }
        public UserFollowerApiHelper(HttpClient client): base (client, "http://localhost:6004/api/UserFollower") { }
        public async Task<bool> Ping()
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync("Ping");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return content == "Pong" ? true : false;

                return false;
            }
            catch (Exception ex) { return false; }
        }
        public async Task<List<string>>GetUsers()
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync("UserFollower/Users");
                var task =  response.Content.ReadAsStringAsync();
                task.Wait();

                var result = task.Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<string>>(result);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Dictionary<string,List<string>>> GetUsersAndTheirFollowers()
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync("UserFollower/Users_And_Their_Followers");
                var task = response.Content.ReadAsStringAsync();
                task.Wait();

                var result = task.Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(result);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async void AddFollowerToUser( string follower, string user,Dictionary<string,List<string>>userFollower)
        {
            try
            {
                Client.DefaultRequestHeaders.Add("follower", follower);
                Client.DefaultRequestHeaders.Add("user", user);
                HttpResponseMessage response = await Client.PutAsync("UserFollower/Add_Follower_To_User",
                    GetByteArrayContent(userFollower));
                var task = response.Content.ReadAsStringAsync();
                task.Wait();

                var result = task.Result;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async void RemoveFollowerFromUser(string follower, string user, Dictionary<string, List<string>> userFollower)
        {
            try
            {
                Client.DefaultRequestHeaders.Add("follower", follower);
                Client.DefaultRequestHeaders.Add("user", user);
                HttpResponseMessage response = await Client.PutAsync("UserFollower/Remove_Follower_From_User",
                    GetByteArrayContent(userFollower));
                var task = response.Content.ReadAsStringAsync();
                task.Wait();

                var result = task.Result;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Dictionary<string,List<string>>> GetUserTweets()
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync("UserFollower/User_Tweets");
                var task = response.Content.ReadAsStringAsync();
                task.Wait();

                var result = task.Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(result);
                return null;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
