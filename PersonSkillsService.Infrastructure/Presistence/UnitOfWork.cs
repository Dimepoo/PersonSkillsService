using PersonSkillsService.Domain.Aggregates.Persons;
using PersonSkillsService.Domain.Aggregates.Skills;
using PersonSkillsService.Domain.Presistence;
using PersonSkillsService.Infrastructure.Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSkillsService.Infrastructure.Presistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly PersonSkillsContext _context;
        private bool disposedValue;

        public IRepository<Person> PersonRepository { get; set; }

        public IRepository<Skill> SkillReposutory { get; set; }

        public UnitOfWork(PersonSkillsContext context)
        {
            _context = context;

            PersonRepository = new Repository<Person>(_context);
            SkillReposutory = new Repository<Skill>(_context);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
