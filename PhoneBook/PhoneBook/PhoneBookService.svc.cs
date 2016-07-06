
using System.Collections.Generic;
using System.Linq;
using PhoneBook.DataAccess;


namespace PhoneBook
{
    public class PhoneBookService : IPhoneBookService
    {
        public void AddContact(ContactDto contact)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                database.Contact.Add(new Contact
                {
                    Name = contact.Name,
                    Surname = contact.Surname,
                    Phone = contact.Phone
                });
                database.SaveChanges();
            }
        }

        public List<ContactDto> GetContacts()
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                return database.Contact.Select(c => new ContactDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    Phone = c.Phone
                }).ToList();
            }
        }
    }
}
