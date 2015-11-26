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
    public partial class EditGroupRoomPOPUP : Form
    {
        IGrumService igs = new GrumService();
        string name;

        public EditGroupRoomPOPUP(string name)
        {
            InitializeComponent();
            txtBx_roomName.Text = name;
            this.name = name;
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            bool whiteboard = chkBx_whiteboard.Checked;
            bool monitor = chkBx_whiteboard.Checked;

            if (igs.UpdateGroupRoom(name, whiteboard, monitor))
            {
                MessageBox.Show("Grupperum opdateret");
                this.Close();
            }
            else
            {
                MessageBox.Show("En fejl er opstået. Grupperum ikke opdateret!");
            }
        }
    }
}
