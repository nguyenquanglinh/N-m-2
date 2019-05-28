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

        public UserManager()
        {
            InitializeComponent();
            CheckUser();
        }
        private void CheckUser()
        {
            var ListUser = new FileManagerUser().GetListUser();
            MessageBox.Show("Cần " + (ListUser.Count * 15).ToString() + " s để kiểm tra tất cả user, vui lòng chờ ", "Thông báo");
            new GoogleChrome(true).checkListUser(ListUser);
            CreateGrb(ListUser);
        }
        private void CreateGrb(List<User> listUser)
        {
            if (listUser.Count == 0)
            {
                if (MessageBox.Show("Chưa có tài khoản nào được thêm vào.Bạn có muốn thêm vào ngay bây giờ không ?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new AddUser().ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có gì để xử lý,mục này cần được đóng lại", "Thông báo");
                }
            }
            else
            {
                GrbListUser.ColumnCount = 3;
                GrbListUser.Columns[0].Name = "User Name";
                GrbListUser.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                GrbListUser.Columns[1].Name = "Pass Word";
                GrbListUser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                GrbListUser.Columns[2].Name = "Check User is True";
                GrbListUser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                foreach (var user in listUser)
                {
                    GrbListUser.Rows.Add(new string[] { user.UserName, user.PassWord, user.CheckUserIsTrue });
                }
            }

        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            ////chuaw lamf gif
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrbListUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = GrbListUser.CurrentCell.RowIndex;
            var row = GrbListUser.Rows[Index];
            var userChange = new User(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
            var changeUser = new ChangeUser(userChange);
            changeUser.ShowDialog();
            if (changeUser.RemoveUser == true)
            {
                new FileManagerUser().RomoveUserInListAffterSaveNewListUser(userChange);
                GrbListUser.Rows.RemoveAt(Index);
            }
        }
    }
}
