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
    public partial class AddPost : Form
    {
        public AddPost()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var post = postForm1.PopPostOutForm();
            if (post != null)
            {
                if (new FileManagerPost().CheckPostInList(post))
                    MessageBox.Show("Bài viết đã tồn tại trên máy không cần thêm nữa");
                else
                {
                    new FileManagerPost().SaveOncePost(post);
                    if (MessageBox.Show("Thêm bài viết thành công, bạn có muốn thêm tiếp không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        postForm1.Clear();
                    }
                }

            }

        }
    }
}
