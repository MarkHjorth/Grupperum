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
                    .ToList());
            }
            return Redirect("Rent");
        }


        [HttpGet]
        public ActionResult Rent()
        {
            RentModel model = new RentModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Rent(RentModel formModel)
        {
            GroupRoomModel model = new GroupRoomModel();
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


                model.GroupRoomList = client.GetGroupRoomList(ds, df, si, wh, mon)
                     .Select(gr => new Models.Home.GroupRoom() { GroupId = gr.Id, GroupName = gr.Name })
                     .ToList();
            }
            
            if (model.GroupRoomList.Count == 0 || model.GroupRoomList.Count == -1)
            {
                model.DisplayList = false;
            }

            return Redirect("Grouproom"(model));
        }

        [HttpGet]
        public ActionResult Grouproom(GroupRoomModel model)
        {
            using (GrumServiceClient client = new GrumServiceClient())
            { 
            
            } return View(model);
        }
        [HttpPost]
        public ActionResult Grouproom()
        {
            return Redirect("index");
        }
    }
}