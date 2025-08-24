namespace RestaurantManagerSystem
{
    partial class ForgotPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sdt_txtbox = new System.Windows.Forms.TextBox();
            this.role_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Id_txtbox = new System.Windows.Forms.TextBox();
            this.submit_bttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fill in your info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SDT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Role";
            // 
            // sdt_txtbox
            // 
            this.sdt_txtbox.Location = new System.Drawing.Point(284, 157);
            this.sdt_txtbox.Name = "sdt_txtbox";
            this.sdt_txtbox.Size = new System.Drawing.Size(174, 20);
            this.sdt_txtbox.TabIndex = 2;
            // 
            // role_comboBox
            // 
            this.role_comboBox.FormattingEnabled = true;
            this.role_comboBox.Location = new System.Drawing.Point(284, 229);
            this.role_comboBox.Name = "role_comboBox";
            this.role_comboBox.Size = new System.Drawing.Size(121, 21);
            this.role_comboBox.TabIndex = 3;
            this.role_comboBox.SelectedIndexChanged += new System.EventHandler(this.role_comboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID";
            // 
            // Id_txtbox
            // 
            this.Id_txtbox.Location = new System.Drawing.Point(284, 193);
            this.Id_txtbox.Name = "Id_txtbox";
            this.Id_txtbox.Size = new System.Drawing.Size(174, 20);
            this.Id_txtbox.TabIndex = 2;
            // 
            // submit_bttn
            // 
            this.submit_bttn.BackColor = System.Drawing.Color.LimeGreen;
            this.submit_bttn.ForeColor = System.Drawing.SystemColors.Window;
            this.submit_bttn.Location = new System.Drawing.Point(284, 267);
            this.submit_bttn.Name = "submit_bttn";
            this.submit_bttn.Size = new System.Drawing.Size(86, 31);
            this.submit_bttn.TabIndex = 5;
            this.submit_bttn.Text = "Submit";
            this.submit_bttn.UseVisualStyleBackColor = false;
            this.submit_bttn.Click += new System.EventHandler(this.submit_bttn_Click);
            // 
            // ForgotPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.submit_bttn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.role_comboBox);
            this.Controls.Add(this.Id_txtbox);
            this.Controls.Add(this.sdt_txtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ForgotPass";
            this.Text = "Forgotpassword";
            this.Load += new System.EventHandler(this.ForgotPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sdt_txtbox;
        private System.Windows.Forms.ComboBox role_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Id_txtbox;
        private System.Windows.Forms.Button submit_bttn;
    }
}