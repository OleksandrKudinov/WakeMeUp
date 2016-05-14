using System.Net.Http;
using System.Web.Http;

namespace WakeMeUp.WebApp.Controllers
{
    public class WakeMeUpController : ApiController
    {
        public IHttpActionResult Get()
        {
            var sd = Request.GetDependencyScope();
            WakeUpService service = (WakeUpService)sd.GetService(typeof(WakeUpService));
            service.SendMessage("asd");
            return Ok("Wake me up, my darling ;)");
        }
    }
}
