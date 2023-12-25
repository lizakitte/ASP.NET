using Data;
using Data.Entities;
using lab3_App.Models.ContactModels;

namespace lab3_App.Models.CarModels
{
    public class EFCarService : ICarService
    {
        private AppDbContext _context;
        public EFCarService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Car car)
        {
            var e = _context.Cars.Add(CarMapper.ToEntity(car));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void DeleteById(int id)
        {
            CarEntity? find = _context.Cars.Find(id);
            if (find != null)
            {
                _context.Cars.Remove(find);
            }
        }

        public List<Car> FindAll()
        {
            return _context.Cars.Select(e => CarMapper.FromEntity(e)).ToList();
        }

        public List<ManufacturerEntity> FindAllManufacturers()
        {
            return _context.Manufacturers.ToList();
        }

        public List<ContactEntity> FindAllOwnerContacts()
        {
            return _context.Contacts.ToList();
        }

        public Car? FindById(int id)
        {
            return CarMapper.FromEntity(_context.Cars.Find(id));
        }

        public PagingList<Car> FindPage(int page, int size)
        {
            return PagingList<Car>.Create(
            (p, s) => _context.Cars
            .OrderBy(c => c.Model)
            .Skip((p - 1) * s)
            .Take(s)
            .Select(CarMapper.FromEntity)
            .ToList(),
            page,
            size,
            _context.Cars.Count()
            );
        }

        public void Update(Car car)
        {
            _context.Cars.Update(CarMapper.ToEntity(car));
        }
    }
}
