using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolFacebook
{
    public partial class AddPost : Form
    {
        public AddPost()
        {
            InitializeComponent();
            Application.Idle += new EventHandler(FrameGrabber);
        }

        private void FrameGrabber(object sender, EventArgs e)
        {
            if (postForm1.Close)
            {
                this.Close();
                Application.Idle-= new EventHandler(FrameGrabber);
            }
        }
    }
}
