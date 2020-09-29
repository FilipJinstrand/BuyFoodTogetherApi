using BuyFoodTogetherApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyFoodTogetherApi.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _items;

        public ItemService(IFoodAppDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<Item>(settings.ItemsCollectionName);
        }

        public List<Item> Get() =>
            _items.Find(item => true).ToList();

        public Item Get(string id) =>
            _items.Find<Item>(item => item.Id == id).FirstOrDefault();

        public Item Create(Item item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, Item itemIn) =>
            _items.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(Item itemIn) =>
            _items.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _items.DeleteOne(item => item.Id == id);
    }
}
