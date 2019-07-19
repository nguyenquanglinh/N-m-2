using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoEnter
{
    public partial class Form1 : Form
    {
        //private Point pointtEnd;
        //private Point pointStart;
        private SelectForm selectform;
        public Form1()
        {
            InitializeComponent();
            this.selectform = new SelectForm();
            selectform.Show();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
           
            timer1.Start();
            dem = Directory.GetFiles(appPath, "*.jpg").Count();
            BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
            this.ControlBox = false;

        }
        string appPath = @"G:\Code\c#\AutoEnter\AutoEnter\data";
        int dem = 0;

        void Run()
        {
            System.Threading.Thread.Sleep(50);
            Bitmap bitmap = new Bitmap(selectform.GetWidth(), selectform.GetHeight());
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(selectform.GetLocation(), Point.Empty, selectform.GetSize());
                }
                pictureBox1.Image = bitmap;
               bitmap.Save(appPath + @"\" + dem.ToString() + ".jpg", ImageFormat.Jpeg);
                dem++;
            }
        }
        #region auto enter
        //[DllImport("User32.dll")]
        //static extern int SetForegroundWindow(IntPtr point);
        //void click()
        //{
        //var dem = 0;
        //Process[] chromeInstances = Process.GetProcesses();
        //foreach (Process p in chromeInstances)
        //{
        //    if (p.ProcessName.Contains(txtGame.Text))
        //    {
        //        dem++;
        //        while (true)
        //        {
        //            SendItembyProcess(p);
        //            Thread.Sleep(5000);
        //        }
        //    }
        //}
        //}


        //private void SendItembyProcess(Process p)
        //{

        //    for (int i = 0; i < int.Parse(txtNumberSendMessager.Text); i++)
        //    {
        //        p.WaitForInputIdle();
        //        IntPtr h = p.MainWindowHandle;
        //        SetForegroundWindow(h);
        //        SendKeys.SendWait("{ENTER}");
        //        Thread.Sleep(1000);
        //    }
        //}
        #endregion
        private void Form1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Run();
            
        }
    }
}
