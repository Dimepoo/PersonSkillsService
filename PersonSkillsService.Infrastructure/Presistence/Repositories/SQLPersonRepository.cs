using Microsoft.EntityFrameworkCore;
using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonSkillsService.Infrastructure.Presistence.Repositories
{
    public class SQLPersonRepository: IRepository<Person>
    {
        private PersonSkillsContext Context;
        private bool disposed = false;

        public SQLPersonRepository(PersonSkillsContext context)
        {
            Context = context;
        }

        public void Create(Person entity)
        {
            Context.Set<Person>().Add(entity);
        }

        public Person GetById(long id)
        {
            return Context.Set<Person>().Include(p => p.Skills).SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return Context.Set<Person>().Include(p => p.Skills);
        }

        public void Remove(Person entity)
        {
            Context.Set<Person>().Remove(entity);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public void Update(Person entity)
        {
            Context.Set<Person>().Update(entity);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Person GetByName(string name)
        {
            return Context.Set<Person>().Include(p => p.Skills).SingleOrDefault(p => p.Name == name);
        }
    }
}
