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
        public bool Close { get; private set; }

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

        private bool PathImgIsError = false;
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
                {
                    btn.BackgroundImage = Image.FromFile(file);
                    grbImg.Controls.Add(btn);
                }
                else
                {
                    MessageBox.Show("ảnh không còn tồn tại trên máy nữa cần sửa lại ngay", "Cảnh báo");
                    PathImgIsError = true;
                }

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
            if (Post.ImgPost.Count != 0 || string.IsNullOrWhiteSpace(Post.TextPost)==false)
            {

                var postFile = new FileManagerPost();
                if (postFile.CheckPostInList(Post))
                {
                    MessageBox.Show("Bài viết đã tồn tại trên máy không cần thêm nữa");
                }
                else
                {
                    postFile.SaveOncePost(Post);
                    if (MessageBox.Show("Thêm bài viết thành công, bạn có muốn thêm tiếp không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        this.Close = true;
                    }
                }
                this.txtTextPost.Text = "";
                this.grbImg.Controls.Clear();
            }
            else if (MessageBox.Show("bài viết không được để trắng,thêm bài viết ngay", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                MessageBox.Show("không có gì để lưu :(");
                this.Close = true;
            }
        }

        public void SetPost(Post post)
        {
            this.txtTextPost.Text = post.TextPost;
            CreatePostImg(post.ImgPost);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close = true;
        }
    }
}
