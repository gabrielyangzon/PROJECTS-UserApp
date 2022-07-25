using BlazorApp2.Models;
using System.Net.Http.Json;
using System.Text;
//using Newtonsoft.Json;
using System.Text.Json;

namespace BlazorApp2.HttpRepository
{
    public class UserHttpRepository : IUserHttpRepository
    {

        public HttpClient _client;
       
        private readonly JsonSerializerOptions _options;

        public UserHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var response = await _client.GetAsync("User/GetAllUsers");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
     

            var userList = JsonSerializer.Deserialize<List<UserModel>>(content, _options);

            return userList;
        }

        public async Task<UserModel> GetUserById(string userId)
        {

            var response = await _client.GetAsync("User/GetUserById?id="+userId);

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }


            var user = JsonSerializer.Deserialize<UserModel>(content, _options);

            return user;

        }


        public async Task<bool> EditUser(UserModel user)
        {

            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            
            try 
            {

                var response = await _client.PutAsJsonAsync("User/EditUser", user);

                //var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
            }catch(Exception ex)
            {

            }
            return true;
        }

        public async Task<bool> AddUser(UserModel user)
        {
            try
            {

                var response = await _client.PostAsJsonAsync("User/AddUser", user);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
            }
            catch (Exception ex)
            { }
            return true;
        }


        public async Task<bool> DeleteUser(string id)
        {

            //HttpContent httpContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            //try
            //{

            //    var response = await _client.PutAsync("User/EditUser", httpContent);

            //    var content = await response.Content.ReadAsStringAsync();

            //    if (!response.IsSuccessStatusCode)
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            return true;
        }
    }
}
