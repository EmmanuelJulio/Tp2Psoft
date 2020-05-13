using Dominio.Commands;
using Dominio.Entities;
using Dominio.Queries;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services
{
    public interface IEntidadService<T>
    {
      
        Entidad Agregar(T entidad);
        void Eliminar(int id);
        void Actualizar(T entidad);
        int Contar(Expression<Func<T, bool>> where);
        Entidad ObtenerPorId(int id);
        List<Entidad> OptenerTodos();
        //    IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery);
    }
   public class EntidadService : IEntidadService<Entidad> 
    {
        private readonly IRepositorio<Entidad> repositorio;
        private  DbContext db;

        public EntidadService(DbContext db, IRepositorio<Entidad> repositorio)
        {
            this.repositorio = repositorio;
            this.db = db;
        }

        public Func<Entidad, object> OrderBy { get; set; }
        public bool IsAscending { get; set; }
        //public List<Entidad> OptenerTodos()
        //{
        //       // return repositorio.

        //}
        public void Repositorio(DbContext dbContext)
        {
            db = dbContext;
        }
        public void Actualizar(Entidad entidad)
        {

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Entidad Agregar(Entidad entidad)
        {
            entidad.FechaIncercion = DateTime.Today;
            db.Entry(entidad).State = EntityState.Added;
            db.SaveChanges();
            return entidad;
        }

        public int Contar(Expression<Func<Entidad, bool>> where)
        {
            return db.Set<Entidad>().Where(where).Count();
        }

        public void Eliminar(int id)
        {
            var entidad = new Entidad() { Id = id };
            db.Entry(entidad).State = EntityState.Deleted;
            db.SaveChanges();
        }

        //public IEnumerable<Entidad> EncontrarPor(ParametrosDeQuery<Entidad> parametrosDeQuery)
        //{
        //    var orderByClass = ObtenerOrderBy(parametrosDeQuery);
        //    Expression<Func<Entidad, bool>> whereTrue = x => true;
        //    var where = (parametrosDeQuery.Where == null) ? whereTrue : parametrosDeQuery.Where;

        //    if (orderByClass.IsAscending)
        //    {
        //        return db.Set<T>().Where(where).OrderBy(orderByClass.OrderBy)
        //        .Skip((parametrosDeQuery.Pagina - 1) * parametrosDeQuery.Top)
        //        .Take(parametrosDeQuery.Top).ToList();
        //    }
        //    else
        //    {
        //        return db.Set<T>().Where(where).OrderByDescending(orderByClass.OrderBy)
        //        .Skip((parametrosDeQuery.Pagina - 1) * parametrosDeQuery.Top)
        //        .Take(parametrosDeQuery.Top).ToList();
        //    }

        //}

        public Entidad ObtenerPorId(int id)
        {
            return db.Set<Entidad>().FirstOrDefault(x => x.Id == id);

        }

        public List<Entidad> TraerIncertadosHoy()
        {

            return db.Set<Entidad>().Where(x => x.FechaIncercion == DateTime.Today).ToList();

        }

        public List<Entidad> OptenerTodos()
        {
            return db.Set<Entidad>().ToList();
        }

        //private OrderByClass ObtenerOrderBy(ParametrosDeQuery<Entidad> parametrosDeQuery)
        //{
        //    //if (parametrosDeQuery.OrderBy == null && parametrosDeQuery.OrderByDescending == null)
        //    //{
        //    //    return new OrderByClass(x => x.Id, true);
        //    //}

        //    //return (parametrosDeQuery.OrderBy != null)
        //    //    ? new OrderByClass(parametrosDeQuery.OrderBy, true) :
        //    //    new OrderByClass(parametrosDeQuery.OrderByDescending, false);
        //}
        //private class OrderByClass
        //{

        //    public OrderByClass()
        //    {

        //    }

        //    public OrderByClass(Func<T, object> orderBy, bool isAscending)
        //    {
        //        OrderBy = orderBy;
        //        IsAscending = isAscending;
        //    }


        //    public Func<T, object> OrderBy { get; set; }
        //    public bool IsAscending { get; set; }
        //}
        //public class ParametrosDeQuery<T>
        //{
        //    public ParametrosDeQuery()
        //    {
        //        Where = null;
        //        OrderBy = null;
        //        OrderByDescending = null;
        //    }

        //    public ParametrosDeQuery(int pagina, int top)
        //    {
        //        Pagina = pagina;
        //        Top = top;
        //        Where = null;
        //        OrderBy = null;
        //        OrderByDescending = null;
        //    }
        //    public int Pagina { get; set; }
        //    public int Top { get; set; }
        //    public Expression<Func<T, bool>> Where { get; set; }
        //    public Func<T, object> OrderBy { get; set; }
        //    public Func<T, object> OrderByDescending { get; set; }
        //}

    }
}

