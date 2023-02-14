using Microsoft.AspNetCore.Mvc;
using System;

namespace CrouseServiceAdvertisement.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("[controller]")]
        public string Index()
        {
            return "Welcome. Crouse Advertisement Service is running...  (" + DateTime.Now.ToString() + ")";
        }

        [HttpPost]
        [Route("[action]")]
        public string Check([FromBody] string msg)
        {
            return msg;
        }
    }
}
