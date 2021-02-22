using System;
using System.Windows.Forms;

namespace Myproject
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //this.Hide();
            Addbook add = new Addbook();
            add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            ViewBook add = new ViewBook();
            add.Show();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issueBook add = new issueBook();
            add.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void addbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Addbook add = new Addbook();
            add.Show();
        }

        private void showBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ViewBook add = new ViewBook();
            add.Show();

        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            //this.Hide();
            Addstudent add = new Addstudent();
            add.Show();
        }

        private void studentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            StudentInfo add = new StudentInfo();
            add.Show();
        }

        private void returnBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReturnBooks add = new ReturnBooks();
            add.Show();
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void completeBookDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Book_details bds = new Book_details();
            bds.Show();
        }
    }
}
