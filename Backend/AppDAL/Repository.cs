﻿using AppContract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppService
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create(T model)
        {
            _context.Set<T>().Add(model);
        }

        public void DeleteConfirmed(T model)
        {
            _context.Set<T>().Remove(model);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int? Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public async Task<T> GetByIdAsync(int? Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public void Update(T model)
        {
            _context.Update(model);
        }
    }
}
