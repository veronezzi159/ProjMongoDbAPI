using MongoDB.Driver;
using ProjMongoDbAPI.Models;
using ProjMongoDbAPI.Utils;

namespace ProjMongoDbAPI.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(IProjMongoDbAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }
        
        public List<Address> Get() =>_address.Find(address => true).ToList();

        public Address GetById(string id) => _address.Find<Address>(address => address.Id == id).FirstOrDefault();

         public Address Create(Address address)
         {
            _address.InsertOne(address);
            return address;
         }

    }
}
