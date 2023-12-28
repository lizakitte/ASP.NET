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
                _context.SaveChanges();
            }
        }

        public List<Manufacturer> FindAll()
        {
            return _context.Manufacturers.Select(e => ManufacturerMapper.FromEntity(e)).ToList();
        }

        public Manufacturer? FindById(int id)
        {
            var find = _context.Manufacturers.Find(id);
            return find is null ? null : ManufacturerMapper.FromEntity(find);
        }

        public void Update(Manufacturer manufacturer)
        {
            var entity = ManufacturerMapper.ToEntity(manufacturer);
            _context.ChangeTracker.Clear();
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
