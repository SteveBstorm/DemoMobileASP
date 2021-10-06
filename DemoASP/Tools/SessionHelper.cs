using DemoASP.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASP.Tools
{
    public static class SessionHelper
    {
        public static User User { get; private set; }

        public static void SetUser(this ISession session, User user)
        {
            session.SetString("User", JsonConvert.SerializeObject(user));
            User = user;
        }

        public static User GetUser(this ISession session)
        {
            return JsonConvert.DeserializeObject<User>(session.GetString("User"));
        }

        public static void Disconnect(this ISession session)
        {
            session.Clear();
            User = null;
        }
    }
}
