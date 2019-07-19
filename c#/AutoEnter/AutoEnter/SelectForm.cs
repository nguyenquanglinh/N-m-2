using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoEnter
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();

            BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
            this.ControlBox = false;
        }
        public Point GetLocation()
        {
            //this.Hide();
            return new Point(this.Location.X + 7, this.Location.Y + 30);
        }
        public Size GetSize()
        {
            return pictureBox1.Size;
        }
         

        internal int GetWidth()
        {
            return pictureBox1.Width;
        }

        internal int GetHeight()
        {
            return pictureBox1.Height;
        }

        private void SelectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
