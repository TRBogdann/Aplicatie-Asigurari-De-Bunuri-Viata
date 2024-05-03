namespace Proiect
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.is_user = new System.Windows.Forms.TextBox();
            this.is_nume = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.is_prenume = new System.Windows.Forms.TextBox();
            this.is_email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.is_telefon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.is_sex = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.is_data = new System.Windows.Forms.DateTimePicker();
            this.signup = new System.Windows.Forms.Button();
            this.is_pass1 = new System.Windows.Forms.TextBox();
            this.is_pass2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.is_salariul = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // is_user
            // 
            this.is_user.Location = new System.Drawing.Point(521, 113);
            this.is_user.Multiline = true;
            this.is_user.Name = "is_user";
            this.is_user.Size = new System.Drawing.Size(392, 43);
            this.is_user.TabIndex = 1;
            this.is_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_user_KeyPress);
            this.is_user.KeyUp += new System.Windows.Forms.KeyEventHandler(this.is_user_KeyUp);
            // 
            // is_nume
            // 
            this.is_nume.Location = new System.Drawing.Point(521, 194);
            this.is_nume.Multiline = true;
            this.is_nume.Name = "is_nume";
            this.is_nume.Size = new System.Drawing.Size(392, 39);
            this.is_nume.TabIndex = 2;
            this.is_nume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_nume_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Utilizator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prenume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nume";
            // 
            // is_prenume
            // 
            this.is_prenume.Location = new System.Drawing.Point(521, 267);
            this.is_prenume.Multiline = true;
            this.is_prenume.Name = "is_prenume";
            this.is_prenume.Size = new System.Drawing.Size(392, 39);
            this.is_prenume.TabIndex = 7;
            this.is_prenume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_prenume_KeyPress);
            // 
            // is_email
            // 
            this.is_email.Location = new System.Drawing.Point(521, 347);
            this.is_email.Multiline = true;
            this.is_email.Name = "is_email";
            this.is_email.Size = new System.Drawing.Size(392, 39);
            this.is_email.TabIndex = 8;
            this.is_email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_email_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email";
            // 
            // is_telefon
            // 
            this.is_telefon.Location = new System.Drawing.Point(521, 425);
            this.is_telefon.Multiline = true;
            this.is_telefon.Name = "is_telefon";
            this.is_telefon.Size = new System.Drawing.Size(392, 39);
            this.is_telefon.TabIndex = 10;
            this.is_telefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_telefon_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Telefon";
            // 
            // is_sex
            // 
            this.is_sex.FormattingEnabled = true;
            this.is_sex.Items.AddRange(new object[] {
            "M",
            "F"});
            this.is_sex.Location = new System.Drawing.Point(521, 503);
            this.is_sex.Name = "is_sex";
            this.is_sex.Size = new System.Drawing.Size(392, 33);
            this.is_sex.TabIndex = 12;
            this.is_sex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_sex_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Sex";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 571);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Data Nastere";
            // 
            // is_data
            // 
            this.is_data.Location = new System.Drawing.Point(521, 566);
            this.is_data.Name = "is_data";
            this.is_data.Size = new System.Drawing.Size(392, 31);
            this.is_data.TabIndex = 15;
            // 
            // signup
            // 
            this.signup.Location = new System.Drawing.Point(620, 847);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(179, 63);
            this.signup.TabIndex = 16;
            this.signup.Text = "Sign up";
            this.signup.UseVisualStyleBackColor = true;
            this.signup.Click += new System.EventHandler(this.signup_Click);
            // 
            // is_pass1
            // 
            this.is_pass1.Location = new System.Drawing.Point(521, 692);
            this.is_pass1.Multiline = true;
            this.is_pass1.Name = "is_pass1";
            this.is_pass1.Size = new System.Drawing.Size(392, 39);
            this.is_pass1.TabIndex = 17;
            this.is_pass1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_pass1_KeyPress);
            // 
            // is_pass2
            // 
            this.is_pass2.Location = new System.Drawing.Point(521, 763);
            this.is_pass2.Multiline = true;
            this.is_pass2.Name = "is_pass2";
            this.is_pass2.Size = new System.Drawing.Size(392, 39);
            this.is_pass2.TabIndex = 18;
            this.is_pass2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_pass2_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 695);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Parola";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 766);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Confirma Parola";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // is_salariul
            // 
            this.is_salariul.Location = new System.Drawing.Point(521, 626);
            this.is_salariul.Multiline = true;
            this.is_salariul.Name = "is_salariul";
            this.is_salariul.Size = new System.Drawing.Size(392, 39);
            this.is_salariul.TabIndex = 21;
            this.is_salariul.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.is_salariul_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(313, 629);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 25);
            this.label10.TabIndex = 22;
            this.label10.Text = "Salariul";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 956);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.is_salariul);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.is_pass2);
            this.Controls.Add(this.is_pass1);
            this.Controls.Add(this.signup);
            this.Controls.Add(this.is_data);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.is_sex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.is_telefon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.is_email);
            this.Controls.Add(this.is_prenume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.is_nume);
            this.Controls.Add(this.is_user);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox is_user;
        private System.Windows.Forms.TextBox is_nume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox is_prenume;
        private System.Windows.Forms.TextBox is_email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox is_telefon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox is_sex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker is_data;
        private System.Windows.Forms.Button signup;
        private System.Windows.Forms.TextBox is_pass1;
        private System.Windows.Forms.TextBox is_pass2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox is_salariul;
    }
}