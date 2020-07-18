using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisTweet.Contracts.V1.Responses
{
    public class GenericResponse
    {
        public string Message { get; set; } = "Ok";
        public int StatusCode { get; set; } = 200;
        public object Data { get; set; }
    }
}
