using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mediatr_FluentValidation_Test.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mediatr_FluentValidation_Test.Controllers
{
    [ApiController]
    [Authorize]
    [Route("merchant")]
    public class MerchantController : ControllerBase
    {
        private readonly Contextt konteks;

        public MerchantController(Contextt context)
        {
            konteks = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<object> allData = new List<object>();
            var data = konteks.merhcants;
            foreach (var x in data)
            {
                allData.Add(new { x.id, x.name, x.image, x.address, x.rating });
            }
            return Ok(new { Message = "Success retreiving data", Status = true, Data = allData });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            var data = konteks.merhcants.Find(ID);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpPost]
        public IActionResult Post(Merhcant data)
        {
            konteks.merhcants.Add(data);
            konteks.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Merhcant data)
        {
            var query = konteks.merhcants.Find(id);
            query.id = data.id;
            query.name = data.name;
            query.image = data.image;
            query.address = data.address;
            query.rating = data.rating;
            query.updated_at = DateTime.Now;
            konteks.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await konteks.merhcants.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            konteks.merhcants.Remove(data);
            await konteks.SaveChangesAsync();

            return Ok();
        }

    }
}
