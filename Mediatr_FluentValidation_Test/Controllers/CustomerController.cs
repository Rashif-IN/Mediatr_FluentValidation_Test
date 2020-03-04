using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mediatr_FluentValidation_Test.Model;
using Microsoft.AspNetCore.Mvc;


namespace Mediatr_FluentValidation_Test.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly Contextt konteks;

        public CustomerController(Contextt context)
        {
            konteks = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<object> allData = new List<object>();
            var data = konteks.Customer;
            foreach (var x in data)
            {
                allData.Add(new { x.id, x.full_name, x.username, x.birthdate, x.password, x.email, x.phone_number });
            }
            return Ok(new { Message = "Success retreiving data", Status = true, Data = allData });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            var data = konteks.Customer.Find(ID);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpPost]
        public IActionResult Post(Customers data)
        {
            konteks.Customer.Add(data);
            konteks.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customers data)
        {
            var query = konteks.Customer.Find(id);
            query.full_name = data.full_name;
            query.username = data.username;
            query.birthdate = data.birthdate;
            query.password = data.password;
            query.gender = data.gender;
            query.email = data.email;
            query.phone_number = data.phone_number;
            query.updated_at = DateTime.Now;
            konteks.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await konteks.Customer.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            konteks.Customer.Remove(data);
            await konteks.SaveChangesAsync();

            return Ok();
        }


    }
}
