using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Domain.Presistence
{
    public interface IRepository<T>
    {
        void Create(T entity);
        IEnumerable<T> Get(ISpecification<T> spec = null);
        void Update(T entity);
        void Remove(T entity);
    }
}
