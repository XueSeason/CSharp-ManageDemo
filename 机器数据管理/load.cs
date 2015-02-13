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
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }

        private void load_Load(object sender, EventArgs e)
        {
            label1.Text = ("您的级别为" + Program.root+",请耐心等待载入。。。");
            Timer tmr = new Timer();
            tmr.Interval = 2000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
