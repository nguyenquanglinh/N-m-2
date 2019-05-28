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
    public partial class ToolFb : Form
    {
        public ToolFb()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var chrome = new GoogleChrome(false);
            var listUser = new FileManagerUser().GetListUser();
            if (listUser.Count == 0)
            {
                if (MessageBox.Show("Chưa có tài khoản nào được thêm vào.Thêm tài khoản luôn", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new AddUser();
                }
            }
            var listPost = new FileManagerPost().GetListPost();
            if (listPost.Count == 0)
            {
                if (MessageBox.Show("Chưa có bài viết nào được thêm vào.Thêm bài viết luôn", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new AddPost();
                }
            }
            foreach (var user in listUser)
            {
                foreach (var post in listPost)
                {
                    chrome.PostInGroups(user, post);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddUser().ShowDialog();
        }

        private void ToolFb_Load(object sender, EventArgs e)
        {

        }

        private void checkUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ListUser = new FileManagerUser().GetListUser();
            if (ListUser.Count != 0)
                new UserManager().ShowDialog();
            else
            {
                if (MessageBox.Show("chưa có User nào được thêm vào.Bạn có muốn thêm ngay bây giờ không", "thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new AddUser().Show();
                }
            }
        }

        private void postManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddPost().ShowDialog();
        }

        private void checkPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ListPost = new FileManagerPost().GetListPost();
            if (ListPost.Count == 0)
            {
                if (MessageBox.Show("Chưa có bài viết nào được thêm vào.Bạn có muốn thêm ngay bây giờ không", "thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    new AddPost().Show();
            }
            else new PostManager().ShowDialog();
        }
    }
}
