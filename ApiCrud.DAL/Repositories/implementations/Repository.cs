using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Core.Entities.Common;
using ApiCrud.DAL.Context;
using ApiCrud.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.DAL.Repositories.implementations
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : BaseEntity, new()
    {
        readonly AppdbContext _context;

        public Repository(AppdbContext context)
        {
            _context = context;
        }
        public DbSet<Tentity> Table() => _context.Set<Tentity>();

        public IQueryable<Tentity> GetAll()
        {
            return Table();
        }

        public IQueryable<Tentity> FindAll(Expression<Func<Tentity , bool>> expression)
        {
       return Table().Where(expression);    
        }

        public async Task<Tentity> GetById(int id)
        {
          return await Table().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tentity> Create(Tentity entity)
        {
            await Table().AddAsync(entity);
            return entity;
        }

        public void Update(Tentity entity)
        {
         Table().Update(entity);
        }

        public void Delete(Tentity entity)
        {
            Table().Remove(entity);
        }

        public async Task<int> Savechanges()
        {
        return await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExsist(Expression<Func<Tentity, bool>> predicate)
        {
            return await Table().AnyAsync(predicate);
        }
    }
}

