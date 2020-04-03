using System;
using System.Collections.Generic;
using System.Text;

namespace PBP.BusinessLogic
{
    class ValidationException : Exception
    {
        public int Code { get; set; }
        public ValidationException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
