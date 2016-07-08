
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ClosedXML.Excel;
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

        public List<ContactDto> GetContacts(string filter)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                return database.Contact.Select(c => new ContactDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    Phone = c.Phone
                }).Where(c => c.Surname.Contains(filter) || c.Name.Contains(filter) || c.Phone.Contains(filter)).ToList();
            }
        }

        public void RemoveContacts(int[] ids)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                database.Contact.RemoveRange(database.Contact.Where(c => ids.Contains(c.Id)));
                database.SaveChanges();
            }
        }

        public Stream GetExcel(string filter)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                var table = database.Contact.Select(c => new ContactDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    Phone = c.Phone
                }).Where(c => c.Surname.Contains(filter) || c.Name.Contains(filter) || c.Phone.Contains(filter)).ToList();
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Контакты");
                    worksheet.Cell("A1").InsertTable(table);
                    
                    var memoryStream = new MemoryStream();
                    workbook.SaveAs(memoryStream);

                    HttpContext.Current.Response.Headers["Content-Disposition"] = "attachment; filename=contacts.xlsx";
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    memoryStream.Position = 0;
                return memoryStream;
                }
            }
        }
    }
}
