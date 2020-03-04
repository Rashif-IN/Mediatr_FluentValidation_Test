using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mediatr_FluentValidation_Test.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Mediatr_FluentValidation_Test.Controllers
{
    [ApiController]
   
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly Contextt konteks;

        public ProductController(Contextt context)
        {
            konteks = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<object> allData = new List<object>();
            var data = konteks.Product;
            foreach (var x in data)
            {
                allData.Add(new { x.id, x.merhcant_id, x.name, x.price });
            }
            return Ok(new { Message = "Success retreiving data", Status = true, Data = allData });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            var data = konteks.Product.Find(ID);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpPost]
        public IActionResult Post(RequestData<Products> data)
        {
            konteks.Product.Add(data.Dataa.Attributes);
            konteks.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RequestData<Products> data)
        {
            var query = konteks.Product.Find(id);
            query.merhcant_id = data.Dataa.Attributes.merhcant_id;
            query.name = data.Dataa.Attributes.name;
            query.price = data.Dataa.Attributes.price;
            query.updated_at = DateTime.Now;
            konteks.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await konteks.Product.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            konteks.Product.Remove(data);
            await konteks.SaveChangesAsync();

            return Ok();
        }

    }
}
