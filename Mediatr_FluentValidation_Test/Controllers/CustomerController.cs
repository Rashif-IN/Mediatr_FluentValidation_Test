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
            var data = konteks.Customer;
            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
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
        public IActionResult Post(RequestData<Customers> data)
        {
            konteks.Customer.Add(data.Dataa.Attributes);
            if(data.Dataa.Attributes.sex == "male")
            {
                data.Dataa.Attributes.gender = kelamin.male;
            }
            else if(data.Dataa.Attributes.sex == "female")
            {
                data.Dataa.Attributes.gender = kelamin.female;
            }
            konteks.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RequestData<Customers> data)
        {
            var query = konteks.Customer.Find(id);
            query.full_name = data.Dataa.Attributes.full_name;
            query.username = data.Dataa.Attributes.username;
            query.birthdate = data.Dataa.Attributes.birthdate;
            query.password = data.Dataa.Attributes.password;
            query.gender = data.Dataa.Attributes.gender;
            query.email = data.Dataa.Attributes.email;
            query.phone_number = data.Dataa.Attributes.phone_number;
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
