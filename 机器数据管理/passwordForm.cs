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
    public partial class passwordForm : Form
    {
        public passwordForm()
        {
            InitializeComponent();
        }
        data db = new data();
        private void passwordForm_Load(object sender, EventArgs e)
        {
            string strsql = "select * from 出库信息表 where (datediff('d',出库时间,now()) between 175 and 180) or (datediff('d',出库时间,now()) between 355 and 360) or (datediff('d',出库时间,now()) between 535 and 540)";
            dataGridView1.DataSource = db.getTable(strsql);
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
                string str = dataGridView1.Rows[e.RowIndex].Cells["出库时间"].Value.ToString();
                DateTime dt = Convert.ToDateTime(str);
                TimeSpan span = DateTime.Now.Subtract(dt);
                int dayDiff = span.Days;
                textBox8.Text = dayDiff.ToString();
                密码1.Text = dataGridView1.Rows[e.RowIndex].Cells["密码1"].Value.ToString();
                密码2.Text = dataGridView1.Rows[e.RowIndex].Cells["密码2"].Value.ToString();
                密码3.Text = dataGridView1.Rows[e.RowIndex].Cells["密码3"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strsql = "select * from 出库信息表 where 产品编号='" + 编号.Text + "'";
            dataGridView1.DataSource = db.getTable(strsql);
        }
    }
}
