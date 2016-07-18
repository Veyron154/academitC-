
using System.Runtime.Serialization;

namespace Dto
{
    [DataContract]
    public class BaseResponseDto
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}