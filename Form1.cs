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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.registerFactorTableAdapter1.Fill(this.shop7DataSet.RegisterFactor);
            this.factorTableAdapter1.Fill(this.shop7DataSet.Factor);
            Form2 frmlogin = new Form2();
            frmlogin.ShowDialog();
            if (!frmlogin.succeeded)
                this.Close();

            goodsTableAdapter1.Fill(shop7DataSet.Goods);
            customersTableAdapter1.Fill(shop7DataSet.Customers);
            usersTableAdapter1.Fill(shop7DataSet.Users);
            factorTableAdapter1.Fill(shop7DataSet.Factor);

            factorTableAdapter1.Fill(shop7DataSet.Factor);

            int count = shop7DataSet.Factor.Rows.Count;

            if (count > 0)
            {
                factorno.Text = (int.Parse(shop7DataSet.Factor.Rows[count - 1]["FactorNo"].ToString()) + 1).ToString();
            }
            else
                factorno.Text = "1";
            gdate.Text = DateTime.Now.ToString();

            textBox14.DataBindings.Add("text", customersBindingSource, "Customer Name");

        }


        private void button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            textcname.Focus();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gname.Text = textcname.Text + " " + textcfamily.Text;
            textfccode.Text = textfccode.Text;
            tabControl1.SelectedTab = tabPage1;
            textfccode.Text = textccode.Text;
            gname.Text = textcname.Text + " " + textcfamily.Text;
            textfccode.Focus();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            textcode.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            textcode1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textname1.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textprice.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textlenght.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            textccode.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
            textcname.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
            textcfamily.Text = dataGridView2.Rows[index].Cells[2].Value.ToString();
            textcmpbile.Text = dataGridView2.Rows[index].Cells[3].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            textfcode.Text = textcode1.Text;
            gname.Text = textname1.Text;
            price.Text = textprice.Text;
            stock.Text = textlenght.Text;
            textfccode.Focus();
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (qty.TextLength == 0 || textfcode.TextLength == 0)
            {
                MessageBox.Show("کد کالا یا تعداد را وارد کنید");
                textfcode.Focus();
                return;
            }
            if (int.Parse(qty.Text) > int.Parse(stock.Text)) 
            {
                MessageBox.Show("موجودی کافی نیست");
                qty.Focus();
                return;
            }

            int n = dataGridView4.Rows.Count-1 ;
            dataGridView4.Rows.Add();
            dataGridView4.Rows[n].Cells[0].Value = textfcode.Text;
            dataGridView4.Rows[n].Cells[1].Value = gname.Text;
            dataGridView4.Rows[n].Cells[2].Value = qty.Text;
            dataGridView4.Rows[n].Cells[3].Value=price.Text ;
            dataGridView4.Rows[n].Cells[4].Value = int.Parse(price.Text) * int.Parse(qty.Text); ;
            int sum = 0;
            for (int i = 0; i < n+1; i++)
            {
                int pr = (int)dataGridView4.Rows[i].Cells[4].Value;
                sum += pr;
            }
            lsum.Text = sum.ToString();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView4.CurrentCell.RowIndex;
            if (dataGridView4.Columns[e.ColumnIndex]is DataGridViewImageColumn && e.RowIndex >=0)
            {
                dataGridView4.Rows.RemoveAt(e.RowIndex); 
            }
        }

        private void textcode1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textfcode_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (textcode.TextLength > 0)
                {
                    goodsTableAdapter1.FillBygood(shop7DataSet.Goods, int.Parse(textcode.Text));
                    if (shop7DataSet.Goods.Rows.Count > 0)
                    {
                        textcode1.Text = shop7DataSet.Goods.Rows[0]["GoodsCode"].ToString();
                        textname1.Text = shop7DataSet.Goods.Rows[0]["GoodsName"].ToString();
                        textprice.Text = shop7DataSet.Goods.Rows[0]["UnitPrice"].ToString();
                        textlenght.Text = shop7DataSet.Goods.Rows[0]["Stock"].ToString();
                    }
                }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textcode1.TextLength>0 && textname1.TextLength>0 && textprice.TextLength>0)
            {
                try
                {
                    goodsTableAdapter1.InsertQuery(int.Parse(textcode1.Text), textname1.Text, int.Parse(textprice.Text), int.Parse(textlenght.Text));
                    goodsTableAdapter1.Fill(shop7DataSet.Goods);
                    MessageBox.Show("با موفقیت ثبت شد");
                }
                catch 
                {
                    MessageBox.Show("خطا در ثبت کالا");
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string date = gdate.Text;
            int numberOfgoods = dataGridView4.Rows.Count - 1;
            if (numberOfgoods > 0)
            {
                int factorNo = int.Parse(factorno.Text);
                int customerCode = int.Parse(textfccode.Text);
                factorTableAdapter1.InsertQuery(factorNo, customerCode, date);
                for (int i = 0; i < numberOfgoods; i++)
                {
                    int goodsCode = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                    short amount = short.Parse(dataGridView4.Rows[i].Cells[2].Value.ToString());
                    registerFactorTableAdapter1.InsertQuery(factorNo, goodsCode, amount);
                   
                }
                dataGridView4.Rows.Clear();
                MessageBox.Show("فاکتور ثبت شد");

            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            customersTableAdapter1.FillBycustomer(shop7DataSet.Customers, int.Parse(textBox15.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textcode_TextChanged(object sender, EventArgs e)
        {
            goodsTableAdapter1.FillBygood(shop7DataSet.Goods,int.Parse(textcode.Text));
        }
    }
}
