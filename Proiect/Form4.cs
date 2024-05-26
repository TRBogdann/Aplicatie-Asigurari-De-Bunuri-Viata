using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace Proiect
{
    public partial class Form4 : Form
    {
        bool checker;
        private Utilizator user;
        private Sesiune sesiune1;
        private int new_id;
        List<AsigurareBunuri> asigurariBunuri = new List<AsigurareBunuri>();
        AsigurareViata asigurare = null; 

        public void RefreshView()
        {
            asigurareDeViataToolStripMenuItem.Visible = true;
            viewAsigurari1.Clear();
            asigurare = null;
            asigurariBunuri.Clear();
            List<FormObject> listAV = Form1.AsigurareModel.join(Form1.AsigurareVModel, "id_asigurare",
     new AsigurareViata().FullTable(), "id_utilizator='" + user.Id + "'");
            List<FormObject> listAB = Form1.AsigurareModel.join(Form1.AsigurareBModel, "id_asigurare",
                new AsigurareBunuri().FullTable(), "id_utilizator='" + user.Id + "'");
            if (listAV.Count > 0)
            {
                viewAsigurari1.addAsigurareViata((AsigurareViata)((Asigurare)listAV[0]));
                this.asigurare = (AsigurareViata)((Asigurare)listAV[0]);
                asigurareDeViataToolStripMenuItem.Visible = false;
              
            }
            if (listAB.Count > 0)
            {
                foreach (FormObject item in listAB)
                {
                    viewAsigurari1.addAsigurareBunuri((AsigurareBunuri)((Asigurare)item));
                    asigurariBunuri.Add((AsigurareBunuri)((Asigurare)item));
                }
            }
        }
        public Form4(Utilizator user,Sesiune sesiune)
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.user = user;
            this.sesiune1 = sesiune;
            RefreshView();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.SessionModel.delete(string.Format("id_sesiune = '{0}'",this.sesiune1.Id));
            Sesiune.emptySession("sesiune.xml");
            this.DialogResult = DialogResult.Abort;
        }

        private void asigurareDeViataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdaugareViata f = new FormAdaugareViata(user);
            f.ShowDialog();
            this.RefreshView();
        }

        private void asigurareDeBunuriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdaugare f = new FormAdaugare(user);
            f.ShowDialog();
            this.RefreshView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode t = viewAsigurari1.SelectedNode;
            if(t.Text== "Asigurare de viata")
            {
                AsigurareViata v = (AsigurareViata)t.Tag;
                Form1.AsigurareVModel.delete("id_asigurare="+v.Id_asigurare.ToString());
                Form1.AsigurareModel.delete("id_asigurare=" + v.Id_asigurare.ToString());
                RefreshView();
                return;
            }
            if(t.Parent!=null && t.Nodes.Count>0)
            {
                AsigurareBunuri b = (AsigurareBunuri)t.Tag;
                Form1.AsigurareBModel.delete("id_asigurare=" + b.Id_asigurare.ToString());
                Form1.AsigurareModel.delete("id_asigurare=" + b.Id_asigurare.ToString());
                RefreshView();
                return;
            }
            MessageBox.Show("Elementul selectat nu reprezinta un obiect de tip asigurare");
        }

        private void viewAsigurari1_MouseDown(object sender, MouseEventArgs e)
        {
            if (viewAsigurari1.SelectedNode == null)
                return;
            TreeNode t = viewAsigurari1.SelectedNode;
            if (t.Text.Equals("Asigurare de viata"))
            {
                checker = false;
                viewAsigurari1.DoDragDrop((AsigurareViata)t.Tag,DragDropEffects.Copy);
                
                return;
            }
            if (t.Parent != null && t.Nodes.Count > 0)
            {
                checker = true;
                viewAsigurari1.DoDragDrop((AsigurareBunuri)t.Tag, DragDropEffects.Copy);
                
                return;
            }
        }

        private void btEdit_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(new AsigurareViata().GetType().ToString())||
                e.Data.GetDataPresent(new AsigurareBunuri().GetType().ToString()))
            {
                e.Effect = DragDropEffects.Copy;
               return;
            }
            e.Effect = DragDropEffects.None;
        }

        private void btEdit_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Effect==DragDropEffects.Copy)
            {
                FormEditareViata f;
                if (!checker)
                {
                    Asigurare v = new AsigurareViata();
                    f = new FormEditareViata((Asigurare)e.Data.GetData(v.GetType().ToString()));
                }
                else
                {
                    Asigurare b = new AsigurareBunuri();
                    f = new FormEditareViata((Asigurare)e.Data.GetData(b.GetType().ToString()));
                }
                f.ShowDialog();
                RefreshView();
            }
        }

        private void loToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfo f = new FormInfo(asigurariBunuri,asigurare,user);
            f.ShowDialog();
        }
        protected override bool ProcessCmdKey(ref Message msg,
                                       Keys keyData)
        {
            bool handled = false;
            switch(keyData)
            {
                case Keys.Control | Keys.Q:
                    logOutToolStripMenuItem_Click(null, null);
                    handled = true;
                    break;
            }
            return handled;
        }
    }
}
