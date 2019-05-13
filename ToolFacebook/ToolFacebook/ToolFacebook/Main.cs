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
    public partial class ToolFb : Form
    {
        public ToolFb()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddUser().ShowDialog();
        }

        private void ToolFb_Load(object sender, EventArgs e)
        {

        }

        private void checkUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UserManager().ShowDialog();
        }

        private void postManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createPostToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
