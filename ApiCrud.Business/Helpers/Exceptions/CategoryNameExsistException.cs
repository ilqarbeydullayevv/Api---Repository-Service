using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Business.Helpers.Exceptions
{
    public class CategoryNameExsistException : Exception
    {
        public CategoryNameExsistException(): base("bele bir adda category movcuddur") { }
       

        public CategoryNameExsistException(string? message) : base(message)
        {
        }
    }
}
