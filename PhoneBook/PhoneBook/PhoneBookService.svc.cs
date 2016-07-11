
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

        public List<ContactDto> GetContacts(string filter, int sizeOfPage, int numberOfPage)
        {
            return GetFullList(filter).OrderBy(c => c.Id)
                    .Skip((numberOfPage - 1) * sizeOfPage)
                    .Take(sizeOfPage)
                    .ToList();
        }

        public void RemoveContacts(int[] ids)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                database.Contact.RemoveRange(database.Contact.Where(c => ids.Contains(c.Id)));
                database.SaveChanges();
            }
        }

        public int GetCountOfContacts(string filter)
        {
            return GetFullList(filter).Count;
        }

        public Stream GetExcel(string filter)
        {
            var table = GetFullList(filter);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Контакты");
                worksheet.Cell("A1").Value = "Фамилия";
                worksheet.Cell("B1").Value = "Имя";
                worksheet.Cell("C1").Value = "Телефон";

                var i = 2;
                foreach (var contact in table)
                {
                    worksheet.Cell("A" + i).Value = contact.Surname;
                    worksheet.Cell("B" + i).Value = contact.Name;
                    worksheet.Cell("C" + i).Value = contact.Phone;
                    ++i;
                }

                var range = worksheet.Range("A1", "C" + (i - 1));
                range.FirstCell().Style
                    .Font.SetBold()
                    .Fill.SetBackgroundColor(XLColor.CornflowerBlue)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                range.CreateTable();

                var memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);

                HttpContext.Current.Response.Headers["Content-Disposition"] = "attachment; filename=contacts.xlsx";
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                memoryStream.Position = 0;
                return memoryStream;
            }
        }

        private List<ContactDto> GetFullList(string filter)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                return database.Contact
                    .Select(c => new ContactDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Surname = c.Surname,
                        Phone = c.Phone
                    }).Where(c => c.Surname.Contains(filter) || c.Name.Contains(filter) || c.Phone.Contains(filter))
                    .ToList();
            }
        }
    }
}
