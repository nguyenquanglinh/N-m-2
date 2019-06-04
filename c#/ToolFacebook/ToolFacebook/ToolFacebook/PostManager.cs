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
        private FileManager FileManager { get; set; }
        private ListPost ListPost { get; set; }

        public PostManager()
        {
            InitializeComponent();
            checkPost();
        }

        private void CreateGrbPost()
        {
            dataGrbPost.Rows.Clear();
            dataGrbPost.ColumnCount = 3;
            dataGrbPost.Columns[0].Name = "stt";
            dataGrbPost.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGrbPost.Columns[1].Name = "Bài viết";
            dataGrbPost.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrbPost.Columns[2].Name = "Số lượng ảnh";
            dataGrbPost.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            var Stt = 0;
            foreach (var post in ListPost.ListP)
            {
                post.Stt = Stt;
                dataGrbPost.Rows.Add(new string[] { Stt.ToString(), post.TextPost, post.ImgPost.PathImgPost.Count.ToString() });
                Stt++;
            }
            MessageBox.Show("Để chình sửa bài viết vui lòng bấm click chuột vào bài viết ", "Hướng dẫn");
        }

        private void checkPost()
        {
            this.ListPost = new FileManagerPost().GetListPost();
            if (ListPost.ListP.Count != 0)
            {
                CreateGrbPost();
            }
            else
            {
                if (MessageBox.Show("Chưa thêm bài viết .Cần thêm ngay", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new AddPost().ShowDialog();
                }
                else this.Close();
            }
        }

        private Post GetPostSelect(int stt)
        {
            return this.ListPost.ListP.FirstOrDefault(x => x.Stt == stt); ;
        }

        private void dataGrbPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGrbPost.CurrentCell.RowIndex;
            var row = dataGrbPost.Rows[index];
            var changePost = new ChangePost(ListPost.GetPostInList(index));
            changePost.ShowDialog();
            if (changePost.Change == true)
                ListPost.ListP[index] = changePost.NewPost;
            //TODO: chưa lưu lại post đã thay đổi
            else if (changePost.Remove == true)
                //dataGrbPost.Rows.RemoveAt(index);
                ListPost.ListP.RemoveAt(index);
            //TODO: Singleton pattern
            if (changePost.SaveChage)
            {
                new FileManagerPost().SaveListPost(ListPost);
                CreateGrbPost();
            }
        }
    }
}
