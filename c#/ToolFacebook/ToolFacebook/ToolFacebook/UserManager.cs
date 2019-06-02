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
        private List<User> listUser;

        public UserManager()
        {
            InitializeComponent();
            this.AcceptButton = btnMo;
            this.CancelButton = btnDong;

        }

        public UserManager(List<User> listUser) : this()
        {
            this.listUser = listUser;
            CreateGrb(listUser);
        }

        //private void CheckUser()
        //{
        //    var ListUser = new FileManagerUser().GetListUser();

        //    if (MessageBox.Show("Cần " + (ListUser.Count * 15).ToString() + " s để kiểm tra tất cả user, vui lòng chờ ", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        //new GoogleChrome(true).checkListUser(ListUser);
        //        CreateGrb(ListUser);
        //    }
        //    this.Close();
        //}
        private void CreateGrb(List<User> listUser)
        {
            //if (listUser.Count == 0)
            //{
            //    if (MessageBox.Show("Chưa có tài khoản nào được thêm vào.Bạn có muốn thêm vào ngay bây giờ không ?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        new AddUser().ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không có gì để xử lý,mục này cần được đóng lại", "Thông báo");
            //    }
            //}
            //else
            //{
            GrbListUser.ColumnCount = 3;
            GrbListUser.Columns[0].Name = "Tên tài khoản";
            GrbListUser.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GrbListUser.Columns[1].Name = "Mật khẩu";
            GrbListUser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GrbListUser.Columns[2].Name = "Thông tin tài khoản";
            GrbListUser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (var user in listUser)
            {
                GrbListUser.Rows.Add(new string[] { user.UserName, user.PassWord, user.CheckUserIsTrue = "đúng" });
            }
        }
        //}

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
            if (changeUser.RemoveUser == true)
            {
                new FileManagerUser().RomoveUserInListAffterSaveNewListUser(userChange);
                GrbListUser.Rows.RemoveAt(index);
            }
        }

        private void GrbListUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = GrbListUser.CurrentCell.RowIndex;
            CellClick(index);

        }
    }
}
