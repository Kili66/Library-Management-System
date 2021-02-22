using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Myproject
{
    public partial class Form1 : Form
    {
     //   string cs = ConfigurationManager.ConnectionStrings = "Data source=.;Initial Catalog=Mydatabase;Integrated Security=True";
       SqlConnection con = new SqlConnection(@"Data Source=KILIBECH99\SQLEXPRESS;database=Mydatabase;Integrated Security=True");
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Logintable where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("Username or Password incorrect,Try again please!");
            }
            else
            {
                this.Hide();
                Homepage add = new Homepage();
                add.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure to exit?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
