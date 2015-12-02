using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupperum_Website_Klient.Models.Home
{
    public class SearchGroupRoomModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }

        public int GrId { get; set; }
        public string GrIdStr { get; set; }
        public int GrSize { get; set; }
        public bool ClassRoom { get; set; }
        public bool Whiteboard { get; set; }
        public bool Monitor { get; set; }
        public bool Projector { get; set; }
        public Request request { get; set; }

        public SearchGroupRoomModel()
        {
            DateStart = DateTime.Today.Date;
            DateFinish = DateTime.Today.Date;
        }
    }
}