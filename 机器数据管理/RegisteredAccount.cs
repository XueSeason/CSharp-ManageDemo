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
    public partial class RegisteredAccount : Form
    {
        public RegisteredAccount()
        {
            InitializeComponent();
        }
        data db = new data();
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "insert into 管理员信息表(用户名,密码,联系电话,使用权限) values('" + textBox1.Text.Replace(" ", "").Replace("'", "") + "'";
            strsql = strsql + ",'" + textBox2.Text + "'";
            strsql = strsql + ",'" + textBox4.Text + "'" + ",'普通用户'";
            strsql = strsql + ")";
            db.execSql(strsql);
            this.Close();
        }

        private void TextChange(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                label5.Text = "密码不一致";
            }
            else
            {
                label5.ForeColor = System.Drawing.Color.Green;
                label5.Text = "密码一致";
            }
        }

        private void AccountChanghed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getTable("select * from 管理员信息表 where 用户名='" + textBox1.Text.Replace(" ", "").Replace("'", "") + "' ");
            if (dt.Rows.Count == 0)
            {
                label6.Text = "有效的用户名√";
            }
            else
            {
                label6.ForeColor = System.Drawing.Color.Red;
                label6.Text = "用户名已存在！";
            }
        }
    }
}
