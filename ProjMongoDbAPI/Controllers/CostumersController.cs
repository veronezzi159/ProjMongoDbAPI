using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoDbAPI.Models;
using ProjMongoDbAPI.Services;

namespace ProjMongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumersController : ControllerBase
    {
        private readonly CostumerService _costumerService;
        private readonly AddressService _addressService;
        public CostumersController(CostumerService costumerService, AddressService addressService)
        {
            _costumerService = costumerService;
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return _costumerService.Get();
        }
        
        [HttpGet("{id:length(24)}", Name = "GetCostumer")]
        public ActionResult<Customer> Get(string id)
        {
            var costumer = _costumerService.GetById(id);
            if (costumer == null)
            {
                return NotFound();
            }
            return Ok(costumer);
        }
        [HttpPost]
        public ActionResult<Customer> Create(Customer costumer)
        {
            
            costumer.Address = _addressService.Create(costumer.Address); 
            var c = _costumerService.Create(costumer);
            if (c == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetCostumer", new { id = costumer.Id }, costumer);
        }

    }
}
