using System.Net;

namespace Bristlecone.ServiceLayer.Common
{
    public class ResponseDTO
    {
        public int? Id;
        public HttpStatusCode StatusCode;
        public string Message;
        public object ReturnObject;
    }
}
