using Cine.Dominio._4._1_Entidades;
using Cine.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Infraestructura.Repositorio
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public async Task Create(T entidad)
        {
            using (var context = new Datacontext())
            {
                await context.Set<T>().AddAsync(entidad);


                await context.SaveChangesAsync();
            }
                    
        }

        public async Task Delete(T entidad)
        {
            using(var context = new Datacontext())
            {
                context.Entry(entidad).State = EntityState.Deleted;

                context.Set<T>().Remove(entidad);

                await context.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool entrableTracking = true)
        {
  
            using (var context = new Datacontext())
            {
                IQueryable<T> query = context.Set<T>();

                if(entrableTracking)
                {
                    query = query.AsNoTracking();
                }

                if(include != null)
                {
                    query = include(query);
                }


                return orderBy != null
                    ? await orderBy(query).ToListAsync()
                    : await query.ToListAsync();

            }
        }

        public async Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            bool enableTracking = true)
        {
            using (var context = new Datacontext())
            {
                IQueryable<T> query = context.Set<T>();

                if (enableTracking)
                {
                    query = query.AsNoTracking();
                }

                if (include != null)
                {
                    query = include(query);
                }
                
                if(predicate != null)
                {
                    query = query.Where(predicate);
                }

               return  orderBy != null ?
               await orderBy(query).ToListAsync() :
               await query.ToListAsync();
                

            }
        }

        public async Task<T>GetById(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enableTracking = true)
        {
            using(var context = new Datacontext())
            {
                IQueryable<T> query = context.Set<T>();

                if(enableTracking)
                {
                    query = query.AsNoTracking();
                }

                if(include != null)
                {
                    query = include(query);
                }


                return await query.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task Update(T entidad)
        {
            using(var context = new Datacontext())
            {
                context.Entry(entidad).State = EntityState.Modified;

                context.Set<T>().Update(entidad);

                await context.SaveChangesAsync();
            }
        }
    }
}
