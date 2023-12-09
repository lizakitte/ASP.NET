using Data.Entities;
using lab3_App.Models.ContactModels;

namespace lab3_App.Models.CarModels
{
    public class CarMapper
    {
        public static Car FromEntity(CarEntity entity)
        {
            return new Car()
            {
                Id = entity.Id,
                Model = entity.Model,
                Manufacturer = entity.Manufacturer,
                Capacity = entity.Capacity,
                Power = entity.Power,
                EngineType = (Engine)entity.EngineType,
                RegistratioinNumber = entity.RegistratioinNumber,
                Owner = entity.Owner,
            };
        }

        public static CarEntity ToEntity(Car model)
        {
            return new CarEntity()
            {
                Id = model.Id,
                Model = model.Model,
                Manufacturer = model.Manufacturer,
                Capacity = model.Capacity,
                Power = model.Power,
                EngineType = (Data.Entities.Engine)model.EngineType,
                RegistratioinNumber = model.RegistratioinNumber,
                Owner = model.Owner,
            };
        }
    }
}
