using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace 机器数据管理
{
    public partial class 登录窗口 : Form
    {
        public 登录窗口()
        {
            InitializeComponent();     
        }
        Form splashForm; // 弹出窗口
        data account = new data();

        /// <summary>
        /// 窗体动画函数    注意：要引用System.Runtime.InteropServices;
        /// </summary>
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        /// <returns></returns>
        [DllImport("User32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = account.getTable("select * from 管理员信息表 where 用户名='" + textBox1.Text.Replace(" ", "").Replace("'", "") + "' ");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("用户名不存在！");
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["密码"].ToString() != textBox2.Text)
                        MessageBox.Show("密码错误！");
                    else
                    {
                        Program.username = textBox1.Text;
                        Program.logintime = DateTime.Now.ToString();
                        Program.root = dt.Rows[0]["使用权限"].ToString();                   
                        this.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 登录窗口_Load(object sender, EventArgs e)
        {
            splashForm = new Form();
            splashForm.Width = 800;
            splashForm.Height = 600;

            splashForm.BackgroundImage = Image.FromFile(@"弹出框.jpg"); // 载入图片
            splashForm.BackgroundImageLayout = ImageLayout.Stretch;
            splashForm.FormBorderStyle = FormBorderStyle.None;
            splashForm.StartPosition = FormStartPosition.CenterScreen;
            splashForm.Opacity = 0;
            splashForm.Show();
            for (int i = 1; i <= 20; ++i)
            { // 实现渐变效果
                splashForm.Opacity = i / 20.0;
                System.Threading.Thread.Sleep(50);
            }
            System.Threading.Thread.Sleep(1000);
            splashForm.Close();


            //int x = Screen.PrimaryScreen.WorkingArea.Left - this.Width;
            //int y = Screen.PrimaryScreen.WorkingArea.Top - this.Height;
            //this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            //AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
        }

        private void 登录窗口_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
        }
    }
}
