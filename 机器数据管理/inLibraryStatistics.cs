using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 机器数据管理
{
    public partial class inLibraryStatistics : Form
    {
        data db = new data();
        public inLibraryStatistics()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strsql = "";
            strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 where 产品编号 like '%" + textBox1.Text + "%'";
            strsql += " or 产品名称 like '%" + textBox1.Text + "%'";
            strsql += " or 入库管理员 like '%" + textBox1.Text + "%'";
            strsql += " or 入库时间 like '%" + textBox1.Text + "%'";
            dt = db.getTable(strsql);
            dataGridView1.DataSource = dt;
        }

        private void 读取_Click(object sender, EventArgs e)
        {
            string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表";
            dataGridView1.DataSource = db.getTable(strsql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 order by 产品编号 asc";
                dataGridView1.DataSource = db.getTable(strsql);
            }
            if (radioButton2.Checked)
            {
                string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 order by 产品名称 asc";
                dataGridView1.DataSource = db.getTable(strsql);
            }
            if (radioButton3.Checked)
            {
                string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 order by 入库时间 asc";
                dataGridView1.DataSource = db.getTable(strsql);
            }
            if (radioButton4.Checked)
            {
                string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 order by 入库管理员 asc";
                dataGridView1.DataSource = db.getTable(strsql);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 order by 产品编号 desc";
                dataGridView1.DataSource = db.getTable(strsql);
            }
            if (radioButton2.Checked)
            {
                string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 order by 产品名称 desc";
                dataGridView1.DataSource = db.getTable(strsql);
            }
            if (radioButton3.Checked)
            {
                string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 order by 入库时间 desc";
                dataGridView1.DataSource = db.getTable(strsql);
            }
            if (radioButton4.Checked)
            {
                string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 order by 入库管理员 desc";
                dataGridView1.DataSource = db.getTable(strsql);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strsql = "select 产品编号,产品名称,入库管理员,入库时间,数量 from 入库信息表 where 入库时间 between #" + textBox2.Text + "# and #" + textBox3.Text + "#";
            dt = db.getTable(strsql);
            if (dt != null)
            {
                int sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int num = int.Parse(dt.Rows[i]["数量"].ToString());
                    sum+= num;
                }
                textBox4.Text = sum.ToString();
                dataGridView1.DataSource = dt;
            }
            else
                MessageBox.Show("请按照正确格式输入！");
        }

        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void Mouse_Click3(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
