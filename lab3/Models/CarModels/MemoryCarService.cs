using lab3_App.Models.ContactModels;

namespace lab3_App.Models.CarModels
{
    public class MemoryCarService : ICarService
    {
        private Dictionary<int, Car> _cars = new Dictionary<int, Car>()
        {
            {1, new Car(){Id = 1, Model = "A6 3.0 tdi quattro", Manufacturer = "Audi",
                Capaciy = 3000, Power = 225, EngineType = Engine.Diesel,
                RegistratioinNumber = 7777, Owner = "Ja"}}
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

        public Car? FindById(int id)
        {
            return _cars[id];
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
