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
    public partial class ChangePost : Form
    {

        public Post NewPost;
        public ChangePost()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public ChangePost(Post post):this()
        {
            this.postForm1.SetEnabled(false);
            this.postForm1.SetPost(post);
            MessageBox.Show("Bấm vào sửa để bắt đầu sửa bài viết ", "Hướng dẫn");
        }

        public bool Remove { get; private set; }
        public bool Change { get;private set; }
        private void btnSua_Click(object sender, EventArgs e)
        {
            this.postForm1.SetEnabled(true);
            this.Change = true;
            this.NewPost = this.postForm1.Post;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Remove = true;
            this.Close();
        }
    }
}
