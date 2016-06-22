using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCars.Data
{
    public class PersonRepository
    {
        private string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> GetPeople()
        {
            using (var context = new PersonCarsDataContext(_connectionString))
            {
                var dataLoadOptions = new DataLoadOptions();
                dataLoadOptions.LoadWith<Person>(p => p.Cars);
                context.LoadOptions = dataLoadOptions;

                return context.Persons.ToList();
            }
        }

        public Person GetById(int personId)
        {
            using (var context = new PersonCarsDataContext(_connectionString))
            {
                return context.Persons.FirstOrDefault(p => p.Id == personId);
            }
        }
    }
}
