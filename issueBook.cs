using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Myproject
{
    public partial class issueBook : Form
    {
        public issueBook()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void issueBook_Load(object sender, EventArgs e)
        {

        }
        int count;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxStudent.Text != "")
            {
                string id = textBoxStudent.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS ; database= Mydatabase;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Table3 where StudentNumber='" + id + "' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //code to count how many book has been issued
                cmd.CommandText = "select count (Std_number) from Table4 where Std_number='" + id + "' and book_returndate is null ";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());


                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtSname.Text = ds.Tables[0].Rows[0][1].ToString();
                    textDep.Text = ds.Tables[0].Rows[0][3].ToString();
                    textClss.Text = ds.Tables[0].Rows[0][4].ToString();
                    textContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    textEmail.Text = ds.Tables[0].Rows[0][6].ToString();

                }
                else
                {
                    txtSname.Clear();
                    textDep.Clear();
                    textClss.Clear();
                    textContact.Clear();
                    textEmail.Clear();
                    MessageBox.Show("Invalid Student Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void issueBook_Load_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= KILIBECH99\\SQLEXPRESS ; database= Mydatabase;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("select BookName from Table2", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    comboBox1.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonIssue_Click(object sender, EventArgs e)
        {
            if (txtSname.Text != "")
            {
                if (comboBox1.SelectedIndex != -1 && count <= 2)
                {
                    Int64 snum = Int64.Parse(textBoxStudent.Text);
                    string sname = txtSname.Text;
                    string sdep = textDep.Text;
                    string clss = textClss.Text;
                    Int64 contact = Int64.Parse(textContact.Text);
                    string mail = textEmail.Text;
                    string Bname = comboBox1.Text;
                    string Bissuedate = dateTimePicker1.Text;
                    string ed = textBoxStudent.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source=KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into Table4(Std_number,Std_name,Std_dep,Std_class,Std_contact,Std_mail,book_name,book_Issuedate)values('" + snum + "' ,'" + sname + "','" + sdep + "','" + clss + "','" + contact + "','" + mail + "','" + Bname + "','" + Bissuedate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Book Issued Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The selected book is not available or the maximum number of book has been issued", "No book selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid student number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure to exit?.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            this.Close();
        }

        private void textBoxStudent_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStudent.Text == "")
            {
                txtSname.Clear();
                textDep.Clear();
                textClss.Clear();
                textContact.Clear();
                textEmail.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxStudent.Clear();
        }
    }
}
