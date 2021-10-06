using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Tools;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class UserService : ApiRequester, IUserService
    {
        public UserService(IConfiguration config) : base(config.GetSection("BaseAddress").Value)
        {

        }

        public User Login(string email, string password)
        {
            string json = JsonConvert.SerializeObject(new { email = email, password = password });
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage message = Client.PostAsync("user/login", content).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    Console.WriteLine(message.StatusCode);
                }

                string jsonResponse = message.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<User>(jsonResponse);
            }
        }

        public void Register(string email, string password)
        {
            string json = JsonConvert.SerializeObject(new { email = email, password = password });
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage message = Client.PostAsync("user/login", content).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    Console.WriteLine(message.StatusCode);
                }
            }
        }
    }
}
