using MongoDB.Driver;
using ProjMongoDbAPI.Models;
using ProjMongoDbAPI.Utils;

namespace ProjMongoDbAPI.Services
{
    public class CostumerService
    {
        private readonly IMongoCollection<Costumer> _costumers;
        public CostumerService(IProjMongoDbAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _costumers = database.GetCollection<Costumer>(settings.ClientCollectionName);
        }
        public List<Costumer> Get() =>
            _costumers.Find(costumer => true).ToList();
        public Costumer GetById(string id) =>
            _costumers.Find<Costumer>(costumer => costumer.Id == id).FirstOrDefault();
        public Costumer Create(Costumer costumer)
        {
            _costumers.InsertOne(costumer);
            return costumer;
        }

        public void Update(string id, Costumer costumerIn) =>
            _costumers.ReplaceOne(costumer => costumer.Id == id, costumerIn);

        public void Remove(Costumer costumerIn) =>
            _costumers.DeleteOne(costumer => costumer.Id == costumerIn.Id);

        public void Remove(string id) =>
            _costumers.DeleteOne(costumer => costumer.Id == id);
    }
}
