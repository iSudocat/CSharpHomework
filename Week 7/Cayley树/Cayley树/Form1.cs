using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CayleyTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int n;
        double leng;
        double th1;
        double th2;
        double per1;
        double per2;
        Color ColorChoosed = System.Drawing.Color.White;

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (graphics == null)
            {
                graphics = panel1.CreateGraphics();
            }
            else
            {
                graphics.Clear(System.Drawing.Color.White);
            }

            try
            {
                n = Convert.ToInt32(tb_n.Text);
                leng = Convert.ToDouble(tb_leng.Text);
                per1 = Convert.ToDouble(tb_per1.Text);
                per2 = Convert.ToDouble(tb_per2.Text);
                th1 = Convert.ToDouble(tb_th1.Text) * Math.PI / 180;
                th2 = Convert.ToDouble(tb_th2.Text) * Math.PI / 180;
            }
            catch
            {
                label_Msg.Visible = true;
                label_Msg.Text = "提示：请输入完整的参数";
                return;
            }

            if(ColorChoosed == System.Drawing.Color.White)
            {
                label_Msg.Visible = true;
                label_Msg.Text = "提示：请选择颜色";
                return;
            }
            
            label_Msg.Visible = false;
            DrawCayleyTree(n, 200, 310, leng, -Math.PI / 2);
                
        }


        void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            DrawLine(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void DrawLine(double x0,double y0,double x1,double y1)
        {
            Pen mypen=new Pen(ColorChoosed);
            graphics.DrawLine(mypen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                //获取所选择的颜色
                ColorChoosed = colorDialog.Color;
            }

        }
    }
}
