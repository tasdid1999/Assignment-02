using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ClientEntity.Response
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string StatusCode { get; set; }

        public string status {  get; set; }

        public object Data { get; set; }

        public Response(bool isSuccess , string message , string statusCode , string status , object data)
        {
            this.IsSuccess = isSuccess;
            this.Message = message; 
            this.StatusCode = statusCode;
            this.status = status;
            this.Data   = data;
        }
    }
}
