using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolFacebook
{
    public partial class SelectObj : UserControl
    {
        public SelectObj()
        {
            InitializeComponent();
        }
       
        public void GetName(string name)
        {
            txtName.Text = "Chọn danh sách";
            txtName.Text += name;
        }
        internal void GetItemUser(List<User> listUser)
        {
            foreach (var obj in listUser)
            {
                checkedListObj.Items.Add(obj);
            }
        }
        internal void GetItemGroup(List<Groups> listGroups)
        {
            foreach (var obj in listGroups)
            {
                checkedListObj.Items.Add(obj);
            }
        }
        internal void GetItemPost(List<Post> listPost)
        {
            foreach (var obj in listPost)
            {
                checkedListObj.Items.Add(obj);
            }
        }

        public bool CheckAll()
        {
            return checkAll.Checked;
        }
        public List<User> SetItemCheckedUser()
        {
            var listObj = new List<User>();
            
            foreach(User obj in checkedListObj.CheckedItems)
            {
                listObj.Add(obj);
            }
            return listObj;
        }


        public List<Post> SetItemCheckedPost()
        {
            var listObj = new List<Post>();
            foreach (Post obj in checkedListObj.CheckedItems)
            {
                listObj.Add(obj);
            }
            return listObj;
        }

        public List<Groups> SetItemCheckedGroup()
        {
            var listObj = new List<Groups>();
            foreach (Groups obj in checkedListObj.CheckedItems)
            {
                listObj.Add(obj);
            }
            return listObj;
        }

    }
}
