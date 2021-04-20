using System;
using System.Collections.Generic;


namespace PersonSkillsService.Domain.Presistence
{
    /// <summary>
    /// Интерфейс для реализации паттерна "Репозиторий"
    /// позволяющий абстрагироваться от конкретных подключений 
    /// к источникам данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>: IDisposable
    {
        void Create(T entity);
        IEnumerable<T> GetAll();
        T GetById(long id);
        T GetByName(string name);
        void Update(T entity);
        void Remove(T entity);
        int Save();
    }
}
