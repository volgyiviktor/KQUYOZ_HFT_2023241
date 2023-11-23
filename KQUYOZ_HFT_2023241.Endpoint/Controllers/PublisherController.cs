using KQUYOZ_HFT_2023241.Logic.Interfaces;
using KQUYOZ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KQUYOZ_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IPublisherLogic logic;
        public PublisherController(IPublisherLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Publisher value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Publisher value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        /*
        // GET: api/<PublisherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PublisherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
