using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AperoRental.API.DataContexts;
using AperoRental.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AperoRental.API.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly DataContext _context;

        public BikesController(DataContext context)
        {
            _context = context;
        }

        // GET /bikes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bikes = await GetAndInitBikesAsync();

            return Ok(bikes);
        }

        [AllowAnonymous]
        // GET api/bikes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Bike bike = await GetBikeAsync(id);
             return Ok(bike);
        }

        // POST api/bikes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/bikes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/bikes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task<List<Bike>> GetAndInitBikesAsync(){
           var bikes = await _context.Bikes.ToListAsync();
             foreach(Bike bike in bikes){
                Speed speed = await _context.Speeds.FirstOrDefaultAsync(s => s.Id == bike.SpeedId);
                bike.Speed = speed;
            }
            return bikes;
        }

        private async Task<Bike> GetBikeAsync(int id){
            Bike bike = await _context.Bikes.FirstOrDefaultAsync(arg => arg.Id == id);
            Speed speed = await _context.Speeds.FirstOrDefaultAsync(arg => arg.Id == bike.SpeedId);
            bike.Speed = speed;

            return bike;
        }

    }
}
