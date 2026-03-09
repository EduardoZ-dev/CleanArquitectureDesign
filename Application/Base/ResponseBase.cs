using Newtonsoft.Json;
using System.Net;

namespace Application.Base
{
    public sealed class ResponseBase<T>
    {
        public ResponseBase()
        {
            Message = "¡Operación exitosa!";
            StatusCode = HttpStatusCode.OK;
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public T? Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
