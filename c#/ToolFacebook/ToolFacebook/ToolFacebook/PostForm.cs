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
        private Post Post { get; set; }
        public List<string> PathImg { get; private set; }

        public void PushPostInForm(Post post)
        {
            //TODO: cần kiểm tra lại các đường dẫn ảnh xèm còn tồn tại trên máy nữa không
            txtTextPost.Text = post.TextPost;
            CreatePostImg(post);
        }

        public Post PopPostOutForm()
        {

            if (string.IsNullOrWhiteSpace(txtTextPost.Text) && PathImg.Count == 0)
            {
                MessageBox.Show("bài viết không được để trắng,thêm bài viết ngay", "Cảnh báo");
                return null;
            }
            Post.TextPost = txtTextPost.Text;
            return Post;
        }



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
                        Post.ImgPost.PathImgPost = openFileDialog.FileNames.ToList();
                        CreatePostImg(Post);
                    }
                }

            }
        }

        /// <summary>
        /// dùng cho trường hợp path img sai
        /// </summary>
        private void CreatePostImg(Post post)
        {
            int ox = 0;
            int oy = 0;
            this.Post.ImgPost = post.ImgPost;
            foreach (var file in post.ImgPost.PathImgPost)
            {
                var btn = new Button()
                {
                    Width = 100,
                    Height = 100,
                    Location = new Point(ox, oy),
                    BackgroundImageLayout = ImageLayout.Stretch,
                };

                try
                {
                    btn.BackgroundImage = Image.FromFile(file);
                }
                catch
                {
                    MessageBox.Show("ảnh trong bài viết đã không còn tồn tại trên máy");
                    this.BackColor = Color.Red;
                }
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



        public bool CheckPostIsTrue(Post post)
        {
            return CheckPathExistImgPostIsTrue(post.ImgPost.PathImgPost);
        }


        private bool CheckPathExistImgPostIsTrue(List<string> imgPost)
        {
            foreach (var path in imgPost)
            {
                if (File.Exists(path) == false)
                    return false;
            }
            return true;
        }



        public void Clear()
        {
            this.txtTextPost.Text = "";
            this.grbImg.Controls.Clear();
        }

    }
}
