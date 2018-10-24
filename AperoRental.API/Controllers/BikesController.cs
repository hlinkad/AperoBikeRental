using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AperoRental.API.DataContexts;
using AperoRental.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AperoRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly DataContext _context;

        public BikesController(DataContext context)
        {
            _context = context;
        }

        // GET api/bikes
        [HttpGet]
        public IActionResult Get()
        {
            var bikes = _context.Bikes.ToList();
           
            foreach(Bike bike in bikes){
                int speed1 = _context.Speeds.FirstOrDefault(s => s.Id == bike.SpeedId).Speed1;
                int speed2 = _context.Speeds.FirstOrDefault(s => s.Id == bike.SpeedId).Speed2;
                bike.Speed.Speed1 = speed1;
                bike.Speed.Speed2 = speed2;
            }


            return Ok(bikes);
        }

        // GET api/bikes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bike = _context.Bikes.FirstOrDefault(arg => arg.Id == id);

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
    }
}
