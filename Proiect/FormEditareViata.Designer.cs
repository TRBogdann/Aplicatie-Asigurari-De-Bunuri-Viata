namespace Proiect
{
    partial class FormEditareViata
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
            this.cbRisc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTip = new System.Windows.Forms.ComboBox();
            this.btAdauga = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbRisc
            // 
            this.cbRisc.FormattingEnabled = true;
            this.cbRisc.Items.AddRange(new object[] {
            "Scazut",
            "Mediu",
            "Ridicat"});
            this.cbRisc.Location = new System.Drawing.Point(260, 141);
            this.cbRisc.Name = "cbRisc";
            this.cbRisc.Size = new System.Drawing.Size(372, 33);
            this.cbRisc.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Categorie de Risc";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tip Asigurare";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cbTip
            // 
            this.cbTip.FormattingEnabled = true;
            this.cbTip.Items.AddRange(new object[] {
            "Baza",
            "Normal",
            "Extinsa"});
            this.cbTip.Location = new System.Drawing.Point(260, 198);
            this.cbTip.Name = "cbTip";
            this.cbTip.Size = new System.Drawing.Size(372, 33);
            this.cbTip.TabIndex = 11;
            // 
            // btAdauga
            // 
            this.btAdauga.Location = new System.Drawing.Point(281, 276);
            this.btAdauga.Name = "btAdauga";
            this.btAdauga.Size = new System.Drawing.Size(267, 79);
            this.btAdauga.TabIndex = 12;
            this.btAdauga.Text = "Modifica";
            this.btAdauga.UseVisualStyleBackColor = true;
            this.btAdauga.Click += new System.EventHandler(this.btAdauga_Click);
            // 
            // FormEditareViata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btAdauga);
            this.Controls.Add(this.cbTip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbRisc);
            this.Name = "FormEditareViata";
            this.Text = "FormEditareViata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRisc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTip;
        private System.Windows.Forms.Button btAdauga;
    }
}