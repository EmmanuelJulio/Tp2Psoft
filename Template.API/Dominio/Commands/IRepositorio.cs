using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Commands
{
    public interface IRepositorio<T>
    {
        T Agregar(T entidad);
        void Eliminar(int id);
        T Actualizar(T entidad);
        int Contar(Expression<Func<T, bool>> where);
        Entidad ObtenerPorId(int id);
        IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery);
        public List<T> OptenerTodos();
    }
}
