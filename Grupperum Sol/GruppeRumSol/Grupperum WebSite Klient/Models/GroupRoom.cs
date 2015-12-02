using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grupperum_Website_Klient.Models.Home
{
    public class GroupRoom
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool Selected { get; set; }
    
        public GroupRoom()
        {

        }

    }
}
