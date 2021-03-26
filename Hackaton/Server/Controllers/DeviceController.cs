using Hackaton.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackaton.Server.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        ApplicationDbContext _context = null;
        public DeviceController(ApplicationDbContext context) {
            _context = context;
        }
        // GET: api/<DeviceController>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Devices.OrderBy(b => b.Id).ToList());
        }

        // GET api/<DeviceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Devices.FindAsync(id);
            if (result is null)
                return NotFound();
            return new JsonResult(result);
        }

        // POST api/<DeviceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Device body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Devices.Add(body);
            await _context.SaveChangesAsync();
            return Ok(); // 200
        }

        // PUT api/<DeviceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Device newDevice)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device is null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();
            device.Latitude = newDevice.Latitude;
            device.Longtitude = newDevice.Longtitude;
            await _context.SaveChangesAsync();
            return Ok();

        }

        // DELETE api/<DeviceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device is null)
                return NotFound();
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
