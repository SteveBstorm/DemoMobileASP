using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll(string token);
        void Insert(Contact c, string token);
    }
}