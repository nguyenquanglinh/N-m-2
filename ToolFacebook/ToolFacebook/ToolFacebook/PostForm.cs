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
            Post = new Post();
        }
        public Post Post { get; set; }
        private void btnOpenImg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTextPost.Text) == false)
            {
                Post.TextPost = txtTextPost.Text;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    openFileDialog.FilterIndex = 10;
                    openFileDialog.Multiselect = true;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        grbImg.Controls.Clear();
                        Post.ImgPost = openFileDialog.FileNames.ToList();
                        CreatePostImg(Post.ImgPost);
                    }
                }

            }
        }

        private void CreatePostImg(List<string> imgPost)
        {
            int ox = 0;
            int oy = 0;
            foreach (var file in imgPost)
            {
                var btn = new Button()
                {
                    Width = 100,
                    Height = 100,
                    Location = new Point(ox, oy),
                    BackgroundImageLayout = ImageLayout.Stretch,
                };

                ///
                if (File.Exists(file) == true)
                    btn.BackgroundImage = Image.FromFile(file);
                else MessageBox.Show("không còn ảnh trong bài viết cần sửa lại ngay", "Cảnh báo");
                grbImg.Controls.Add(btn);
                ox += 100;
                if (ox > this.Width)
                {
                    oy += 100;
                    ox = 0;
                }
                else if (oy > this.Height)
                {
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            new FileManagerPost().SaveOncePost(Post);
            if (MessageBox.Show("Thêm bài viết thành công, bạn có muốn thêm tiếp không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Enabled = false;
                MessageBox.Show("Bấm x ở góc bên phải màn hình để đóng ", "Hướng dẫn");
            }
        }

        public void SetEnabled(bool isEnabled)
        {
            this.Enabled = isEnabled;
        }

        public void SetPost(Post post)
        {
            this.txtTextPost.Text = post.TextPost;
            CreatePostImg(post.ImgPost);
        }
    }
}
