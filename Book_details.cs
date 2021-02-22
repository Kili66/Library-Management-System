using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Myproject
{
    public partial class Book_details : Form
    {
        public Book_details()
        {
            InitializeComponent();
        }

        private void Book_details_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from Table4 where book_returndate is null ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            cmd.CommandText = "select * from Table4 where book_returndate is not null ";
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView2.DataSource = ds1.Tables[0];
         
        }
    }
}
