using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepositoryDesignPattern
{
    public class PersonRepository<T> : IRepository<Person, int> where T : DatabaseContext, new()
    {
        private readonly T _database;

        public PersonRepository()
        {
        }
        public PersonRepository(T database)
        {
            _database = database ?? new T();
        }


        public IEnumerable<Person> List
        {
            get { return _database.Persons.ToList(); }
        }
        public void Add(Person entity)
        {
            _database.Persons.Add(entity);
            _database.SaveChanges();
        }

        public void Delete(Person entity)
        {
            _database.Persons.Remove(entity);
        }

        public void Update(Person entity)
        {
            _database.Entry(entity).State = EntityState.Modified;
            _database.SaveChanges();
        }

        public Person FindById(int id)
        {
            return _database.Persons.FirstOrDefault(x => x.Id == id);
        }

        public Person FindById(string email)
        {
            return _database.Persons.FirstOrDefault(x => x.Email.Equals(email));
        }
    }
}