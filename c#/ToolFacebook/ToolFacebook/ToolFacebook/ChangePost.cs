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

        public ChangePost(Post post) : this()
        {
            this.postForm1.PushPostInForm(post);
            MessageBox.Show("Bấm vào sửa để bắt đầu sửa bài viết ", "Hướng dẫn");
        }
        public bool SaveChage = true;
        public bool Remove { get; private set; }
        public bool Change { get; private set; }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bài viết của bạn sẽ được sửa khi bạn thoát.Ban có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Change = true;
                NewPost = postForm1.PopPostOutForm();
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Remove = true;
            if (MessageBox.Show("bài viết của bạn sẽ được xóa khi bạn thoát.Ban có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn cần lưu trước khi thoát.Yes nếu bạn không muốn thay đổi bài viết ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                SaveChage = false;
            }
        }
    }


}
