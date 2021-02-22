using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Myproject
{
    public partial class StudentInfo : Form
    {
        public StudentInfo()
        {
            InitializeComponent();
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            // panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Table3";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete your unsaved data.", "Are you sure to Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sname = textSname.Text;
            Int64 snum = Int64.Parse(txtSNumber.Text);
            string sdep = txtSDepartment.Text;
            string sclass = textSClass.Text;
            Int64 sphone = Int64.Parse(txtSPhone.Text);
            string smail = txtSEmail.Text;
            if (MessageBox.Show("Student informations will be updated. Confirm?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Table3 set StudentName ='" + sname + "', StudentNumber='" + snum + "',Department='" + sdep + "',Class='" + sclass + "',PhoneNumber='" + sphone + "',Email='" + smail + "' where sId='" + rowid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                StudentInfo_Load(this, null);
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                panel2.Visible = false;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS ; database= Mydatabase;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Table3 where StudentNumber LIKE '" + textBox1.Text + "%' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }


        }
        int sid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                sid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Table3 where sId='" + sid + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            textSname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtSNumber.Text = ds.Tables[0].Rows[0][2].ToString();
            txtSDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
            textSClass.Text = ds.Tables[0].Rows[0][4].ToString();
            txtSPhone.Text = ds.Tables[0].Rows[0][5].ToString();
            txtSEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInfo_Load(this, null);
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted. Confirm?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS; database= Mydatabase; integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from Table3 where sId=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
