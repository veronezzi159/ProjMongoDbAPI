using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoDbAPI.Models;
using ProjMongoDbAPI.Services;

namespace ProjMongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get()
        {
            return _addressService.Get();
        }

        [HttpGet("id:length(24)", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            return address;
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);
            return CreatedAtRoute("GetAddress", new { id = address.Id }, address);
        }
    }
}
