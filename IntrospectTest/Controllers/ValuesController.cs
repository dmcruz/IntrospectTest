using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IntrospectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        const string URL = "";
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values/userinfo/tk
        [HttpGet("userinfo/{tk}")]

        public string GetUserInfo(string tk)
        {
            return validateAccessToken(tk);
        }

        private string validateAccessToken(string at)
        {
            try
            {
                var response = string.Empty;
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Authorization", "Bearer " + at);
                    response = client.DownloadString(URL);
                    return response;
                }
            }
            catch(Exception ex)
            {
                return ex.Message + " ::: " + ex.StackTrace + " ::: " + (ex.InnerException != null ? ex.InnerException.Message + " :: " + ex.InnerException.StackTrace : "");
            }
        }
    }
}
