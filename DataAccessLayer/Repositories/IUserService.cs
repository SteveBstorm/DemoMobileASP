using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface IUserService
    {
        User Login(string email, string password);
        void Register(string email, string password);
    }
}