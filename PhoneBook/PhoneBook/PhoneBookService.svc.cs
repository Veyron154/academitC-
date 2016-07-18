
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ClosedXML.Excel;
using PhoneBook.DataAccess;
using PhoneBook.Dto;


namespace PhoneBook
{
    public class PhoneBookService : IPhoneBookService
    {
        public BaseResponseDto AddContact(ContactDto contact)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                var isNotUniquePhone = database.Contact.Any(c => c.Phone == contact.Phone);

                if (isNotUniquePhone)
                {
                    return new BaseResponseDto
                    {
                        Success = false,
                        Message = $"Контакт с номером {contact.Phone} уже существует"
                    };
                }

                if (string.IsNullOrEmpty(contact.Phone) || string.IsNullOrEmpty(contact.Name) || 
                    string.IsNullOrEmpty(contact.Surname))
                {
                    return new BaseResponseDto
                    {
                        Success = false,
                        Message = "Не все поля заполнены"
                    };
                }

                database.Contact.Add(new Contact
                {
                    Name = contact.Name,
                    Surname = contact.Surname,
                    Phone = contact.Phone
                });

                database.SaveChanges();

                return new BaseResponseDto
                {
                    Success = true,
                    Message = ""
                };
            }
        }

        public TableDataDto GetContacts(RequestDataDto requestData)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                var fullData = GetFullData(requestData.Filter, database.Contact, requestData.SortCommand, requestData.IsSortedDesc);

                return new TableDataDto
                {
                    ContactsList = fullData
                        .Skip((requestData.NumberOfPage - 1) * requestData.SizeOfPage)
                        .Take(requestData.SizeOfPage)
                        .ToList(),
                    CountOfContacts = fullData.Count()
                };
            }
        }

        public BaseResponseDto RemoveContacts(int[] ids)
        {
            using (var database = new PhoneBookDatabaseEntities())
            {
                database.Contact.RemoveRange(database.Contact.Where(c => ids.Contains(c.Id)));
                database.SaveChanges();

                return new BaseResponseDto
                {
                    Success = true,
                    Message = ""
                };
            }
        }
        
        public Stream GetExcel(string filter, SortCommand sortCommand, bool isSortedDesc)
        {
            List<ContactDto> table;

            using (var database = new PhoneBookDatabaseEntities())
            {
                table = GetFullData(filter, database.Contact, sortCommand, isSortedDesc).ToList();
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Контакты");

                worksheet.ColumnWidth = 20;
                   
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

                var rngNumbers = range.Range("C2", "C" + (i - 1));
                rngNumbers.Style.NumberFormat.Format = "@";

                var rngHeader = range.Range("A1", "C1");
                rngHeader.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                range.FirstCell()
                    .Style
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

        private static IQueryable<ContactDto> GetFullData(string filter, IQueryable<Contact> contact, SortCommand sortCommand, 
            bool isSortedDesc)
        {
            var data =  contact.Select(c => new ContactDto
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname,
                Phone = c.Phone
            }).Where(c => c.Surname.Contains(filter) || c.Name.Contains(filter) || c.Phone.Contains(filter));

            if (!isSortedDesc)
            {
                if (sortCommand == SortCommand.Name)
                {
                    return data.OrderBy(c => c.Name);
                }
                if (sortCommand == SortCommand.Surname)
                {
                    return data.OrderBy(c => c.Surname);
                }
                return data.OrderBy(c => c.Phone);
            }
            if (sortCommand == SortCommand.Name)
            {
                return data.OrderByDescending(c => c.Name);
            }
            if (sortCommand == SortCommand.Surname)
            {
                return data.OrderByDescending(c => c.Surname);
            }
            return data.OrderByDescending(c => c.Phone);
        }
    }
}
