using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HauseCalcApi.Models;
using AppContext = HauseCalcApi.Models.AppContext;

namespace HauseCalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly AppContext _context;

        public CalculatorController(AppContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceDTO>>> GetPrices()
        {
            return await _context.Prices
                .Select(x => PriceToDTO(x))
                .ToListAsync();
        }

        // GET: api/Prices/5
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceDTO>> GetPrice(long id)
        {
            var todoItem = await _context.Prices.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return PriceToDTO(todoItem);
        }
        // </snippet_GetByID>

        // PUT: api/Prices/5
        // <snippet_Update>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrice(long id, PriceDTO priceDTO)
        {
            if (id != priceDTO.Id)
            {
                return BadRequest();
            }

            var PriceItem = await _context.Prices.FindAsync(id);
            if (PriceItem == null)
            {
                return NotFound();
            }

            PriceItem.Name = priceDTO.Name;
            PriceItem.Value = priceDTO.Value;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoPriceExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        // </snippet_Update>

        // POST: api/Prices
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<PriceDTO>> PostPriceItem(PriceDTO todoDTO)
        {
            var priceItem = new Price
            {
                Value = todoDTO.Value,
                Name = todoDTO.Name
            };

            _context.Prices.Add(priceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPrices),
                new { id = priceItem.Id },
                PriceToDTO(priceItem));
        }
        // </snippet_Create>

        // DELETE: api/Prices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.Prices.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Prices.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoPriceExists(long id)
        {
            return _context.Prices.Any(e => e.Id == id);
        }

        private static PriceDTO PriceToDTO(Price price) =>
           new PriceDTO
           {
               Id = price.Id,
               Name = price.Name,
               Value = price.Value
           };
    }
}
