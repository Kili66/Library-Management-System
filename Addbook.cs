using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Myproject
{
    public partial class Addbook : Form
    {
        public Addbook()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure to exit?.", "Are you sure to Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtbookname.Text != "" && txtAuthorname.Text != "" && txtpublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                string bname = txtbookname.Text;
                string bAuth = txtAuthorname.Text;
                string bPub = txtpublication.Text;
                string bDate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 Qnt = Int64.Parse(txtQuantity.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into Table2(BookName,BookAuthor,BookPublication,BookDate,BookPrice,BookQuantity) values('" + bname + "','" + bAuth + "', '" + bPub + "', '" + bDate + "', '" + price + "', '" + Qnt + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Book Added Succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbookname.Clear();
                txtAuthorname.Clear();
                txtpublication.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Please fill the empty box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void Addbook_Load(object sender, EventArgs e)
        {

        }
    }
}
