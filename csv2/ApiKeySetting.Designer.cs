
namespace WalletMiddleware
{
    partial class ApiKeySetting
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSiYao = new System.Windows.Forms.TextBox();
            this.tbGongYao = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnJIeMi = new System.Windows.Forms.Button();
            this.tbGongYaoMi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnCopy);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbSiYao);
            this.groupBox3.Controls.Add(this.tbGongYao);
            this.groupBox3.Location = new System.Drawing.Point(18, 248);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 254);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ApiKey设置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "私钥";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(452, 157);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(103, 30);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(167, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 39);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "公钥";
            // 
            // tbSiYao
            // 
            this.tbSiYao.Location = new System.Drawing.Point(143, 158);
            this.tbSiYao.Name = "tbSiYao";
            this.tbSiYao.PasswordChar = '*';
            this.tbSiYao.Size = new System.Drawing.Size(303, 25);
            this.tbSiYao.TabIndex = 1;
            // 
            // tbGongYao
            // 
            this.tbGongYao.Location = new System.Drawing.Point(143, 104);
            this.tbGongYao.Name = "tbGongYao";
            this.tbGongYao.Size = new System.Drawing.Size(412, 25);
            this.tbGongYao.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnJIeMi);
            this.groupBox2.Controls.Add(this.tbGongYaoMi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbPwd);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 216);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Api密文解析";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label3.Location = new System.Drawing.Point(23, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "获取API密请打开APP>我的>设置>ApiKey中获取";
            // 
            // btnJIeMi
            // 
            this.btnJIeMi.Location = new System.Drawing.Point(326, 156);
            this.btnJIeMi.Name = "btnJIeMi";
            this.btnJIeMi.Size = new System.Drawing.Size(230, 39);
            this.btnJIeMi.TabIndex = 0;
            this.btnJIeMi.Text = "解 析";
            this.btnJIeMi.UseVisualStyleBackColor = true;
            this.btnJIeMi.Click += new System.EventHandler(this.btnJIeMi_Click);
            // 
            // tbGongYaoMi
            // 
            this.tbGongYaoMi.Location = new System.Drawing.Point(20, 59);
            this.tbGongYaoMi.Multiline = true;
            this.tbGongYaoMi.Name = "tbGongYaoMi";
            this.tbGongYaoMi.Size = new System.Drawing.Size(536, 89);
            this.tbGongYaoMi.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "交易密码";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(90, 164);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(221, 25);
            this.tbPwd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Location = new System.Drawing.Point(29, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "可以通过以上密文解析填入";
            // 
            // ApiKeySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 519);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "ApiKeySetting";
            this.Text = "配置APIKey";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSiYao;
        private System.Windows.Forms.TextBox tbGongYao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnJIeMi;
        private System.Windows.Forms.TextBox tbGongYaoMi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label1;
    }
}