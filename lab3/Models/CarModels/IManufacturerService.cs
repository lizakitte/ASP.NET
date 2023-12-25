using Data.Entities;
using lab3_App.Models.ContactModels;

namespace lab3_App.Models.CarModels
{
    public interface IManufacturerService
    {
        int Add(Manufacturer manufacturer);
        Manufacturer? FindById(int id);
        List<Manufacturer> FindAll();
        void DeleteById(int id);
        void Update(Manufacturer manufacturer);
    }
}
