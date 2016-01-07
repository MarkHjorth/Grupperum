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
using GrupperumServer.ModelLayer;

namespace Grupperum_Dedikeret_Klient
{
    public partial class Form1 : Form
    {
        private static IGrumService igs = new GrumService();

        List<GroupRoom> grl = new List<GroupRoom>();

        public Form1()
        {
            InitializeComponent();
            grl = igs.GetGroupRooms();
            CreateDropDownList();
        }

        private void btn_CreateRoom_Click(object sender, EventArgs e)
        {
            CreateGroupRoomPOPUP crpop = new CreateGroupRoomPOPUP();
            crpop.ShowDialog();
            CreateDropDownList();
        }

        private void btn_editRoom_Click(object sender, EventArgs e)
        {
            GroupRoom gr;
            List<GroupRoom> tempList = new List<GroupRoom>();
            try
            {
                tempList = grl.Where(GroupRoom => GroupRoom.Name == comBx_groupRooms.SelectedItem.ToString()).ToList();
            }
            catch
            {
                gr = (GroupRoom)grl.Where(GroupRoom => GroupRoom.Name == comBx_groupRooms.SelectedItem.ToString());
            }
            gr = tempList[0];
            EditGroupRoomPOPUP edpop = new EditGroupRoomPOPUP(gr);
            edpop.ShowDialog();
        }

        private void CreateDropDownList()
        {
            comBx_groupRooms.Items.Clear();
            grl = igs.GetGroupRooms();
            foreach (GroupRoom gr in grl)
            {
                comBx_groupRooms.Items.Add(gr.Name);
            }
            comBx_groupRooms.SelectedIndex = 0;
        }

        private void btn_doTheFunk_Click(object sender, EventArgs e)
        {
            igs.DoTheFunkyAlgorithm();
            MessageBox.Show("Algoritmen er færdig!", "Done");
        }
    }
}
