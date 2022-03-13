using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Collections.Generic;

namespace Trip.Feeds.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        [RequiredScope("FeedScopes:ReadScope")]
        [HttpGet()]
        // GET: api/<MenuController>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [RequiredScope("access_as_user")]
        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
