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

        public ActionResult CreateGroup()
        {
            ViewBag.Message = "Opret Gruppe";
            using(GrumServiceClient client = new GrumServiceClient())
            {
                ViewBag.ID1 = client.getClassById(1).Id;
                ViewBag.ID2 = client.getClassById(2).Id;
                ViewBag.ID3 = client.getClassById(3).Id;
                ViewBag.People = client.getClassById(2).StudentList;
            }

            return View();
        }
    }
}