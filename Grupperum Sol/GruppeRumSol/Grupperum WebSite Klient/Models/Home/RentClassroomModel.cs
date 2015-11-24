using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupperum_Website_Klient.Models.Home
{
    public class RentClassroomModel
    {
        public int GrId { get; set; }
        public int GrSize { get; set; }
        public bool Whiteboard { get; set; }
        public bool Monitor { get; set; }
        public bool Projector { get; set; }
        public Request request { get; set; }

        public RentClassroomModel()
        {

        }
    }
}