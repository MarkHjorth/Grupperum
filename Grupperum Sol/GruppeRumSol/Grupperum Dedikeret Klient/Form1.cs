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
        }

        private void btn_CreateRoom_Click(object sender, EventArgs e)
        {
            
        }
    }
}
