using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupperum_Website_Klient.Models.Home
{
    public class GroupRoomListModel
    {
        public List<GroupRoom> GroupRoomList { get; set; }
        public bool DisplayList { get; set; }
        public GroupRoomListModel()
        {
            GroupRoomList = new List<GroupRoom> { };
            DisplayList = true;
        }
    }
}