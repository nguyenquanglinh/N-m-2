using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var x = new Ram("G.skill", "2x16GB", "DDR4", "2666MHZ", "pc");
            var y = new CPU("intel", "core I5-9400F", "LGA 1151 -v2", "2.9-4.1 GHZ", "6");
            var z = new MainBoard("asrock", "h310", "LGA 1151 -v2", "H310", "2 khe", "32Gb", "2133MHZ", "DDR4");
            MessageBox.Show(y.ToString()+x.ToString()+z.ToString());
        }
    }
}
