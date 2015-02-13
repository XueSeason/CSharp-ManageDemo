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
    public partial class AllAccountInfo : Form
    {
        public AllAccountInfo()
        {
            InitializeComponent();
        }
        data db = new data();
        private void AllAccountInfo_Load(object sender, EventArgs e)
        {
            string strsql = "select * from 管理员信息表 where 使用权限='普通用户'";
            dataGridView1.DataSource = db.getTable(strsql);
        }
    }
}
