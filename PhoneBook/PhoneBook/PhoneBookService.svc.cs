using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace PhoneBook
{
    public class PhoneBookService : IPhoneBookService
    {
        public string Echo(string text)
        {
            return text;
        }

        public void AddContact()
        {
            using (
                var connection =
                    new SqlConnection(
                        @"Server=(LocalDB)\MSSQLLocalDB; Integrated Security=true; AttachDbFileName=C:\Users\Veyron\Documents\GitHubVisualStudio\academitCS\PhoneBook\PhoneBook\App_Data\PhoneBookDatabase.mdf")
                )
            {
                connection.Open();
               
                /*var context = new DbContext(connection, false);
                context.Contact.Add(new Contact
                {
                    Surname = "Ivanov",
                    Name = "Ivan",
                    Phone = "3456"
                });
                context.SaveChanges();*/
            }
        }
    }
}
