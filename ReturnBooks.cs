using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Myproject
{
    public partial class ReturnBooks : Form
    {
        public ReturnBooks()
        {
            InitializeComponent();
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            // con.Open();
            cmd.CommandText = "select * from Table4 where Std_number='" + Int64.Parse(textBoxSnum.Text) + "' and book_returndate is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            // dataGridView1.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridViewbook.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No Book Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        Int64 rowId;
        string Bkname;
        string Bookdate;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowId = Int64.Parse(dataGridViewbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                Bkname = dataGridViewbook.Rows[e.RowIndex].Cells[7].Value.ToString();
                //there is a probleme here
                Bookdate = dataGridViewbook.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtBname.Text = Bkname;
            txtIssuDate.Text = Bookdate;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update Table4 set book_returndate='" + dateTimePicker1.Text + "' where Std_number='" + textBoxSnum.Text + "' and id='" + rowId + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Book Returned  Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBoxSnum_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSnum.Text == "")
            {
                txtBname.Clear();
                txtIssuDate.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxSnum.Clear();
            //StudentInfo_Load(this, null);
           // dataGridViewbook.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure to exit?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);
            this.Close();
        }
    }
}
