using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyFoodTogetherApi.Models
{
    public class FoodAppDatabaseSettings : IFoodAppDatabaseSettings
    {
        public string ItemsCollectionName { get; set; }
        public string PersonsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFoodAppDatabaseSettings
    {
        string ItemsCollectionName { get; set; }
        string PersonsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
