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
            // check for students selected
            if (formModel.Students == null || formModel.Students.Count == 0) { return View(formModel); }

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
            GroupRoomListModel model = new GroupRoomListModel();
            using (GrumServiceClient client = new GrumServiceClient())
            {
                DateTime ds = formModel.DateStart;
                DateTime df = formModel.DateFinish;

                bool cr = formModel.request.ClassRoom;
                string idS = formModel.GrIdStr;
                int id = Int32.Parse(idS);
                int si = formModel.request.GrSize;
                bool wh = formModel.request.Whiteboard;
                bool mon = formModel.request.Monitor;
                bool pr = formModel.request.Projector;

                
                //model.GroupRoomList = client.GetGroupRoomList(ds, df, si, wh, mon);
            }

            if (model.GroupRoomList.Count == 0)
            {
                model.DisplayList = false;
            }

            return RedirectToAction("Grouproom", model);
        }
        [HttpGet]
        public ActionResult Grouproom(GroupRoomListModel formModel)
        {

            return View(formModel);
        }
        [HttpPost]
        public ActionResult Grouproom()
        {
            return Redirect("index");
        }
    }
}