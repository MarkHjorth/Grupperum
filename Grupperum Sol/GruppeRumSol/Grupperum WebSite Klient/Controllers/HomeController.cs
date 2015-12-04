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
        [HttpGet]
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
            RentModel model = new RentModel();

            DateTime ds = formModel.DateStart;
            DateTime df = formModel.DateFinish;

            bool cr = formModel.request.ClassRoom;
            string idS = formModel.GrIdStr;
            int id = Int32.Parse(idS);
            int si = formModel.request.GrSize;
            bool wh = formModel.request.Whiteboard;
            bool mon = formModel.request.Monitor;
            bool pr = formModel.request.Projector;

            //Saves session cookie if they want classroom
            Session["cr"] = cr;
            //Saves session cookie: GroupId
            Session["id"] = id;
            //Saves session cookie: GroupSize
            Session["si"] = si;
            //Saves session cookie: start/finish date
            Session["ds"] = ds;
            Session["df"] = df;
            //Saves session cookie: preferences about whiteboard, monitor and projector(classroom only)
            Session["wh"] = wh;
            Session["mon"] = mon;
            Session["pr"] = pr;

            return Redirect("Grouproom");
        }

        [HttpGet]
        public ActionResult Grouproom()
        {
            GroupRoomModel model = new GroupRoomModel();

            using (GrumServiceClient client = new GrumServiceClient())
            {
                if (Session.Count == 0)
                {
                    return Redirect("Rent");
                }

                int id = (int) Session["id"];
                DateTime ds = (DateTime)Session["ds"];
                DateTime df = (DateTime)Session["df"];
                int si = (int)Session["si"];
                bool wh = (bool)Session["wh"];
                bool mon = (bool)Session["mon"];
                
                model.GroupRoomList = client.GetGroupRoomList(ds, df, si, wh, mon)
                     .Select(gr => new Models.Home.GroupRoom() { GroupRoomId = gr.Id, GroupRoomName = gr.Name })
                     .ToList();
            
                if (model.GroupRoomList.Count == 0 || model.GroupRoomList.Count == -1)
                {
                    model.DisplayList = false;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Grouproom(GroupRoomModel formModel)
        {
            using (GrumServiceClient client = new GrumServiceClient())
            {
                var gr = formModel.GroupRoomList.Where(x => x.Selected == true).FirstOrDefault();

                int groupSize = (int) Session["si"];
                DateTime ds = (DateTime) Session["ds"];
                DateTime df = (DateTime) Session["df"];
                bool wh = (bool) Session["wh"];
                bool mon = (bool) Session["mon"];
                bool pr = (bool) Session["pr"]; 

                bool RentedGroupRoom = client.RentGroupRoom(gr.GroupRoomId, groupSize, ds, df);
                Session["groupRoomName"] = gr.GroupRoomName;                
                Session["rgr"] = RentedGroupRoom;
                bool ListedToClassRoom = false;
                Session["ltcr"] = false;
                
                if (!RentedGroupRoom)
                {
                    ListedToClassRoom = client.RequestClassRoom(gr.GroupRoomId, groupSize, wh, mon, pr);
                    Session["ltcr"] = ListedToClassRoom;
                }
            }
            return Redirect("Finish");
        }

        public ActionResult Finish()
        {
            FinishModel model = new FinishModel();
            model.RentedGroupRoom = (bool)Session["rgr"];
            if (model.RentedGroupRoom == null)
            {
                model.RentedGroupRoom = false;
            }
            model.ListedForClassRoom = (bool)Session["ltcr"];
            if (model.ListedForClassRoom == null)
            {
                model.ListedForClassRoom = false;
            }
            return View(model);
        }    
    }
}