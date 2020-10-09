using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanOutputLibrary;
using Microsoft.AspNetCore.Mvc;

namespace FanRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FanController : ControllerBase
    {
        private static List<FanOutput> _fanList = new List<FanOutput>();
        private static int _idCounter = 1;

        // GET: api/Fan
        [HttpGet]
        public IEnumerable<FanOutput> Get()
        {
            return _fanList;
        }

        // GET api/Fan/5
        [HttpGet("{id}")]
        public FanOutput Get(int id)
        {
            return _fanList.Find(f => f.Id == id);
        }

        // POST api/Fan
        [HttpPost]
        public void Post([FromBody] FanOutput fanOutput)
        {
            fanOutput.Id = _idCounter++;
            _fanList.Add(fanOutput);
        }

        // PUT api/Fan/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutput value)
        {
            FanOutput fanOutput = Get(id);
            if (fanOutput != null)
            {
                fanOutput.Id = value.Id;
                fanOutput.Navn = value.Navn;
                fanOutput.Temp = value.Temp;
                fanOutput.Fugt = value.Fugt;
            }
        }

        // DELETE api/Fan/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutput fanOutput = Get(id);
            _fanList.Remove(fanOutput);
        }
    }
}
