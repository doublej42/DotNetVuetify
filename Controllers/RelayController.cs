using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DotNetVuetify.Controllers
{
    [Route("api/[controller]")]
    public class RelayController : Controller
    {
        public static Dictionary<long, List<postableData>> data = new Dictionary<long, List<postableData>>();

        [HttpPost()]
        public void Post([FromBody] postableData postedData )
        {
            if (!data.ContainsKey(postedData.room))
            {
                data[postedData.room] = new List<postableData>();
            }
            data[postedData.room].Add(postedData);
        }

        [HttpGet("{room}")]
        public List<postableData> Get(long room)
        {
            if (!data.ContainsKey(room))
            {
                data[room] = new List<postableData>();
            }
            return data[room];
        }

        public class postableData
        {
            public long room { get; set; }
            public string sender { get; set; }

            public string message { get; set; }
        }

    }
}
