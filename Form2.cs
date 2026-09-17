using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p17
{
    public partial class Form2 : Form
    {
        public bool succeeded;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shop7DataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.shop7DataSet.Users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            usersTableAdapter.FillByuser(shop7DataSet.Users, textBox1.Text, textBox2.Text);
            if (shop7DataSet.Users.Rows.Count > 0)
            {
                succeeded = true;
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text = "admin";
                textBox2.Text = "1234";
            }
        }
    }
}
