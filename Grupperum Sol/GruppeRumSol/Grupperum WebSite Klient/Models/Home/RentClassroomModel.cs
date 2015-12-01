using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupperum_Website_Klient.Models.Home
{
    public class RentClassroomModel
    {
        public String DateStart { get; set; }
        public String DateFinish { get; set; }

        public int GrId { get; set; }
        public string GrIdStr { get; set; }
        public int GrSize { get; set; }
        public bool ClassRoom { get; set; }
        public bool Whiteboard { get; set; }
        public bool Monitor { get; set; }
        public bool Projector { get; set; }
        public Request request { get; set; }

        public RentClassroomModel()
        {
            DateStart = DateTime.Today.Date.ToString("dd/MM/yyyy");
            DateFinish = DateTime.Today.Date.ToString("dd/MM/yyyy");
        }
    }
}