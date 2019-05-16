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
    public partial class PostManager : Form
    {
        private FileManager FileManager { get;  set; }

        public PostManager()
        {
            InitializeComponent();
            checkPost();
        }

        private void CreateGrbPost(List<Post> listPost)
        {
            dataGrbPost.ColumnCount = 2;
            dataGrbPost.Columns[0].Name = "bài viết";
            dataGrbPost.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrbPost.Columns[1].Name = "Ảnh\video";
            dataGrbPost.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach(var post in listPost)
            {
                dataGrbPost.Rows.Add(new string[] { post.TextPost,"bấm vào để xem ảnh/video"});
            }
            MessageBox.Show("Để chình sửa bài viết vui lòng bấm click chuột vào bài viết ", "Hướng dẫn");
        }

        private void checkPost()
        {
            li = new FileManager();
            if (ListPost.Count == 0)
            {
                if (MessageBox.Show("Chưa có bài viết nào được thêm vào.Bạn có muốn thêm ngay bây giờ không", "thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new CreatePost().Show();
                }
                else
                {
                    MessageBox.Show("Cần đóng mục này lại vì không có gì để xử lý cả.", "Thông báo");
                }
            }
            else
            {
                CreateGrbPost(ListPost);
            };
        }

        private void dataGrbPost_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dataGrbPost.CurrentCell.RowIndex;
            var row = dataGrbPost.Rows[Index];
            var post = new Post(row.Cells[0].Value.ToString());
            post.ImgPost=
            var changeUser = new ChangePost(post);
            changeUser.ShowDialog();
            if (changeUser.RemoveUser == true)
            {
                new FileManager().ChangeListUser(post);
                dataGrbPost.Rows.RemoveAt(Index);
            }
        }
    }
}
