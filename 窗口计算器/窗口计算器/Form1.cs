using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗口计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private void Add(double a, double b)
        {
            double result = a + b;
            label4.Text = "计算结果：" + Convert.ToString(result);
        }
        private void Minus(double a, double b)
        {
            double result = a - b;
            label4.Text = "计算结果：" + Convert.ToString(result);
        }
        private void Multiply(double a, double b)
        {
            double result = a * b;
            label4.Text = "计算结果：" + Convert.ToString(result);
        }
        private void Divide(double a, double b)
        {
            double result = a / b;
            label4.Text = "计算结果：" + Convert.ToString(result);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double n1 = 0, n2 = 0;
            try
            {
                n1 = Convert.ToDouble(textBox_num1.Text);
                n2 = Convert.ToDouble(textBox_num2.Text);
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "+":
                        Add(n1, n2);
                        break;
                    case "-":
                        Minus(n1, n2);
                        break;
                    case "*":
                        Multiply(n1, n2);
                        break;
                    case "/":
                        Divide(n1, n2);
                        break;
                }
            }
            catch(FormatException)
            {
               label4.Text = "错误的数字";
               return;
            }
            catch (DivideByZeroException)   //double除0不会产生此异常，故其实不需要
            {
               label4.Text = "不能除以0";
            }
            catch (OverflowException)
            {
                label4.Text = "数据溢出";
            }
        }
    }
}
