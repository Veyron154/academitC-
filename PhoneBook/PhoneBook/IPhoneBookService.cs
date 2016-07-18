
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using PhoneBook.Dto;

namespace PhoneBook
{
    [ServiceContract]
    public interface IPhoneBookService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, 
                   RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponseDto AddContact (ContactDto contact);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        TableDataDto GetContacts(RequestDataDto requestData);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
                   RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponseDto RemoveContacts(int[] ids);
        
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
                   RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, 
                    UriTemplate = "/Excel?filter={filter}&sortCommand={sortCommand}&isSortedDesc={isSortedDesc}")]
        Stream GetExcel(string filter, SortCommand sortCommand, bool isSortedDesc);
    }
}
