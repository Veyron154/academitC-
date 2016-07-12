
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PhoneBook
{
    [DataContract]
    public class TableDataDto
    {
        [DataMember(Name = "contactsList")]
        public List<ContactDto> ContactsList { get; set; }

        [DataMember(Name = "countOfContacts")]
        public int CountOfContacts { get; set; }
    }
}