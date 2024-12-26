using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.DAL.Repositories.Interface
{
    public interface IRepository<Tentity> where Tentity : BaseEntity, new()
    {
     public DbSet<Tentity> Table { get;  }
     public Task<Tentity> GetById(int id);
     public IQueryable<Tentity> FindAll(Expression<Func<Tentity, bool>> expression);
     public IQueryable<Tentity> GetAll();
        public Task<Tentity> Create(Tentity entity);
        public void Update(Tentity entity);
        public void Delete(Tentity entity);
        public Task<int> Savechanges ();
        public  Task<bool> IsExsist (Expression<Func<Tentity, bool>> predicate);
    }
}
