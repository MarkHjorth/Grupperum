using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfGrumService;

namespace Grupperum_Dedikeret_Klient
{
    public partial class Form1 : Form
    {
        private static IGrumService igs = new GrumService();

        public Form1()
        {
            InitializeComponent();
            CreateDropDownList();
        }

        private void btn_CreateRoom_Click(object sender, EventArgs e)
        {
            CreateGroupRoomPOPUP crpop = new CreateGroupRoomPOPUP();
            crpop.ShowDialog();
        }

        private void btn_editRoom_Click(object sender, EventArgs e)
        {
            string roomName = comBx_groupRooms.SelectedItem.ToString();
            EditGroupRoomPOPUP edpop = new EditGroupRoomPOPUP(roomName);
            edpop.ShowDialog();
        }

        private void CreateDropDownList()
        {
            List<string> grl = igs.GetGroupRooms();
            
            foreach (string s in grl)
            {
                comBx_groupRooms.Items.Add(s.Name);
            }
            comBx_groupRooms.SelectedIndex = 0;
        }
    }
}
