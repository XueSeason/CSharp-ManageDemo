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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            登录窗口 lg = new 登录窗口();
            lg.ShowDialog();
            if (Program.username == "") this.Close();
            load ld = new load();
            ld.ShowDialog();
            toolStripStatusLabel1.Text = "用户名：" + Program.username + " ,   登录时间：" + Program.logintime;
            pictureBox1.Enabled = true;
            Timer tmr = new Timer();
            tmr.Interval = 5000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
        }

        private void 填写入库产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "普通用户" || Program.root == "超级用户")
            {
                fillinStorageForm fm = new fillinStorageForm();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！请必须先登录！");
            }
        }

        private void 入库统计查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "普通用户" || Program.root == "超级用户")
            {
                inLibraryStatistics fm = new inLibraryStatistics();
            fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！请必须先登录！");
            }
            
        }

        private void 入库信息编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "超级用户")
            {
                inInforEdit fm = new inInforEdit();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！只有超级用户才可以执行此操作！");
            }
        }

        private void 填写出库产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "普通用户" || Program.root == "超级用户")
            {
                filloutStorageForm fm = new filloutStorageForm();
            fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！请必须先登录！");
            }
           
        }

        private void 出库统计查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "普通用户" || Program.root == "超级用户")
            {
                 outLibraryStatistics fm = new outLibraryStatistics();
            fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！请必须先登录！");
            }
           
        }

        private void 密码即将到期产品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "普通用户" || Program.root == "超级用户")
            {
               passwordForm fm = new passwordForm();
            fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！请必须先登录！");
            }
            
        }

        private void 出库信息编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "超级用户")
            {
                outInforEdit fm = new outInforEdit();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！只有超级用户才可以执行此操作！");
            }
        }

        private void 注册管理员帐号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "超级用户")
            {
                RegisteredAccount fm = new RegisteredAccount();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！只有超级用户才可以执行此操作！");
            }
        }

        private void 删除管理员帐号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "超级用户")
            {
                DeletedAccount fm = new DeletedAccount();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！只有超级用户才可以执行此操作！");
            }
        }

        private void 查看所有管理员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.root == "超级用户")
            {
                AllAccountInfo fm = new AllAccountInfo();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您的权限有限！只有超级用户才可以执行此操作！");
            }
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Diagnostics.Process.Start(@Application.StartupPath + "\\机器数据管理.exe");
        }
    }
}
