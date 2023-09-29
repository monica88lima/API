﻿using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalogo.Infrastructure.Repositories
{
    public class Repository<T>: IRepository<T> where T : class
    {
        protected AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
             _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Get()
        { 
              return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}