using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Core.Entities;
using ApiCrud.DAL.Context;
using ApiCrud.DAL.Repositories.Interface;

namespace ApiCrud.DAL.Repositories.implementations
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public CategoryRepository(AppdbContext _context) : base(_context) { }
       
    }
}
