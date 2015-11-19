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
        public ActionResult CreateGroup(FormCollection form)
        {
            int i = 0;
            var groupName = form.GetValue("groupName");
            List< int > studentIdList = new List<int>();
            /*
            while (form.GetValue("Checkbox" + i) != null)
            {
                var tempvar = (form.GetValue("Checkbox" + i));
                int studentId = Int32.Parse(tempvar);
                studentIdList.Add(tempvar);
                form.
                i++;
            }
            */
            var ckbx1 = form.GetValue("chkbx1");
            var ckbx2 = form.GetValue("chkbx2");
            var ckbx3 = form.GetValue("chkbx3");

            using (GrumServiceClient client = new GrumServiceClient())
            {
                //client.CreateGroup(groupName, );
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