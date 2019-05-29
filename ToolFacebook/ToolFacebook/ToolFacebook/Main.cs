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
            var strart1 = checkboxStart.Checked;
            var start2 = checkBoxRieng.Checked;
            if (strart1 == true && start2 == true)
            {
                MessageBox.Show("Chỉ được chọn 1 chế độ");
                checkBoxRieng.Checked = false;
            }
            else if (strart1)
            {
                MessageBox.Show("Bắt đầu với chế độ mặc định.Tất cả các tài khoản được chọn sẽ đăng chung 1 bài viết");
            }


        }
        private void Start2()
        {
            var listUser = new FileManagerUser().GetListUser();
            if (listUser.Count == 0)
            {
                if (MessageBox.Show("Chưa thêm tài khoản đăng bài.Cần thêm tài khoản ngay", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new AddUser().ShowDialog();

                }
            }
            else
            {

            }
        }


        private void Start1()
        {
            var selectUser = new SelectUser();
            selectUser.ShowDialog();
            var listUser = selectUser.ListUserIsSelected;
            if (listUser.Count == 0)
            {
                if (MessageBox.Show("Chưa chọn tài khoản đăng bài.Cần chọn tài khoản ngay", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    selectUser = new SelectUser();
                    selectUser.ShowDialog();
                    listUser = selectUser.ListUserIsSelected;
                }
            }
            else
            {
                var selectPost = new SelectPost();
                selectPost.ShowDialog();
                var listPost = selectPost.ListPostIsSelected;
                if (listPost.Count == 0)
                {
                    if (MessageBox.Show("Chưa có bài viết nào được thêm vào.Thêm bài viết luôn", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        new AddPost().ShowDialog();
                    }
                }
                else
                {
                    int dem = 0;
                    var listWork = new List<WorkList>();
                    foreach (var user in listUser)
                    {
                        var selectGroups = new SelectGroups(user);
                        selectGroups.ShowDialog();
                        var groups = selectGroups.ListGroupsIsSelected;
                        listWork.Add(new WorkList(user, listPost, groups, dem));
                    }
                    foreach (var work in listWork)
                    {
                        foreach (var post in listPost)
                        {
                            var chrome = new GoogleChrome(false);
                            chrome.PostInGroups(work.User, post, work.Groups);
                            chrome.Driver.Close();
                        }
                    }
                }

            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddUser().ShowDialog();
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
