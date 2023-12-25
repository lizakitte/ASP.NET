using Data.Entities;
using lab3_App.Models.ContactModels;

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
        public PagingList<Car> FindPage(int page, int size);
    }
}
