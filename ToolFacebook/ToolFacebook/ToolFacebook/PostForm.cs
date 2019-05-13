using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ToolFacebook
{
    public partial class PostForm : UserControl
    {
        public PostForm()
        {
            InitializeComponent();
        }

        private void btnOpenImg_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog.FilterIndex = 9;
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var maxWith = this.Width;
                    var maxHeight = this.Height - this.GrbText.Height;
                    var listFile = openFileDialog.FileNames;
                    int ox = 0;
                    int oy = 150;
                    foreach (var file in listFile)
                    {
                        var btn = new Button()
                        {
                            Width = 100,
                            Height = 100,
                            Location = new Point(ox, oy),
                            BackgroundImageLayout = ImageLayout.Stretch,
                            BackgroundImage = Image.FromFile(file),
                        };
                        this.Controls.Add(btn);
                        ox += 100;
                        if (ox > maxWith)
                        {
                            oy += 100;
                            ox = 0;
                        }
                    }
                }
            }
        }
    }
}
