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
    public partial class SelectGroups : Form
    {
        public List<Groups> ListGroupsIsSelected;
        private List<Groups> listGroupsIsSelected;

        public SelectGroups()
        {
            InitializeComponent();
            ListGroupsIsSelected = new List<Groups>();

        }
        public SelectGroups(User user) : this()
        {
            var chrome = new GoogleChrome(false);
            this.listGroupsIsSelected = chrome.GetAllGroup(user);
            selectObjGroups.GetItemGroup(listGroupsIsSelected);
            chrome.Driver.Close();
            selectObjGroups.GetName(" nhóm đăng cho tài khoản " + user.UserName);
        }

        private void btnAccep_Click(object sender, EventArgs e)
        {
            if (selectObjGroups.CheckAll() == false)
                ListGroupsIsSelected = selectObjGroups.SetItemCheckedGroup();
            else if (selectObjGroups.CheckAll())
                ListGroupsIsSelected = listGroupsIsSelected;
            else ListGroupsIsSelected = new List<Groups>();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cần bấm vào Chọn xong để hoàn thành quá trình chọn tài khoản đăng nhập", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
