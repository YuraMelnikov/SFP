using Newtonsoft.Json;

namespace Entities.Models
{
    public class ErrorDetails
    {
        int statusCode;
        string message;

        public int StatusCode { get => statusCode; set => statusCode = value; }
        public string Message { get => message; set => message = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
