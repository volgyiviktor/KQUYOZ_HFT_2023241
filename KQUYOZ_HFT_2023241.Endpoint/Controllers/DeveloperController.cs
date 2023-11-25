using KQUYOZ_HFT_2023241.Logic.Interfaces;
using KQUYOZ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KQUYOZ_HFT_2023241.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        IDeveloperLogic logic;
        public DeveloperController(IDeveloperLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Developer>ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Developer Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Developer value)
        { 
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Developer value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        /*
        // GET: api/<DeveloperController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeveloperController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeveloperController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DeveloperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeveloperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
