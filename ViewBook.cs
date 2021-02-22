using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Myproject
{
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewBook_Load(object sender, System.EventArgs e)
        {
            panel2.Visible = false;//to make invisible the stoolbar
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=KILIBECH99\\SQLEXPRESS; database= Mydatabase; integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Table2";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Delete your unsaved data.", "Are you sure to Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            // panel2.Visible = false;
            this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            textBook.Clear();
            panel2.Visible = false;
        }
        int Id;
        Int64 rowid;
        private void button2_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Book Informations will be updated. Confirm?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = txtbookname.Text;
                string bAuth = txtAuthorname.Text;
                string bPub = txtpublication.Text;
                string bDate = txtDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 Qnt = Int64.Parse(txtQuantity.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=KILIBECH99\\SQLEXPRESS; database= Mydatabase; integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Table2 set BookName ='" + bname + "', BookAuthor='" + bAuth + "',BookPublication='" + bPub + "',BookDate='" + bDate + "',BookPrice=" + price + ",BookQuantity=" + Qnt + " where Id=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBook.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase; integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Table2 where BookName LIKE '" + textBook.Text + "%' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=KILIBECH99\\SQLEXPRESS; database= Mydatabase; integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Table2";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=KILIBECH99\\SQLEXPRESS; database= Mydatabase; integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Table2 where Id=" + Id + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtbookname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthorname.Text = ds.Tables[0].Rows[0][2].ToString();
            txtpublication.Text = ds.Tables[0].Rows[0][3].ToString();
            txtDate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted. Confirm?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase; integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from Table2 where Id=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
