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
    public partial class DeletedAccount : Form
    {
        public DeletedAccount()
        {
            InitializeComponent();
        }
        data db = new data();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["用户名"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["密码"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["联系电话"].Value.ToString();
            }
        }

        private void DeletedAccount_Load(object sender, EventArgs e)
        {
            string strsql = "select * from 管理员信息表 where 使用权限 = '普通用户'";
            dataGridView1.DataSource = db.getTable(strsql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "delete from 管理员信息表  where 用户名='" + textBox1.Text + "'";
            db.execSql(strsql);
            strsql = "select * from 管理员信息表 where 使用权限 = '普通用户'";
            dataGridView1.DataSource = db.getTable(strsql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
