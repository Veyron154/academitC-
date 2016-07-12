
using System.Runtime.Serialization;

namespace PhoneBook
{
    [DataContract]
    public class ContactDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "surname")]
        public string Surname { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "countOfContacts")]
        public int CountOfContacts { get; set; }
    }
}