using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PhoneBook
{
    [ServiceContract]
    public interface IPhoneBookService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, 
                   RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddContact (ContactDto contact);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<ContactDto> GetContacts();
    }
}
