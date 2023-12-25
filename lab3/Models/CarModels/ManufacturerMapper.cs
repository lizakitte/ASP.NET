using Data.Entities;
using Data.Migrations;

namespace lab3_App.Models.CarModels
{
    public class ManufacturerMapper
    {
        public static Manufacturer FromEntity(ManufacturerEntity entity)
        {
            return new Manufacturer()
            {
                ManufacturerId = entity.ManufacturerId,
                Name = entity.Name,
                Address = entity.Address,
            };
        }

        public static ManufacturerEntity ToEntity(Manufacturer model)
        {
            return new ManufacturerEntity()
            {
                ManufacturerId = model.ManufacturerId,
                Name = model.Name,
                Address = model.Address,
            };
        }
    }
}
