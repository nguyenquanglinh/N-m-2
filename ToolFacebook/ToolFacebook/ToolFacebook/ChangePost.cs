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
        private Post Post;

        public Post NewPost;
        public ChangePost()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public ChangePost(Post post)
        {
            this.Post = post;
            this.Enabled = false;
        }

        public bool Remove { get; private set; }
        public bool Sua { get;private set; }
        private void btnSua_Click(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.Sua = true;
            this.NewPost = this.postForm1.Post;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Remove = true;
        }
    }
}
