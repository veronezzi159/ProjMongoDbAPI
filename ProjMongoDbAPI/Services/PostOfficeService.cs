using Newtonsoft.Json;
using ProjMongoDbAPI.Models;
namespace ProjMongoDbAPI.Services
{
    public class PostOfficeService
    {
        static readonly HttpClient address = new HttpClient();

        public static async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage repos = await address.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                repos.EnsureSuccessStatusCode();

                string addr = await repos.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<AddressDTO>(addr);
            }
            catch (Exception e)
            {

                throw;
            }

           
        }
    }
}
