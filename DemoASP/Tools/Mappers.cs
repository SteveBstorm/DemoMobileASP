using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL = DataAccessLayer.Entities;
using ASP = DemoASP.Models;

namespace DemoASP.Tools
{
    public static class Mappers
    {
        public static ASP.User ToASP(this DAL.User user)
        {
            return new ASP.User
            {
                Id = user.Id,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Token = user.Token
            };
        }
    }
}
