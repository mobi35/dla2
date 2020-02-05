

using DLA_Thesis.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
 
        public class Repository<T> : IRepository<T> where T : class
        {
            protected readonly DLADBContext _context;

            public Repository(DLADBContext context)
            {
                _context = context;
            }

            protected  void Save() =>  _context.SaveChanges();
            public int Count(Func<T, bool> predicate)
            {
                return _context.Set<T>().Where(predicate).Count();
            }

            public  void Create(T entity)
            {
                _context.Add(entity);
                Save();
            }

            public  void Delete(T entity)
            {
                _context.Remove(entity);
                Save();
            }

            public IEnumerable<T> Find(Func<T, bool> predicate)
            {
                return _context.Set<T>();
            }

            public IEnumerable<T> GetAll()
            {
                return _context.Set<T>();
            }

            public T GetIdBy(int id)
            {
                return _context.Set<T>().Find(id);
            }

            public  void Update(T entity)
            {
                _context.Entry(entity).State = EntityState.Modified;
                Save();
            }


        }
  
}
