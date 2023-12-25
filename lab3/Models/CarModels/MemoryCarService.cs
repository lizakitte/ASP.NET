using lab3_App.Models.ContactModels;

namespace lab3_App.Models.CarModels
{
    public class MemoryCarService : ICarService
    {
        private Dictionary<int, Car> _cars = new Dictionary<int, Car>()
        {
            {1, new Car(){Id = 1, Model = "A6 3.0 tdi quattro", ManufacturerId = 1003,
                Capacity = 3000, Power = 225, EngineType = Engine.Diesel,
                RegistratioinNumber = 7777, ContactId = 1}}
        };
        private int id = 2;

        public int Add(Car car)
        {
            car.Id = id++;
            _cars[car.Id] = car;
            return car.Id;
        }

        public void DeleteById(int id)
        {
            _cars.Remove(id);
        }

        public List<Car> FindAll()
        {
            return _cars.Values.ToList();
        }

        public List<Data.Entities.ManufacturerEntity> FindAllManufacturers()
        {
            throw new NotImplementedException();
        }

        public List<Data.Entities.ContactEntity> FindAllOwnerContacts()
        {
            throw new NotImplementedException();
        }

        public Car? FindById(int id)
        {
            return _cars[id];
        }

        public PagingList<Car> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            if (_cars.ContainsKey(car.Id))
            {
                _cars[car.Id] = car;
            }
        }
    }
}
