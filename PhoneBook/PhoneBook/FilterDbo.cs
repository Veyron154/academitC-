
using System.Runtime.Serialization;

namespace PhoneBook
{
    [DataContract]
    public class FilterDbo
    {
        [DataMember(Name = "filter")]
        public string Filter { get; set; }
    }
}