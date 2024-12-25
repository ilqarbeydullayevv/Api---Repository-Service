using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Business.Helpers.Exceptions.Common
{
    public class NullIdException : Exception
    {
        public NullIdException() : base("Id 0 ve ya menfi olanmaz") {}
       

        public NullIdException(string? message) : base(message)
        {
        }
    }
}
