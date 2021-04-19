using Microsoft.EntityFrameworkCore;
using PersonSkillsService.Domain.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Infrastructure.Presistence.Repositories
{
    class Repository<T> : IRepository<T> where T : class
    {
        protected PersonSkillsContext Context;

        public Repository(PersonSkillsContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Get(ISpecification<T> spec = null)
        {
            if (spec == null)
                return Context.Set<T>().AsEnumerable();

            var queryableResultWithIncludes = spec.Includes
                .Aggregate(Context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return secondaryResult
                .Where(spec.Criteria)
                .ToList();
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
