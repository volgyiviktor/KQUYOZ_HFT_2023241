using KQUYOZ_HFT_2023241.Logic.Interfaces;
using KQUYOZ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KQUYOZ_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGameLogic logic;
        public StatController(IGameLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{year}")]
        public List<Developer> AllDeveloperFromThatYear(int year)
        {
            return this.logic.AllDeveloperFromThatYear(year);
        }

        [HttpGet("{year}")]
        public List<Publisher> AllPublisherFromThatYear(int year)
        {
            return this.logic.AllPublisherFromThatYear(year);
        }

        [HttpGet("{id}")]
        public double AverageRatingOfDeveloperGames(int id)
        {
            return this.logic.AverageRatingOfDeveloperGames(id);
        }

        [HttpGet("{id}")]
        public double AverageRatingOfPublisherGames(int id)
        {
            return this.logic.AverageRatingOfPublisherGames(id);
        }

        [HttpGet("{year}")]
        public Developer DeveloperOfGameOfTheYear(int year)
        {
            return this.logic.DeveloperOfGameOfTheYear(year);
        }
        /*
        // GET: api/<StatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
