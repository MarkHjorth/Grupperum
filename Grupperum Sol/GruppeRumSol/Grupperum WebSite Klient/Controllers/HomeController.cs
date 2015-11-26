using Grupperum_Website_Klient.GrumService;
using Grupperum_Website_Klient.Models;
using Grupperum_Website_Klient.Models.Home;
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
            CreateGroupModel model = new CreateGroupModel();
            using (GrumServiceClient client = new GrumServiceClient())
            {
                model.Students = client.getClassById(2).StudentList
                    .Select(s => new Models.Student(s.Id, s.Name))
                    .ToList();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateGroup(CreateGroupModel formModel)
        {
            int[] idList = formModel.Students.Where(s => s.Selected).Select(s => s.Id).ToArray();
            // check for students selected
            if (formModel.Students == null || idList.Length == 0)
            {
                return Redirect("CreateGroup");
            }

            using (GrumServiceClient client = new GrumServiceClient())
            {
                
                client.CreateGroup(formModel.Name, formModel.Students
                    .Where(s => s.Selected)
                    .Select(s => s.Id)
                    .ToArray());
            }

            return Redirect("Rent");
        }
        
        [HttpGet]
        public ActionResult Rent()
        { 
            RentClassroomModel model = new RentClassroomModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Rent(RentClassroomModel formModel)
        {
            using (GrumServiceClient client = new GrumServiceClient())
            {
                string idS = formModel.GrIdStr;
                int id = Int32.Parse(idS);
                int si= formModel.request.GrSize;
                bool wh = formModel.request.Whiteboard;
                bool mon = formModel.request.Monitor;
                bool pr= formModel.request.Projector;
                client.RequestClassRoom(id, si, wh, mon, pr);
            }
            return Redirect("Rent");
        }
    }
}