namespace ProjMongoDbAPI.Utils
{
    public interface IProjMongoDbAPIDataBaseSettings
    {
        string ClientCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
