namespace ProjMongoDbAPI.Utils
{
    public class ProjMongoDbAPIDataBaseSettings : IProjMongoDbAPIDataBaseSettings
    {
        public string CustomerCollectionName { get; set ; }
        public string AddressCollectionName { get  ; set  ; }
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }


    }
}
