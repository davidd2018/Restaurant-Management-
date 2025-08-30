namespace RestaurantManagerSystem
{
    partial class AccountDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.name_txtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sdt_txtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mail_txtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.role_cmbbox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.return_bttn = new System.Windows.Forms.Button();
            this.edit_bttn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.empid_txtbox = new System.Windows.Forms.TextBox();
            this.accid_txtbox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.name_txtbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 41);
            this.panel1.TabIndex = 0;
            // 
            // name_txtbox
            // 
            this.name_txtbox.Location = new System.Drawing.Point(75, 10);
            this.name_txtbox.Name = "name_txtbox";
            this.name_txtbox.Size = new System.Drawing.Size(161, 20);
            this.name_txtbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sdt_txtbox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 42);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // sdt_txtbox
            // 
            this.sdt_txtbox.Location = new System.Drawing.Point(75, 13);
            this.sdt_txtbox.Name = "sdt_txtbox";
            this.sdt_txtbox.Size = new System.Drawing.Size(161, 20);
            this.sdt_txtbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "SDT";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mail_txtbox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 197);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 42);
            this.panel3.TabIndex = 3;
            // 
            // mail_txtbox
            // 
            this.mail_txtbox.Location = new System.Drawing.Point(75, 13);
            this.mail_txtbox.Name = "mail_txtbox";
            this.mail_txtbox.Size = new System.Drawing.Size(161, 20);
            this.mail_txtbox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Email";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.role_cmbbox);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 245);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 48);
            this.panel4.TabIndex = 2;
            // 
            // role_cmbbox
            // 
            this.role_cmbbox.FormattingEnabled = true;
            this.role_cmbbox.Location = new System.Drawing.Point(75, 13);
            this.role_cmbbox.Name = "role_cmbbox";
            this.role_cmbbox.Size = new System.Drawing.Size(161, 21);
            this.role_cmbbox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Vai trò";
            // 
            // return_bttn
            // 
            this.return_bttn.Location = new System.Drawing.Point(12, 314);
            this.return_bttn.Name = "return_bttn";
            this.return_bttn.Size = new System.Drawing.Size(75, 32);
            this.return_bttn.TabIndex = 4;
            this.return_bttn.Text = "Trở về";
            this.return_bttn.UseVisualStyleBackColor = true;
            // 
            // edit_bttn
            // 
            this.edit_bttn.Location = new System.Drawing.Point(186, 314);
            this.edit_bttn.Name = "edit_bttn";
            this.edit_bttn.Size = new System.Drawing.Size(72, 32);
            this.edit_bttn.TabIndex = 5;
            this.edit_bttn.Text = "Chỉnh sửa";
            this.edit_bttn.UseVisualStyleBackColor = true;
            this.edit_bttn.Click += new System.EventHandler(this.edit_bttn_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Thông tin tài khoản";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Mã nhân viên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "AcountID";
            // 
            // empid_txtbox
            // 
            this.empid_txtbox.Location = new System.Drawing.Point(87, 76);
            this.empid_txtbox.Name = "empid_txtbox";
            this.empid_txtbox.Size = new System.Drawing.Size(56, 20);
            this.empid_txtbox.TabIndex = 1;
            this.empid_txtbox.TextChanged += new System.EventHandler(this.empid_txtbox_TextChanged);
            // 
            // accid_txtbox
            // 
            this.accid_txtbox.Location = new System.Drawing.Point(202, 76);
            this.accid_txtbox.Name = "accid_txtbox";
            this.accid_txtbox.Size = new System.Drawing.Size(56, 20);
            this.accid_txtbox.TabIndex = 1;
            // 
            // AccountDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 349);
            this.Controls.Add(this.accid_txtbox);
            this.Controls.Add(this.empid_txtbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edit_bttn);
            this.Controls.Add(this.return_bttn);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AccountDetail";
            this.Text = "AccountDetail";
            this.Load += new System.EventHandler(this.AccountDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox name_txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox sdt_txtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox mail_txtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox role_cmbbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button return_bttn;
        private System.Windows.Forms.Button edit_bttn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox empid_txtbox;
        private System.Windows.Forms.TextBox accid_txtbox;
    }
}