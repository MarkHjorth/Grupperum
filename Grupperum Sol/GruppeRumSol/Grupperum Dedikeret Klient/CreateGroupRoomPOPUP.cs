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
    public partial class CreateGroupRoomPOPUP : Form
    {
        private static IGrumService igs = new GrumService(); 
        public CreateGroupRoomPOPUP()
        {
            InitializeComponent();
        }

        private void lbl_Name_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lol wat XD");
        }

        private void btn_godkend_Click(object sender, EventArgs e)
        {
            string name = txt_Name.Text;
            bool whiteboard = check_whiteboard.Checked;
            bool monitor = Check_Monitor.Checked;

            if(igs.CreateGroupRoom(name, whiteboard, monitor))
            {
                MessageBox.Show("Grupperum oprettet");
                this.Close();
            }
            else
            {
                MessageBox.Show("En fejl er opstået. Grupperum ikke oprettet!");
            }
        }
    }
}
