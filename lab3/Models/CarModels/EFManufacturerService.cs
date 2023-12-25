using Data;
using Data.Entities;
using lab3_App.Models.ContactModels;

namespace lab3_App.Models.CarModels
{
    public class EFManufacturerService : IManufacturerService
    {
        private AppDbContext _context;
        public EFManufacturerService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Manufacturer manufacturer)
        {
            var e = _context.Manufacturers.Add(ManufacturerMapper.ToEntity(manufacturer));
            _context.SaveChanges();
            return e.Entity.ManufacturerId;
        }

        public void DeleteById(int id)
        {
            ManufacturerEntity? find = _context.Manufacturers.Find(id);
            if (find != null)
            {
                _context.Manufacturers.Remove(find);
            }
        }

        public List<Manufacturer> FindAll()
        {
            return _context.Manufacturers.Select(e => ManufacturerMapper.FromEntity(e)).ToList();
        }

        public Manufacturer? FindById(int id)
        {
            return ManufacturerMapper.FromEntity(_context.Manufacturers.Find(id));
        }

        public void Update(Manufacturer manufacturer)
        {
            _context.Manufacturers.Update(ManufacturerMapper.ToEntity(manufacturer));
        }
    }
}
