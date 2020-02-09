using Cine.Dominio._4._1_Entidades;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Interfaces.Repositorio
{
    public interface IRepository<T> where T : EntityBase
    {


        Task Create(T entidad);

        Task Update(T entidad);

        Task Delete(T entidad);


        Task<T> GetById(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> inlcude = null, bool enableTracking = true);

        Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> predicate = null,
              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
              Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
              bool enableTracking = true);

        Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>
        include = null, bool entrableTracking = true);









    }
}
