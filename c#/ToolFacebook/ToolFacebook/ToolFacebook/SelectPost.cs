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
    public partial class SelectPost : Form
    {
        private ListPost listpost;

        public ListPost ListPostIsSelected { get; private set; }

        public SelectPost()
        {
            InitializeComponent();
            ListPostIsSelected = new ListPost();
            selectObjPost.GetName(" bài viết để đăng");
            if (new FileManagerPost().GetListPost().ListP.Count == 0)
            {
                if (MessageBox.Show("Chưa thêm đăng bài.Cần thêm  ngay", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new AddPost().ShowDialog();
                }
                else this.Close();
            }
            else
            {
                this.listpost =new FileManagerPost().GetListPost();
                selectObjPost.SetListPostInForm(listpost);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cần bấm vào Chọn xong để hoàn thành quá trình chọn bài đăng", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Close();
            }
        }

        private void btnAccep_Click(object sender, EventArgs e)
        {
             ListPostIsSelected = selectObjPost.CheckAll() ?new FileManagerPost().GetListPost() : selectObjPost.SetListPostChecked();
            //if (selectObjPost.CheckAll() == false)
            //    this.ListPostIsSelected = selectObjPost.SetListPostChecked();
            //else
            //    ListPostIsSelected =new ListPost( new FileManagerPost().GetListPost());
            this.Close();
        }
    }
}
