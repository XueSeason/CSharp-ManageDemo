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
    public partial class outInforEdit : Form
    {
        public outInforEdit()
        {
            InitializeComponent();
        }
        data db = new data();
        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "select * from 出库信息表";
            dataGridView1.DataSource = db.getTable(strsql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strsql = "insert into 出库信息表(产品编号,产品名称,出库管理员,出库时间,客户名,客户地址,客户联系电话,密码1,密码2,密码3,数量) values('" + textBox1.Text + "'";
            strsql = strsql + ",'" + textBox2.Text + "'";
            strsql = strsql + ",'" + textBox3.Text + "'";
            strsql = strsql + ",'" + textBox4.Text + "'";
            strsql = strsql + ",'" + textBox5.Text + "'";
            strsql = strsql + ",'" + textBox6.Text + "'";
            strsql = strsql + ",'" + textBox7.Text + "'";
            strsql = strsql + ",'" + textBox8.Text + "'";
            strsql = strsql + ",'" + textBox9.Text + "'";
            strsql = strsql + ",'" + textBox10.Text + "'";
            strsql = strsql + ",'" + textBox11.Text + "'";
            strsql = strsql + ")";             
            db.execSql(strsql);
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strsql = "delete from 出库信息表  where 产品编号='" + textBox1.Text + "'";
            db.execSql(strsql);
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strsql = "update 出库信息表 set 产品编号='" + textBox1.Text + "'";
            strsql = strsql + ",产品名称='" + textBox2.Text + "'";
            strsql = strsql + ",出库管理员='" + textBox3.Text + "'";
            strsql = strsql + ",出库时间='" + textBox4.Text + "'";
            strsql = strsql + ",客户名='" + textBox5.Text + "'";
            strsql = strsql + ",客户地址='" + textBox6.Text + "'";
            strsql = strsql + ",客户联系电话='" + textBox7.Text + "'";
            strsql = strsql + ",密码1='" + textBox8.Text + "'";
            strsql = strsql + ",密码2='" + textBox9.Text + "'";
            strsql = strsql + ",密码3='" + textBox10.Text + "'";
            strsql = strsql + ",数量='" + textBox11.Text + "'";
            strsql = strsql + " where 产品编号='" + textBox1.Text + "'";
            db.execSql(strsql);
            button1_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strsql = "";
            strsql = "select * from 出库信息表 where 产品编号='" + 查询.Text + "'";
            strsql += " or 产品名称= '" + 查询.Text + "'";
            strsql += " or 出库管理员= '" + 查询.Text + "'";
            //strsql += " or 出库时间= '" + 查询.Text + "'";
            strsql += " or 客户名= '" + 查询.Text + "'";
            strsql += " or 客户地址= '" + 查询.Text + "'";
            strsql += " or 客户联系电话= '" + 查询.Text + "'";
            strsql += " or 密码1= '" + 查询.Text + "'";
            strsql += " or 密码2= '" + 查询.Text + "'";
            strsql += " or 密码3= '" + 查询.Text + "'";
            strsql += " or 数量= '" + 查询.Text + "'";
            dt = db.getTable(strsql);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strsql = "";
            strsql = "select * from 出库信息表 where 产品编号 like '%" + 查询.Text + "%'";
            strsql += " or 产品编号 like '%" + 查询.Text + "%'";
            strsql += " or 产品名称 like '%" + 查询.Text + "%'";
            strsql += " or 出库管理员 like '%" + 查询.Text + "%'";
            strsql += " or 出库时间 like '%" + 查询.Text + "%'";
            strsql += " or 客户名 like '%" + 查询.Text + "%'";
            strsql += " or 客户地址 like '%" + 查询.Text + "%'";
            strsql += " or 客户联系电话 like '%" + 查询.Text + "%'";
            strsql += " or 密码1 like '%" + 查询.Text + "%'";
            strsql += " or 密码2 like '%" + 查询.Text + "%'";
            strsql += " or 密码3 like '%" + 查询.Text + "%'";
            strsql += " or 数量 like '%" + 查询.Text + "%'";
            dt = db.getTable(strsql);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["产品名称"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["出库管理员"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["出库时间"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["客户名"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["客户地址"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["客户联系电话"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["密码1"].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["密码2"].Value.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["密码3"].Value.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["数量"].Value.ToString();
            }
        }
    }
}
