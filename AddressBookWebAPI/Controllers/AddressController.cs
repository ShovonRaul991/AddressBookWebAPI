using Microsoft.AspNetCore.Mvc;
using AddressBookWebAPI.Data;
using AddressBookWebAPI.Model;

namespace AddressBookWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly AddressBookAPIDbContext _context;

        public AddressController(AddressBookAPIDbContext db)
        {
            _context= db;
        }

        [HttpGet]
        [Route("GetAllAddress")]
        public IActionResult Index()
        {
            return Ok(_context.Addresses.ToList());

        }

        [HttpGet]
        [Route("GetAddress/{id}")]
        public IActionResult GetAddressDetails(int id)
        {
            var tempAddress = _context.Addresses.Find(id);
            if (tempAddress == null)
            {
                return NotFound();
            }
            return Ok(tempAddress);
        }

        [HttpPost]
        [Route("AddAddress")]
        public IActionResult GetAddress(AddAddress obj)
        {
            var tempAddress = new Address()
            {
                Name = obj.Name,
                email = obj.email,
                phone = obj.phone,
                landline = obj.landline,
                website = obj.website,
                AddressDetails = obj.AddressDetails,
            };
            _context.Addresses.Add(tempAddress);
            _context.SaveChanges();
            return Ok(tempAddress);
        }

        [HttpPut]
        [Route("UpdateAddress/{id}")]
        public IActionResult UpdateAddressDetails(int id, AddAddress obj)
        {
            var tempAddress = _context.Addresses.Find(id);
            if(tempAddress== null)
            {
                return NotFound();
            }
            tempAddress.Name = obj.Name;
            tempAddress.email = obj.email;
            tempAddress.phone = obj.phone;
            tempAddress.landline = obj.landline;
            tempAddress.website = obj.website;
            tempAddress.AddressDetails = obj.AddressDetails;

            return Ok(tempAddress);
        }

        [HttpDelete]
        [Route("DeleteAddress/{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var tempAddress = _context.Addresses.Find(id);
            if(tempAddress== null)
            {
                return BadRequest();
            }
            _context.Remove(tempAddress);
            _context.SaveChanges();
            return Ok(tempAddress);

        }
    }
}
