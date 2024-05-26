namespace Proiect
{
    partial class FormAdaugareViata
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
            this.cbRisc.Location = new System.Drawing.Point(244, 111);
            this.cbRisc.Name = "cbRisc";
            this.cbRisc.Size = new System.Drawing.Size(372, 33);
            this.cbRisc.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Categorie de Risc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tip Asigurare";
            // 
            // cbTip
            // 
            this.cbTip.FormattingEnabled = true;
            this.cbTip.Items.AddRange(new object[] {
            "Baza",
            "Normal",
            "Extinsa"});
            this.cbTip.Location = new System.Drawing.Point(244, 186);
            this.cbTip.Name = "cbTip";
            this.cbTip.Size = new System.Drawing.Size(372, 33);
            this.cbTip.TabIndex = 10;
            // 
            // btAdauga
            // 
            this.btAdauga.Location = new System.Drawing.Point(279, 278);
            this.btAdauga.Name = "btAdauga";
            this.btAdauga.Size = new System.Drawing.Size(267, 79);
            this.btAdauga.TabIndex = 11;
            this.btAdauga.Text = "Adauga";
            this.btAdauga.UseVisualStyleBackColor = true;
            this.btAdauga.Click += new System.EventHandler(this.btAdauga_Click);
            // 
            // FormAdaugareViata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btAdauga);
            this.Controls.Add(this.cbTip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbRisc);
            this.Name = "FormAdaugareViata";
            this.Text = "FormAdaugareViata";
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