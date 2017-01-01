using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExample.Controllers
{
    [Route("company/[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "123";
        }

        [Route("[action]")]
        public string Address()
        {
            return "HK";
        }
    }
}
