using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ContactService : ApiRequester, IContactService
    {
        public ContactService(IConfiguration config) : base(config.GetSection("BaseAddress").Value)
        {

        }

        public IEnumerable<Contact> GetAll(string token)
        {
            return Get<IEnumerable<Contact>>("contact", token);
        }

        public void Insert(Contact c, string token)
        {
            Post<Contact>("contact", c, token);
        }


    }
}
