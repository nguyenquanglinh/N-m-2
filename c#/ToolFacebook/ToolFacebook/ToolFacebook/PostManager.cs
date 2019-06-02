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
        private List<Post> ListPost { get; set; }

        public PostManager()
        {
            InitializeComponent();
            checkPost();
        }

        private void CreateGrbPost(List<Post> listPost)
        {
            dataGrbPost.ColumnCount = 3;
            dataGrbPost.Columns[0].Name = "stt";
            dataGrbPost.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGrbPost.Columns[1].Name = "Bài viết";
            dataGrbPost.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrbPost.Columns[2].Name = "Số lượng ảnh";
            dataGrbPost.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            var Stt = 0;
            foreach (var post in listPost)
            {
                post.Stt = Stt;
                dataGrbPost.Rows.Add(new string[] { Stt.ToString(),post.TextPost, post.ImgPost.Count.ToString() });
                Stt++;
            }
            MessageBox.Show("Để chình sửa bài viết vui lòng bấm click chuột vào bài viết ", "Hướng dẫn");
        }

        private void checkPost()
        {
            this.ListPost = new FileManagerPost().GetListPost();
            CreateGrbPost(ListPost);
        }

        private Post GetPostSelect(int stt)
        {
            var post = new Post();
            foreach (var posts in this.ListPost)
            {
                if (posts.Stt == stt)
                {
                    return post = posts;
                }
            }
            return post;
        }




        private void dataGrbPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dataGrbPost.CurrentCell.RowIndex;
            var row = dataGrbPost.Rows[Index];
            var post = GetPostSelect(Index);
            var changePost = new ChangePost(post);
            changePost.ShowDialog();
            if (changePost.Change == true)
                post = changePost.NewPost;
            else if (changePost.Remove == true)
            {
                dataGrbPost.Rows.RemoveAt(Index);
                ListPost.RemoveAt(Index);
            }
            new FileManagerPost().RomovePostInListAffterSaveNewListPost(ListPost);
        }
    }
}
