using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            var start1 = checkboxStart.Checked;
            var start2 = checkBoxRieng.Checked;
            if (start1 == true && start2 == true)
            {
                MessageBox.Show("Chỉ được chọn 1 chế độ");
                checkBoxRieng.Checked = false;
            }
            else if (start2 == false && start1 == false)
            {
                MessageBox.Show("Cần chọn 1 chế độ để làm việc");
                checkBoxRieng.Checked = false;
            }
            else if (start1 && start2 == false)
            {
                MessageBox.Show("Bắt đầu với chế độ mặc định-Tất cả các tài khoản được chọn sẽ đăng chung 1 bài viết");
                Start1();
            }
            else if (start2 == true && start1 == false)
            {
                MessageBox.Show("Bắt đầu với chế độ riêng.Chọn quá trình làm việc cho từng tài khoản");
                Start2();
            }
        }

        private void Start2()
        {
            //lấy ds user sau đó chọn cv cho từng user
            var listUser = new FileManagerUser().GetListUser();
            if (listUser.Count == 0)
            {
                if (MessageBox.Show("Chưa thêm tài khoản đăng bài.Cần thêm tài khoản ngay", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    new AddUser().ShowDialog();
            }
            else
            {
                var managerWork = new List<WorkList>();
                foreach (var user in listUser)
                {
                    var userSelect = SelectUser(2, user);
                    if (userSelect.Count == 0)
                    {
                        if (MessageBox.Show("Bạn không chọn tài khoản này.Bạn có chắc chắn không.? " + user.UserName, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            userSelect = SelectUser(2, user);
                        }
                        if (userSelect.Count == 0) continue;
                    }
                    else
                    {
                        var listPost = SelectPost();
                        if (listPost.Count == 0)
                        {
                            if (MessageBox.Show("Chưa có bài viết được chọn để đăng cho tài khoản " + user.UserName + ".Thêm bài viết luôn", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                listPost = SelectPost();
                            }
                            if (listPost.Count == 0) continue;
                        }
                        else
                        {
                            MessageBox.Show("kiểm tra nhóm");
                            var groups = SelectGroups(user);
                            if (groups.Count == 0)
                            {
                                if (MessageBox.Show("Tài khoản chưa tham gia nhóm nào.", "Error", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    groups = SelectGroups(user);
                                }
                                if (groups.Count == 0) continue;
                            }
                            else
                                managerWork.Add(new WorkList(user, listPost, groups));
                        }
                    }
                }
                AlwayRunWorkList(managerWork);
            }
        }

        void AlwayRunWorkList(List<WorkList> managerWork)
        {

            while (true)
            {
                try
                {
                    var chromeInstances = Process.GetProcessesByName("chrome");
                    foreach (Process p in chromeInstances)
                        p.Kill();
                    RunWorkList(managerWork);
                    Thread.Sleep(180000);
                }
                catch { }

            }
        }
        private List<Groups> SelectGroups(User user)
        {
            var selectGroups = new SelectGroups(user);
            selectGroups.ShowDialog();
            return selectGroups.ListGroupsIsSelected;
        }

        private List<User> SelectUser(int mode, User user)
        {
            if (mode == 1)
            {
                var selectUser = new SelectUser(mode);
                selectUser.ShowDialog();
                return selectUser.ListUserIsSelected;
            }
            else
            {
                var selectUser = new SelectUser(new List<User>() { user });
                selectUser.ShowDialog();
                return selectUser.ListUserIsSelected;
            }
        }
        private List<Post> SelectPost()
        {
            var selectPost = new SelectPost();
            selectPost.ShowDialog();
            return selectPost.ListPostIsSelected;
        }
        private void Start1()
        {
            var listUser = SelectUser(1, new User());
            if (listUser.Count == 0)
            {
                if (MessageBox.Show("Chưa chọn tài khoản đăng bài.Cần chọn tài khoản ngay", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    listUser = SelectUser(1, new User());
                    if (listUser.Count == 0)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                var listPost = SelectPost();
                if (listPost.Count == 0)
                {

                    if (MessageBox.Show("Chưa có bài viết nào được chọn để đăng .Chọn lại ???", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        listPost = SelectPost();
                        if (listPost.Count == 0)
                            this.Close();
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
                    if (MessageBox.Show("Lưu danh quá trình làm việc cho lần sau", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //new FileManagerWorkList(listWork);
                    }
                    AlwayRunWorkList(listWork);
                }
            }
        }

        private void RunWorkList(List<WorkList> listWork)
        {
            foreach (var work in listWork)
            {
                foreach (var post in work.ListPost)
                {
                    var chrome = new GoogleChrome(false);
                    chrome.PostInGroups(work.User, post, work.Groups);
                    chrome.Driver.Close();
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
            try
            {
                var ListUser = new FileManagerUser().GetListUser();
                if (ListUser.Count != 0)
                    new UserManager().ShowDialog();
                else
                {
                    if (MessageBox.Show("chưa có User nào được thêm vào.Bạn có muốn thêm ngay bây giờ không", "thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        new AddUser().Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

        private void userManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolFb_Load(object sender, EventArgs e)
        {

        }
    }
}
