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
            var ListUser = new FileManager().Open();
            if (ListUser.Count == 0)
            {
                if (MessageBox.Show("chưa có User nào được thêm vào.Bạn có muốn thêm ngay bây giờ không", "thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new AddUser().Show();
                }
                else this.Close();
            }
            else
            {
                new GoogleChrome(true).checkListUser(ListUser);
                CreateGrb(ListUser);
            }
        }
        private void CreateGrb(List<User> listUser)
        {
            GrbListUser.ColumnCount = 3;
            GrbListUser.Columns[0].Name = "User Name";
            GrbListUser.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GrbListUser.Columns[1].Name = "Pass Word";
            GrbListUser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GrbListUser.Columns[2].Name = "Check User is True";
            GrbListUser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach(var user in listUser)
            {
                GrbListUser.Rows.Add(new string[] { user.UserName, user.PassWord, user.CheckUserIsTrue});
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
            var xx = GrbListUser.Rows[Index];
            new ChangeUser(new User(xx.Cells[0].Value.ToString(), xx.Cells[1].Value.ToString(), xx.Cells[2].Value.ToString())).ShowDialog();
        }
    }
}
