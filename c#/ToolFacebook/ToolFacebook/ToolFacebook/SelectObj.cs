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

        #region đặt giá trị 3 đối tượng user-post-group
        internal void SetListUseInForm(ListUser listUser)
        {
            foreach (var obj in listUser.ListU)
            {
                checkedListObj.Items.Add(obj);
            }
        }

        internal void SetListGroupInForm(List<Group> listGroups)
        {
            foreach (var obj in listGroups)
            {
                checkedListObj.Items.Add(obj);
            }
        }

        
        internal void SetListPostInForm(ListPost listPost)
        {
            foreach (var obj in listPost.ListP)
            {
                checkedListObj.Items.Add(obj);
            }
        }
        #endregion
        
        /// <summary>
        /// chọn tất cả các lựa chọn có thể
        /// </summary>
        /// <returns></returns>
        public bool CheckAll()
        {
            return checkAll.Checked;
        }


        #region lấy giá trị cho 3 đối tượng user-post-group
        public ListUser SetListUserChecked()
        {
            var listObj = new ListUser();

            foreach (User obj in checkedListObj.CheckedItems)
            {
                listObj.ListU.Add(obj);
            }
            return listObj;
        }

        public ListPost SetListPostChecked()
        {
            var listObj = new ListPost();
            foreach (Post obj in checkedListObj.CheckedItems)
            {
                listObj.ListP.Add(obj);
            }
            return listObj;
        }

        public List<Group> SetListGroupChecked()
        {
            var listObj = new List<Group>();
            foreach (Group obj in checkedListObj.CheckedItems)
            {
                listObj.Add(obj);
            }
            return listObj;
        }
        #endregion
    }
}
