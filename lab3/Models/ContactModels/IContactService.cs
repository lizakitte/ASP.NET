
using Data.Entities;
using Data.Migrations;

namespace lab3_App.Models.ContactModels
{
    public interface IContactService
    {
        int Add(Contact contact);
        Contact? FindById(int id);
        List<Contact> FindAll();
        void DeleteById(int id);
        void Update(Contact contact);
        List<OrganizationEntity> FindAllOrganizations();
    }
}
