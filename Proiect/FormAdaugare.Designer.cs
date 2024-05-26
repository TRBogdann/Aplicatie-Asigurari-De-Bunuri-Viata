namespace Proiect
{
    partial class FormAdaugare
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
            this.tbDenumire = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbValoare = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRisc = new System.Windows.Forms.ComboBox();
            this.cbTip = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btAdauga = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDenumire
            // 
            this.tbDenumire.Location = new System.Drawing.Point(291, 120);
            this.tbDenumire.Name = "tbDenumire";
            this.tbDenumire.Size = new System.Drawing.Size(372, 31);
            this.tbDenumire.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Denumire Bun";
            // 
            // tbValoare
            // 
            this.tbValoare.Location = new System.Drawing.Point(291, 175);
            this.tbValoare.Name = "tbValoare";
            this.tbValoare.Size = new System.Drawing.Size(372, 31);
            this.tbValoare.TabIndex = 2;
            this.tbValoare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValoare_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valoare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Categorie de Risc";
            // 
            // cbRisc
            // 
            this.cbRisc.FormattingEnabled = true;
            this.cbRisc.Items.AddRange(new object[] {
            "Scazut",
            "Mediu",
            "Ridicat"});
            this.cbRisc.Location = new System.Drawing.Point(291, 239);
            this.cbRisc.Name = "cbRisc";
            this.cbRisc.Size = new System.Drawing.Size(372, 33);
            this.cbRisc.TabIndex = 6;
            // 
            // cbTip
            // 
            this.cbTip.FormattingEnabled = true;
            this.cbTip.Items.AddRange(new object[] {
            "Baza",
            "Normal",
            "Extinsa"});
            this.cbTip.Location = new System.Drawing.Point(291, 300);
            this.cbTip.Name = "cbTip";
            this.cbTip.Size = new System.Drawing.Size(372, 33);
            this.cbTip.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tip Asigurare";
            // 
            // btAdauga
            // 
            this.btAdauga.Location = new System.Drawing.Point(337, 393);
            this.btAdauga.Name = "btAdauga";
            this.btAdauga.Size = new System.Drawing.Size(267, 79);
            this.btAdauga.TabIndex = 9;
            this.btAdauga.Text = "Adauga";
            this.btAdauga.UseVisualStyleBackColor = true;
            this.btAdauga.Click += new System.EventHandler(this.btAdauga_Click);
            // 
            // FormAdaugare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1020, 608);
            this.Controls.Add(this.btAdauga);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTip);
            this.Controls.Add(this.cbRisc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbValoare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDenumire);
            this.Name = "FormAdaugare";
            this.Text = "FormAdaugare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDenumire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbValoare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRisc;
        private System.Windows.Forms.ComboBox cbTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAdauga;
    }
}