using GrupperumServer.ModelLayer;
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

        public EditGroupRoomPOPUP(GroupRoom gr)
        {
            InitializeComponent();
            txtBx_roomName.Text = gr.Name;
            this.name = gr.Name;
            chkBx_whiteboard.Checked = gr.Whiteboard;
            chkBx_whiteboard.Checked = gr.Monitor;
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
