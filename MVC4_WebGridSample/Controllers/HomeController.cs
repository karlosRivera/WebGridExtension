using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4_WebGridSample.Models;
using MVC4_WebGridSample.Service;


namespace MVC4_WebGridSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(StudentViewModel model)
        {
            StudentService service = new StudentService();
            return View(service.GetFilterData(model));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
