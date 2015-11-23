using Grupperum_Website_Klient.GrumService;
using Grupperum_Website_Klient.Models;
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

        [HttpGet]
        public ActionResult CreateGroup()
        {
            
            ViewBag.Message = "Opret Gruppe";

            using (GrumServiceClient client = new GrumServiceClient())
            {
                ViewBag.People = client.getClassById(2).StudentList;
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateGroup(FormCollection form, List<int> selected)
        {
            var gn = form.Get("groupName");
            string groupName = gn.ToString();

            int[] sel = selected.ToArray();

            using (GrumServiceClient client = new GrumServiceClient())
            {
                client.CreateGroup(groupName, sel);
            }

            return Redirect("Rent");
        }
        
        public ActionResult Rent(List<Grupperum_Website_Klient.GrumService.Student> sList)
        {
            ViewBag.Message = "Lej grupperum";

            return View();
        }
    }
}