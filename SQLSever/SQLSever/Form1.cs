using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLSever
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=WIN-50GP30FGO75;Initial Catalog=Demodb;User ID=sa;Password=demol23";
            conn = new SqlConnection(connetionString);
            var xx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=U:\Code\SQLSever\SQLSever\Student.mdf;Integrated Security=True");
            xx.Open();
            var table = new DataTable();
            using (var da = new SqlDataAdapter("SELECT Name FROM Students", @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=U:\Code\SQLSever\SQLSever\Student.mdf;Integrated Security=True"))
            {
                da.Fill(table);
            }
            string sql = "Select Id,Name,Old,class from Students";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = xx;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                MessageBox.Show(reader.GetInt32(0).ToString()+"  "+reader.GetInt32(1).ToString());
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // Chỉ số của cột Emp_ID trong câu lệnh SQL.
                        int empIdIndex = reader.GetOrdinal("id"); // 0


                        long empId = Convert.ToInt64(reader.GetValue(0));
                        string empNo = reader.GetString(1);
                        int empNameIndex = reader.GetOrdinal("Emp_Name");// 2
                        string empName = reader.GetString(empNameIndex);

                    }
                    
                }
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.studentDataSet.Students);

        }
    }
}
