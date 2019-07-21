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
            var t = new CardManhinh("gigabyte", "gtx-1660ti", "1600", "1845MHZ", "6gb GĐR^", "pcie", "hdmi", "2 quạt", "450w");
            var a = new ManHinh("AOC","xyz", "21.5", "1920x1080", "phẳng");
            var o = new OCung("ss", "ssd", "120", "M,2", "sât", "500mb/s", "320mb");
            MessageBox.Show(y+x.ToString()+z.ToString()+a+o+t);
        }
        void start()
        {
            string createTableQuery = @"CREATE TABLE IF NOT EXISTS [MyTable] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [Key] NVARCHAR(2048)  NULL,
                          [Value] VARCHAR(2048)  NULL
                          )";

        }
    }
}
