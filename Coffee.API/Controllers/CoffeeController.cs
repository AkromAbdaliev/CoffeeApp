using Coffee.API.DTOs;
using Coffee.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<CoffeeRecordDto>>> GetAll()
        {
            var coffees = await _coffeeService.GetAllAsync();
            return Ok(coffees);
        }

        [HttpGet("getby/{id}")]
        public async Task<ActionResult<CoffeeRecordDto>> GetById(int id)
        {
            var coffee = await _coffeeService.GetByIdAsync(id);
            if (coffee == null)
                return NotFound();

            return Ok(coffee);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add ([FromBody] CreateCoffeeDto createRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _coffeeService.AddAsync(createRecord);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var exists = await _coffeeService.GetByIdAsync(id);
            if (exists == null)
            {
                return NotFound(new {message = "Record not found or already deleted."});
            }

            await _coffeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
