using Data.Entities;

namespace lab3_App.Models.CarModels
{
    public interface ICarService
    {
        int Add(Car car);
        Car? FindById(int id);
        List<Car> FindAll();
        void DeleteById(int id);
        void Update(Car car);
        List<ManufacturerEntity> FindAllManufacturers();
        List<ContactEntity> FindAllOwnerContacts();
    }
}
