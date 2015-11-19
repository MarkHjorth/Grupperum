using Grupperum_Website_Klient.GrumService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupperum_Website_Klient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Denne side er om os";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt os";

            return View();
        }

        [HttpPost]
        public ActionResult CreateGroup(FormCollection form)
        {
            
            ViewBag.Message = "Opret Gruppe";
            using(GrumServiceClient client = new GrumServiceClient())
            {
                ViewBag.People = client.getClassById(2).StudentList;
            }
            var model = new Student();
            return View(model);
        }

        public ActionResult Rent(List<Student> sList)
        {
            ViewBag.Message = "Lej grupperum";

            return View();
        }
    }
}