using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHCL.Day1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";

            return View();
        }
        //public ActionResult Test(int empid,string name)
        //{
        //    ViewBag.Message = "My Test page.";

        //    //return View();
        //    return Content("empid:"+empid+"name:" +name);
        //}
        //public ActionResult Example(string name)
        //{
        //    return View();
        //}
    }
}