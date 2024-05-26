namespace Proiect
{
    partial class Form4
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asigurareDeViataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asigurareDeBunuriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btEdit = new System.Windows.Forms.Button();
            this.viewAsigurari1 = new Proiect.ViewAsigurari();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.adaugaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1376, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(121, 40);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // loToolStripMenuItem
            // 
            this.loToolStripMenuItem.Name = "loToolStripMenuItem";
            this.loToolStripMenuItem.Size = new System.Drawing.Size(317, 44);
            this.loToolStripMenuItem.Text = "Info";
            this.loToolStripMenuItem.Click += new System.EventHandler(this.loToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(317, 44);
            this.logOutToolStripMenuItem.Text = "Log Out (ctrl+q)";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // adaugaToolStripMenuItem
            // 
            this.adaugaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asigurareDeViataToolStripMenuItem,
            this.asigurareDeBunuriToolStripMenuItem});
            this.adaugaToolStripMenuItem.Name = "adaugaToolStripMenuItem";
            this.adaugaToolStripMenuItem.Size = new System.Drawing.Size(105, 40);
            this.adaugaToolStripMenuItem.Text = "Creaza";
            // 
            // asigurareDeViataToolStripMenuItem
            // 
            this.asigurareDeViataToolStripMenuItem.Name = "asigurareDeViataToolStripMenuItem";
            this.asigurareDeViataToolStripMenuItem.Size = new System.Drawing.Size(358, 44);
            this.asigurareDeViataToolStripMenuItem.Text = "Asigurare de Viata";
            this.asigurareDeViataToolStripMenuItem.Click += new System.EventHandler(this.asigurareDeViataToolStripMenuItem_Click);
            // 
            // asigurareDeBunuriToolStripMenuItem
            // 
            this.asigurareDeBunuriToolStripMenuItem.Name = "asigurareDeBunuriToolStripMenuItem";
            this.asigurareDeBunuriToolStripMenuItem.Size = new System.Drawing.Size(358, 44);
            this.asigurareDeBunuriToolStripMenuItem.Text = "Asigurare de Bunuri";
            this.asigurareDeBunuriToolStripMenuItem.Click += new System.EventHandler(this.asigurareDeBunuriToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 42);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(158, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btEdit
            // 
            this.btEdit.AllowDrop = true;
            this.btEdit.Location = new System.Drawing.Point(461, 650);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(412, 124);
            this.btEdit.TabIndex = 4;
            this.btEdit.Text = "Drag Here to Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.DragDrop += new System.Windows.Forms.DragEventHandler(this.btEdit_DragDrop);
            this.btEdit.DragEnter += new System.Windows.Forms.DragEventHandler(this.btEdit_DragEnter);
            // 
            // viewAsigurari1
            // 
            this.viewAsigurari1.AllowDrop = true;
            this.viewAsigurari1.ContextMenuStrip = this.contextMenuStrip1;
            this.viewAsigurari1.Location = new System.Drawing.Point(271, 151);
            this.viewAsigurari1.Name = "viewAsigurari1";
            this.viewAsigurari1.Size = new System.Drawing.Size(763, 447);
            this.viewAsigurari1.TabIndex = 2;
            this.viewAsigurari1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewAsigurari1_MouseDown);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1376, 810);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.viewAsigurari1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form4";
            this.Text = "Form4";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asigurareDeViataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asigurareDeBunuriToolStripMenuItem;
        private ViewAsigurari viewAsigurari1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btEdit;
    }
}