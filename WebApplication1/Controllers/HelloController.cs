using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ServiceReferenceClient;

namespace WebApplication1.Controllers
{
    public class HelloController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string password)
        {
            ServiceHelloClient shc = new ServiceHelloClient();

            ViewBag.Result = shc.HelloWorld(login, password);

            return View();
        }
    }
}