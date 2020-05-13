using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Commands;
using Microsoft.EntityFrameworkCore;

namespace Datos.Comandos
{

    public class GenericRepository : IGenericsRepositoty
    {
        private readonly ContextApplication _context;

        public GenericRepository(ContextApplication dbcontex)
        {
            _context = dbcontex;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

        }

        public IEnumerable<T> GetALL<T>() where T : class
        {
            DbSet<T> table = null;
            table = _context.Set<T>();
            return table.ToList();

        }

        public T GetBy<T>(int id) where T : class
        {
            DbSet<T> table = _context.Set<T>();
            return table.Find(id);
        }

        public T GetByCodigo<T>(string codigo) where T : class
        {
            DbSet<T> table = _context.Set<T>();
            var tablelist = table.Find(codigo);
            return tablelist;

        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
