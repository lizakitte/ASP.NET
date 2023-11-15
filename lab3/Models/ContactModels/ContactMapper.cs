using Data.Entities;

namespace lab3_App.Models.ContactModels
{
    public class ContactMapper
    {
        public static Contact FromEntity(ContactEntity entity)
        {
            return new Contact()
            {
                Id = entity.ContactId,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Birth = entity.Birth,
                OrganizationId = entity.OrganizationId,
            };
        }

        public static ContactEntity ToEntity(Contact model)
        {
            return new ContactEntity()
            {
                ContactId = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Birth = model.Birth,
                OrganizationId = model.OrganizationId,
            };
        }
    }
}
