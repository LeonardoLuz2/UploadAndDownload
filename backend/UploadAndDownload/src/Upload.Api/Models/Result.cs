using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload.Api.Models
{
    public class Result
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public static Result Response(int statusCode, string message)
        {
            return new Result
            {
                StatusCode = statusCode,
                Message = message
            };
        }
    }
}
