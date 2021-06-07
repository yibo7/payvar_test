namespace WalletMiddleware
{
    partial class Index
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAddrs = new System.Windows.Forms.TextBox();
            this.cbCoinList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbGuid = new System.Windows.Forms.TextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全局参数配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCoolAddress = new System.Windows.Forms.Button();
            this.txtAddrNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddrJson = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(142, 179);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(230, 39);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发 送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "币种";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "收币地址";
            // 
            // tbAddrs
            // 
            this.tbAddrs.Location = new System.Drawing.Point(112, 25);
            this.tbAddrs.Name = "tbAddrs";
            this.tbAddrs.Size = new System.Drawing.Size(371, 25);
            this.tbAddrs.TabIndex = 1;
            // 
            // cbCoinList
            // 
            this.cbCoinList.FormattingEnabled = true;
            this.cbCoinList.Location = new System.Drawing.Point(125, 88);
            this.cbCoinList.Name = "cbCoinList";
            this.cbCoinList.Size = new System.Drawing.Size(360, 23);
            this.cbCoinList.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbGuid);
            this.groupBox1.Controls.Add(this.tbAmount);
            this.groupBox1.Controls.Add(this.tbAddrs);
            this.groupBox1.Location = new System.Drawing.Point(13, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 229);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发币测试";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(112, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(294, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "订单ID具有唯一性，相同订单ID只发一次。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "订单ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "打币数量";
            // 
            // tbGuid
            // 
            this.tbGuid.Location = new System.Drawing.Point(112, 109);
            this.tbGuid.Name = "tbGuid";
            this.tbGuid.Size = new System.Drawing.Size(371, 25);
            this.tbGuid.TabIndex = 1;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(112, 71);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(371, 25);
            this.tbAmount.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 30);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全局参数配置ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 全局参数配置ToolStripMenuItem
            // 
            this.全局参数配置ToolStripMenuItem.Name = "全局参数配置ToolStripMenuItem";
            this.全局参数配置ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.全局参数配置ToolStripMenuItem.Text = "全局参数配置";
            this.全局参数配置ToolStripMenuItem.Click += new System.EventHandler(this.全局参数配置ToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAddrNum);
            this.groupBox2.Controls.Add(this.btnCoolAddress);
            this.groupBox2.Location = new System.Drawing.Point(13, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 87);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "获取充值地址";
            // 
            // btnCoolAddress
            // 
            this.btnCoolAddress.Location = new System.Drawing.Point(190, 32);
            this.btnCoolAddress.Name = "btnCoolAddress";
            this.btnCoolAddress.Size = new System.Drawing.Size(143, 30);
            this.btnCoolAddress.TabIndex = 5;
            this.btnCoolAddress.Text = "获取充值地址";
            this.btnCoolAddress.UseVisualStyleBackColor = true;
            // 
            // txtAddrNum
            // 
            this.txtAddrNum.Location = new System.Drawing.Point(92, 34);
            this.txtAddrNum.Name = "txtAddrNum";
            this.txtAddrNum.Size = new System.Drawing.Size(82, 25);
            this.txtAddrNum.TabIndex = 5;
            this.txtAddrNum.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "获取数量";
            // 
            // txtAddrJson
            // 
            this.txtAddrJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddrJson.Location = new System.Drawing.Point(3, 21);
            this.txtAddrJson.Name = "txtAddrJson";
            this.txtAddrJson.Size = new System.Drawing.Size(439, 348);
            this.txtAddrJson.TabIndex = 6;
            this.txtAddrJson.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAddrJson);
            this.groupBox3.Location = new System.Drawing.Point(518, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(445, 372);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "调用结果";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbInfo.Location = new System.Drawing.Point(21, 43);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(0, 15);
            this.lbInfo.TabIndex = 9;
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 477);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cbCoinList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Index";
            this.Text = "测试工具V1.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAddrs;
        private System.Windows.Forms.ComboBox cbCoinList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbGuid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全局参数配置ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddrNum;
        private System.Windows.Forms.Button btnCoolAddress;
        private System.Windows.Forms.RichTextBox txtAddrJson;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbInfo;
    }
}