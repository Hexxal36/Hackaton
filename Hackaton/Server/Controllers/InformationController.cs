using Hackaton.Server.Data;
using Hackaton.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackaton.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public InformationController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Information.OrderByDescending(b => b.CreatedAt).ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Information.FindAsync(id);
            if (result is null)
                return NotFound();
            return new JsonResult(result);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Information body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            if (_context.Devices.Find(body.DeviceId) is null)
            {
                return BadRequest();
            }
            body.CreatedAt = DateTime.Now;
            _context.Information.Add(body);
            await _context.SaveChangesAsync();
            return Ok(); // 200
        }
    }
}
