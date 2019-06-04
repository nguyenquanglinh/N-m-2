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
    public partial class UserManager : Form
    {
        public ListUser ListUser { get; private set; }

        public UserManager()
        {
            InitializeComponent();
            this.AcceptButton = btnMo;
            this.CancelButton = btnDong;

        }

        public UserManager(ListUser listUser) : this()
        {
            this.ListUser = listUser;
            if (ListUser.ListU.Count != 0)
                CreateGrb(ListUser);
            else
            {
                if (MessageBox.Show("chưa có User nào được thêm vào.Bạn có muốn thêm ngay bây giờ không", "thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    new AddUser().Show();
            }
        }

        private void CreateGrb(ListUser listUser)
        {
            if (listUser.ListU.Count != 0)
            {
                GrbListUser.ColumnCount = 3;
                GrbListUser.Columns[0].Name = "Tên tài khoản";
                GrbListUser.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                GrbListUser.Columns[1].Name = "Mật khẩu";
                GrbListUser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                GrbListUser.Columns[2].Name = "Thông tin tài khoản";
                GrbListUser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                foreach (var user in listUser.ListU)
                {
                    GrbListUser.Rows.Add(new string[] { user.UserName, user.PassWord, user.CheckUserIsTrue = "đúng" });
                }
            }
             
            
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            CellClick(1);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CellClick(int index)
        {
            var row = GrbListUser.Rows[index];
            var userChange = new User(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
            var changeUser = new ChangeUser(userChange);
            changeUser.ShowDialog();
            ListUser.ListU[index] = changeUser.User;
            if (changeUser.RemoveUser == true)
            {
                GrbListUser.Rows.RemoveAt(index);
                ListUser.ListU.RemoveAt(index);
            }
            new FileManagerUser().SaveListUser(ListUser);
        }

        private void GrbListUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = GrbListUser.CurrentCell.RowIndex;
            CellClick(index);
        }
    }
}
