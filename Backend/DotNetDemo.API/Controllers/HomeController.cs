using System.Web.Mvc;

namespace DotNetDemo.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/Swagger");
        }
    }
}
