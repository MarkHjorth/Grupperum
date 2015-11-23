using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupperum_Website_Klient.Models.Home
{
    public class CreateGroupModel
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }

    }
}