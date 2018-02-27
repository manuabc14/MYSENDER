using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYSENDER.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public int Modifications { get; set; }
        public int Id { get; set; }

        public static Response NotFound = new Response
        {
            Success = false,
            Code = 0,
            Modifications = 0,
            Id = 0
        };
    }
}
