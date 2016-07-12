﻿
using System.Runtime.Serialization;

namespace PhoneBook
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