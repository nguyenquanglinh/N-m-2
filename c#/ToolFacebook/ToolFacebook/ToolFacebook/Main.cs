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
            Console.WriteLine("strat application");
            MaximizeBox = false;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("start click");
            var start1 = checkboxStart1.Checked;
            var start2 = checkBoxStart2.Checked;
            if (start1)
            {
                Console.WriteLine("start1->");
                MessageBox.Show("Bắt đầu với chế độ 1->Tất cả các tài khoản được chọn sẽ đăng chung các bài viết", "hướng dẫn");
                Start1();
            }
            else if (start2)
            {
                Console.WriteLine("start2-> ");
                MessageBox.Show("Bắt đầu với chế độ 2->Quá trình làm việc cho từng tài khoản");
                Start2();
            }
            else
            {
                throw new Exception("strart3 chưa viết");
            }
        }
        /// <summary>
        /// bắt đầu với chế độ chung bài viết khác nhóm đăng
        /// </summary>
        private void Start1()
        {
            Console.WriteLine("start1");
            MessageBox.Show("b1: Chọn các tài khoản sẽ sử dụng ", "Hướng dẫn");
            #region b1 chọn user
            var listUser = SelectUserMode1();
            if (listUser.ListU.Count == 0)
                CanhbaoTat(1);
            else
            {
                Console.WriteLine("b1:SelectUser :" + listUser.ListU.Count);
                #endregion

                #region b2 chọn bài viết <=> như user đã được chọn
                MessageBox.Show("b2: Chọn các bài viết sẽ đăng ", "Hướng dẫn");
                Console.WriteLine("b2: SelectPost: ");
                var listPost = SelectPost();
                if (listPost.ListP.Count == 0)
                {
                    CanhbaoTat(2);
                }
                else
                {
                    #endregion

                    #region b3 chọn nhóm đăng <=> chọn xong bài viết và user

                    var listWork = new List<WorkList>();
                    foreach (var user in listUser.ListU)
                    {
                        MessageBox.Show("b3: Chọn các nhóm sẽ sử dụng cho tài khoản " + user);
                        Console.WriteLine("b3: selectGroups cho " + user);
                        var selectGroups = new SelectGroups(user);
                        selectGroups.ShowDialog();
                        var groups = selectGroups.ListGroupsIsSelected;
                        if (groups.Count != 0)
                        {
                            listWork.Add(new WorkList(user, listPost, groups));
                            Console.Write("groups.Count = " + groups.Count);
                        }
                        else CanhbaoTat(3);
                    }
                    #endregion

                    #region b4 làm việc với danh sách đã tạo
                    if (listWork.Count != 0)
                        RunMode2(listWork);
                    #endregion
                }
            }
        }

        private void Start2()
        {
            Console.WriteLine("start2");
            #region b1 kiểm tra ds user có trong file
            //lấy ds user sau đó chọn cv cho từng user
            var listUser = new FileManagerUser().GetListUser();
            if (listUser.ListU.Count == 0)
            {
                Console.WriteLine("listUser.ListU.Count == 0");
                if (MessageBox.Show("Chưa thêm tài khoản đăng bài.Cần thêm tài khoản ngay", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    new AddUser().ShowDialog();
                else CanhbaoTat(1);
            }
            else
            {
                #endregion

                #region b2 Chọn từng tài khoản
                var listWork = new List<WorkList>();
                foreach (var user in listUser.ListU)
                {
                    var userSelect = SelectUserMode2(user);
                    if (userSelect.ListU.Count == 0)
                    {
                        if (MessageBox.Show("Bạn không chọn tài khoản " + user.UserName + ".Bạn có chắc chắn không.? ", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            continue;
                        }
                        else CanhbaoTat(1);
                    }
                    else
                    {
                        #endregion

                        #region b3 Chọn bài viết
                        var listPost = SelectPost();
                        if (listPost.ListP.Count == 0)
                        {
                            CanhbaoTat(1);
                        }
                        else
                        {
                            #endregion

                            #region b4 chọn nhóm
                            MessageBox.Show("kiểm tra nhóm");
                            var groups = SelectGroups(user);
                            if (groups.Count == 0)
                            {
                                CanhbaoTat(3);
                            }
                            else
                                listWork.Add(new WorkList(user, listPost, groups));
                        }
                    }
                }
                #endregion

                #region b5 chạy ds làm việc đã được tạo
                CheckRun(listWork);
                #endregion
            }
        }

        private void CheckRun(List<WorkList> listWork)
        {
            if (listWork.Count != 0)
                if (checkRunAlway.Checked == true)
                    RunMode2(listWork);
                else RunMode1(listWork);
        }

        /// <summary>
        /// với cảnh báo ==3 <=>ds group ==0 khi đó sẽ không được lưu quá trình làm việc
        /// </summary>
        /// <param name="mode">1,2 khởi động lại ct</param>
        private void CanhbaoTat(int mode)
        {
            Console.WriteLine("CanhbaoTat " + mode.ToString());
            if (MessageBox.Show("Chưa chọn tài khoản đăng bài.Cần chọn ít nhất 1 tài khoản,1 bài viết,1 nhóm để đăng bài", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                MessageBox.Show("Vui lòng chọn lại start");
            else if (mode < 3)
                CloseAll();
        }

        /// <summary>
        /// chạy liên tục
        /// </summary>
        /// <param name="managerWork"></param>
        private void RunMode2(List<WorkList> managerWork)
        {
            while (true)
            {
                try
                {
                    var chromeInstances = Process.GetProcessesByName("chrome");
                    foreach (Process p in chromeInstances)
                    { p.Kill(); Thread.Sleep(500); }
                    RunMode1(managerWork);
                    Thread.Sleep(180000);
                }
                catch { }

            }
        }
        private List<Group> SelectGroups(User user)
        {
            var selectGroups = new SelectGroups(user);
            selectGroups.ShowDialog();
            return selectGroups.ListGroupsIsSelected;
        }

        public ListUser SelectUserMode1()
        {
            Console.WriteLine("SelectUserMode1");
            var selectUser = new SelectUser(1);
            selectUser.ShowDialog();
            return selectUser.ListUserIsSelected;
        }
        public ListUser SelectUserMode2(User user)
        {
            Console.WriteLine("SelectUserMode2");
            var selectUser = new SelectUser(new ListUser(user));
            selectUser.ShowDialog();
            return selectUser.ListUserIsSelected;
        }

        private ListPost SelectPost()
        {
            var selectPost = new SelectPost();
            selectPost.ShowDialog();
            return selectPost.ListPostIsSelected;
        }
        /// <summary>
        /// chạy xong các work list thì thôi
        /// </summary>
        /// <param name="listWork"></param>
        private void RunMode1(List<WorkList> listWork)
        {
            Console.WriteLine("RunWorkList is start");
            foreach (var work in listWork)
            {
                Console.WriteLine("RunWorkList is " + work);
                foreach (var post in work.ListPost.ListP)
                {
                    var chrome = new GoogleChrome(false);
                    Console.WriteLine("chorme is strat");
                    chrome.PostInGroups(work.User, post, work.Groups);
                    chrome.Driver.Close();
                    Console.WriteLine("chrome is close");
                    Thread.Sleep(500);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Console.WriteLine("stop click");
            CloseAll();
        }

        private void CloseAll()
        {
            Console.WriteLine("CloseAll");
            this.Close();
            Environment.Exit(1);
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("AddUser is running");
            new AddUser().ShowDialog();
        }

        private void checkUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("UserManager is running");
            try
            {
                new UserManager(new FileManagerUser().GetListUser()).ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:close form UserManager " + ex);
            }
        }

        private void createPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("AddPost is running");
            new AddPost().ShowDialog();
        }

        private void checkPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("PostManager is running");
            var ListPost = new FileManagerPost().GetListPost();
            if (ListPost.ListP.Count != 0)
            {
                try
                {
                    new PostManager().ShowDialog();

                }
                catch
                {
                    Console.WriteLine("Erro:PostManager ");
                }
            }
            else
            {
                if (MessageBox.Show("Chưa có bài viết nào được thêm vào.Bạn có muốn thêm ngay bây giờ không", "thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    new AddPost().Show();
            }
        }

        private void checkBoxStart2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("start2 click");
            checkboxStart1.Checked = !checkBoxStart2.Checked;
        }
    }
}
