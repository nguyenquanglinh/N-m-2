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
        private List<Post> ListPost { get; private set; }

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
            dataGrbPost.Columns[1].Name = "Stt";
            dataGrbPost.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            var Stt = 0;
            foreach(var post in listPost)
            {
                post.Stt = Stt;
                dataGrbPost.Rows.Add(new string[] { post.TextPost,Stt.ToString()});
                Stt++;
            }
            MessageBox.Show("Để chình sửa bài viết vui lòng bấm click chuột vào bài viết ", "Hướng dẫn");
        }

        private void checkPost()
        {
            this.ListPost = new FileManager().GetListPost();
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

        private Post GetPostSelect(int stt)
        {
            var post = new Post();
            foreach(var posts in this.ListPost)
            {
                if (posts.Stt == stt)
                {
                    return post= posts;
                }
            }
            return post;
        }


        private void dataGrbPost_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dataGrbPost.CurrentCell.RowIndex;
            var row = dataGrbPost.Rows[Index];
            var post = GetPostSelect(Index);
           
            var changePost = new ChangePost(post);
            changePost.ShowDialog();
            if (changePost.Sua == true)
            {
                post = changePost.NewPost;
            }
            if (changePost.Remove == true)
            {
                dataGrbPost.Rows.RemoveAt(Index);
            }
            new FileManager().SaveListPost(ListPost);
        }
    }
}
