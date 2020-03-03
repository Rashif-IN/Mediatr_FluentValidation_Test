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
    [Route("customer_PC")]
    public class CPCController : ControllerBase
    {
        private readonly Contextt konteks;

        public CPCController(Contextt context)
        {
            konteks = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<object> allData = new List<object>();
            var data = konteks.CPC;
            foreach (var x in data)
            {
                allData.Add(new { x.id, x.customer_id, x.name_on_card, x.exp_month, x.exp_year, x.postal_code, x.credit_card_number });
            }
            return Ok(new { Message = "Success retreiving data", Status = true, Data = allData });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            var data = konteks.CPC.Find(ID);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpPost]
        public IActionResult Post(Customer_Payment_Card data)
        {
            konteks.CPC.Add(data);
            konteks.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer_Payment_Card data)
        {
            var query = konteks.CPC.Find(id);
            query.customer_id = data.customer_id;
            query.name_on_card = data.name_on_card;
            query.exp_month = data.exp_month;
            query.exp_year = data.exp_year;
            query.postal_code = data.postal_code;
            query.credit_card_number = data.credit_card_number;
            query.updated_at = DateTime.Now;
            konteks.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await konteks.CPC.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            konteks.CPC.Remove(data);
            await konteks.SaveChangesAsync();

            return Ok();
        }


    }
}
