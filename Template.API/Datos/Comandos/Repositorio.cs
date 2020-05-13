using Dominio.Commands;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Datos.Comandos
{

    public class Repositorio<T> : IRepositorio<T> where T : Entidad, new()
    {
        private DbContext db;

        public Repositorio(DbContext db)
        {
            this.db = db;
        
        }

        public Func<T, object> OrderBy { get; set; }
        public bool IsAscending { get; set; }

        //public Repositorio(DbContext dbContext,T) 
        //{
        //    db = dbContext;
        //}
        public T Actualizar(T entidad)
        {

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public T Agregar(T entidad)
        {
            entidad.FechaIncercion = DateTime.Today;
            db.Entry(entidad).State = EntityState.Added;
            db.SaveChanges();
            return entidad;
        }

        public int Contar(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().Where(where).Count();
        }

        public void Eliminar(int id)
        {
            var entidad = new T() { Id = id };
            db.Entry(entidad).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery)
        {
            var orderByClass = ObtenerOrderBy(parametrosDeQuery);
            Expression<Func<T, bool>> whereTrue = x => true;
            var where = (parametrosDeQuery.Where == null) ? whereTrue : parametrosDeQuery.Where;

                if (orderByClass.IsAscending)
                {
                    return db.Set<T>().Where(where).OrderBy(orderByClass.OrderBy)
                    .Skip((parametrosDeQuery.Pagina - 1) * parametrosDeQuery.Top)
                    .Take(parametrosDeQuery.Top).ToList();
                }
                else
                {
                    return db.Set<T>().Where(where).OrderByDescending(orderByClass.OrderBy)
                    .Skip((parametrosDeQuery.Pagina - 1) * parametrosDeQuery.Top)
                    .Take(parametrosDeQuery.Top).ToList();
                }

        }

        public Entidad ObtenerPorId(int id)
        {
            return db.Set<T>().FirstOrDefault(x => x.Id == id);

        }

        public List<T> TraerIncertadosHoy()
        {

            return db.Set<T>().Where(x => x.FechaIncercion == DateTime.Today).ToList();

        }
        public List<T> OptenerTodos()
        {
                return db.Set<T>().ToList();
        }
        private OrderByClass ObtenerOrderBy(ParametrosDeQuery<T> parametrosDeQuery)
        {
            if (parametrosDeQuery.OrderBy == null && parametrosDeQuery.OrderByDescending == null)
            {
                return new OrderByClass(x => x.Id, true);
            }

            return (parametrosDeQuery.OrderBy != null)
                ? new OrderByClass(parametrosDeQuery.OrderBy, true) :
                new OrderByClass(parametrosDeQuery.OrderByDescending, false);
        }
        private class OrderByClass
        {

            public OrderByClass()
            {

            }

            public OrderByClass(Func<T, object> orderBy, bool isAscending)
            {
                OrderBy = orderBy;
                IsAscending = isAscending;
            }


            public Func<T, object> OrderBy { get; set; }
            public bool IsAscending { get; set; }
        }

    }
   

}
