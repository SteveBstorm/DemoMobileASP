using System.Collections.Generic;

namespace DemoASP.Models
{
    public interface IFakeBiereService
    {
        void Delete(int Id);
        List<Biere> GetAll();
        Biere GetById(int Id);
        void Insert(Biere b);
    }
}