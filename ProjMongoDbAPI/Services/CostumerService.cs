using MongoDB.Driver;
using ProjMongoDbAPI.Models;
using ProjMongoDbAPI.Utils;

namespace ProjMongoDbAPI.Services
{
    public class CostumerService
    {
        private readonly IMongoCollection<Customer> _costumers;
        public CostumerService(IProjMongoDbAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _costumers = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }
        public List<Customer> Get() =>
            _costumers.Find(costumer => true).ToList();
        public Customer GetById(string id) =>
            _costumers.Find<Customer>(costumer => costumer.Id == id).FirstOrDefault();
        public Customer Create(Customer costumer)
        {
            _costumers.InsertOne(costumer);
            return costumer;
        }

        public void Update(string id, Customer costumerIn) =>
            _costumers.ReplaceOne(costumer => costumer.Id == id, costumerIn);

        public void Remove(Customer costumerIn) =>
            _costumers.DeleteOne(costumer => costumer.Id == costumerIn.Id);

        public void RemoveById(string id) =>
            _costumers.DeleteOne(costumer => costumer.Id == id);
    }
}
