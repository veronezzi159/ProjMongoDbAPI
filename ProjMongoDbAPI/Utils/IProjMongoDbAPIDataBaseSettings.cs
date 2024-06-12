namespace ProjMongoDbAPI.Utils
{
    public interface IProjMongoDbAPIDataBaseSettings
    {
        string CustomerCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
