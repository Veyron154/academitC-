
using System.Runtime.Serialization;

namespace PhoneBook.Dto
{
    [DataContract]
    public class RequestDataDto
    {
        [DataMember(Name = "filter")]
        public string Filter { get; set; }

        [DataMember(Name = "sizeOfPage")]
        public int SizeOfPage { get; set; }

        [DataMember(Name = "numberOfPage")]
        public int NumberOfPage { get; set; }

        [DataMember(Name = "sortCommand")]
        public SortCommand SortCommand { get; set; }

        [DataMember(Name = "isSortedDesc")]
        public bool IsSortedDesc { get; set; }
    }
}