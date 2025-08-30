namespace RestaurantManagerSystem
{
    partial class Register
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
            this.addaccount_bttn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.role_cmbbox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password_txtbox = new System.Windows.Forms.TextBox();
            this.gmail_txtbox = new System.Windows.Forms.TextBox();
            this.sdt_txtbox = new System.Windows.Forms.TextBox();
            this.name_txtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.addaccount_bttn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.role_cmbbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.password_txtbox);
            this.panel1.Controls.Add(this.gmail_txtbox);
            this.panel1.Controls.Add(this.sdt_txtbox);
            this.panel1.Controls.Add(this.name_txtbox);
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 240);
            this.panel1.TabIndex = 0;
            // 
            // addaccount_bttn
            // 
            this.addaccount_bttn.Location = new System.Drawing.Point(102, 188);
            this.addaccount_bttn.Name = "addaccount_bttn";
            this.addaccount_bttn.Size = new System.Drawing.Size(91, 49);
            this.addaccount_bttn.TabIndex = 6;
            this.addaccount_bttn.Text = "Thêm tài khoản";
            this.addaccount_bttn.UseVisualStyleBackColor = true;
            this.addaccount_bttn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Vai trò";
            // 
            // role_cmbbox
            // 
            this.role_cmbbox.FormattingEnabled = true;
            this.role_cmbbox.Location = new System.Drawing.Point(102, 151);
            this.role_cmbbox.Name = "role_cmbbox";
            this.role_cmbbox.Size = new System.Drawing.Size(100, 21);
            this.role_cmbbox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gmail";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SDT";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ và tên";
            // 
            // password_txtbox
            // 
            this.password_txtbox.Location = new System.Drawing.Point(102, 109);
            this.password_txtbox.Name = "password_txtbox";
            this.password_txtbox.Size = new System.Drawing.Size(100, 20);
            this.password_txtbox.TabIndex = 0;
            this.password_txtbox.TextChanged += new System.EventHandler(this.password_txtbox_TextChanged);
            // 
            // gmail_txtbox
            // 
            this.gmail_txtbox.Location = new System.Drawing.Point(102, 66);
            this.gmail_txtbox.Name = "gmail_txtbox";
            this.gmail_txtbox.Size = new System.Drawing.Size(100, 20);
            this.gmail_txtbox.TabIndex = 0;
            // 
            // sdt_txtbox
            // 
            this.sdt_txtbox.Location = new System.Drawing.Point(102, 34);
            this.sdt_txtbox.Name = "sdt_txtbox";
            this.sdt_txtbox.Size = new System.Drawing.Size(100, 20);
            this.sdt_txtbox.TabIndex = 0;
            // 
            // name_txtbox
            // 
            this.name_txtbox.Location = new System.Drawing.Point(102, 6);
            this.name_txtbox.Name = "name_txtbox";
            this.name_txtbox.Size = new System.Drawing.Size(100, 20);
            this.name_txtbox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 31);
            this.label6.TabIndex = 1;
            this.label6.Text = "Register";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Return";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 325);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox name_txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gmail_txtbox;
        private System.Windows.Forms.TextBox sdt_txtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox role_cmbbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password_txtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addaccount_bttn;
        private System.Windows.Forms.Button button1;
    }
}