using BuyFoodTogetherApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyFoodTogetherApi.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _persons;

        public PersonService(IFoodAppDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _persons = database.GetCollection<Person>(settings.PersonsCollectionName);
        }

        public List<Person> Get() =>
            _persons.Find(person => true).ToList();

        public Person Get(string id) =>
            _persons.Find<Person>(Person => Person.Id == id).FirstOrDefault();

        public Person Create(Person person)
        {
            _persons.InsertOne(person);
            return person;
        }

        public void Update(string id, Person personIn) =>
            _persons.ReplaceOne(person => person.Id == id, personIn);

        public void Remove(Person personIn) =>
            _persons.DeleteOne(person => person.Id == personIn.Id);

        public void Remove(string id) =>
            _persons.DeleteOne(person => person.Id == id);
    }
}
