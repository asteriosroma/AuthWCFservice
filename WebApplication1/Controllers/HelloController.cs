using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ServiceReferenceClient;
using WcfService1.Models;

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

            Account acc = shc.HelloAccount(login, password);

            if(acc == null)
            {
                return View("Error");
            }

            return View(acc);
        }
    }
}