namespace CayleyTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSetColor = new System.Windows.Forms.Button();
            this.tb_th2 = new System.Windows.Forms.TextBox();
            this.tb_th1 = new System.Windows.Forms.TextBox();
            this.tb_per2 = new System.Windows.Forms.TextBox();
            this.tb_per1 = new System.Windows.Forms.TextBox();
            this.tb_leng = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_n = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label_Msg = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_Msg);
            this.panel2.Controls.Add(this.btnSetColor);
            this.panel2.Controls.Add(this.tb_th2);
            this.panel2.Controls.Add(this.tb_th1);
            this.panel2.Controls.Add(this.tb_per2);
            this.panel2.Controls.Add(this.tb_per1);
            this.panel2.Controls.Add(this.tb_leng);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tb_n);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDraw);
            this.panel2.Location = new System.Drawing.Point(488, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 425);
            this.panel2.TabIndex = 1;
            // 
            // btnSetColor
            // 
            this.btnSetColor.Location = new System.Drawing.Point(126, 262);
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Size = new System.Drawing.Size(100, 23);
            this.btnSetColor.TabIndex = 14;
            this.btnSetColor.Text = "点击选择";
            this.btnSetColor.UseVisualStyleBackColor = true;
            this.btnSetColor.Click += new System.EventHandler(this.btnSetColor_Click);
            // 
            // tb_th2
            // 
            this.tb_th2.Location = new System.Drawing.Point(126, 220);
            this.tb_th2.Name = "tb_th2";
            this.tb_th2.Size = new System.Drawing.Size(100, 21);
            this.tb_th2.TabIndex = 13;
            this.tb_th2.Text = "20";
            // 
            // tb_th1
            // 
            this.tb_th1.Location = new System.Drawing.Point(126, 178);
            this.tb_th1.Name = "tb_th1";
            this.tb_th1.Size = new System.Drawing.Size(100, 21);
            this.tb_th1.TabIndex = 12;
            this.tb_th1.Text = "30";
            // 
            // tb_per2
            // 
            this.tb_per2.Location = new System.Drawing.Point(126, 138);
            this.tb_per2.Name = "tb_per2";
            this.tb_per2.Size = new System.Drawing.Size(100, 21);
            this.tb_per2.TabIndex = 11;
            this.tb_per2.Text = "0.7";
            // 
            // tb_per1
            // 
            this.tb_per1.Location = new System.Drawing.Point(126, 97);
            this.tb_per1.Name = "tb_per1";
            this.tb_per1.Size = new System.Drawing.Size(100, 21);
            this.tb_per1.TabIndex = 10;
            this.tb_per1.Text = "0.6";
            // 
            // tb_leng
            // 
            this.tb_leng.Location = new System.Drawing.Point(126, 58);
            this.tb_leng.Name = "tb_leng";
            this.tb_leng.Size = new System.Drawing.Size(100, 21);
            this.tb_leng.TabIndex = 9;
            this.tb_leng.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "画笔颜色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "左分支角度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "右分支角度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "左分支长度比";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "右分支长度比";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "主干长度";
            // 
            // tb_n
            // 
            this.tb_n.Location = new System.Drawing.Point(126, 19);
            this.tb_n.Name = "tb_n";
            this.tb_n.Size = new System.Drawing.Size(100, 21);
            this.tb_n.TabIndex = 2;
            this.tb_n.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "递归深度";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(151, 349);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 450);
            this.panel1.TabIndex = 2;
            // 
            // label_Msg
            // 
            this.label_Msg.AutoSize = true;
            this.label_Msg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Msg.Location = new System.Drawing.Point(12, 310);
            this.label_Msg.Name = "label_Msg";
            this.label_Msg.Size = new System.Drawing.Size(51, 20);
            this.label_Msg.TabIndex = 15;
            this.label_Msg.Text = "提示：";
            this.label_Msg.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_th2;
        private System.Windows.Forms.TextBox tb_th1;
        private System.Windows.Forms.TextBox tb_per2;
        private System.Windows.Forms.TextBox tb_per1;
        private System.Windows.Forms.TextBox tb_leng;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_n;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label_Msg;
    }
}

