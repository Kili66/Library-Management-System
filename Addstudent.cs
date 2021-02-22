using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Myproject
{
    public partial class Addstudent : Form
    {
        public Addstudent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textName.Clear();
            txtNumber.Clear();
            txtclass.Clear();
            txtDepartment.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete unsaved student information.", "Are you sure to Exit?", MessageBoxButtons.YesNo , MessageBoxIcon.Warning);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" && txtNumber.Text != "" && txtDepartment.Text != "" && txtclass.Text != "" && txtPhone.Text != "" && txtEmail.Text != "")
            {
                string name = textName.Text;
                string number = txtNumber.Text;
                string dep = txtDepartment.Text;
                string clss = txtclass.Text;
                Int64 phone = Int64.Parse(txtPhone.Text);
                string mail = txtEmail.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=KILIBECH99\\SQLEXPRESS; database= Mydatabase;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into Table3(StudentName,StudentNumber,Department,Class,PhoneNumber,Email) values('" + name + "','" + number + "', '" + dep + "', '" + clss + "', '" + phone + "', '" + mail + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please fill the empty box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Addstudent_Load(object sender, EventArgs e)
        {

        }
    }
}
