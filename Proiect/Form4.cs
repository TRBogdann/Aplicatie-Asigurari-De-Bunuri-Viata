using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Form4 : Form
    {
        private Utilizator user;
        private Sesiune sesiune1;
        private int new_id;
        List<AsigurareBunuri> asigurariBunuri = new List<AsigurareBunuri>();
        AsigurareViata asigurare = null; 

        public void RefreshView()
        {
            asigurareDeViataToolStripMenuItem.Visible = false;
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
                asigurareDeViataToolStripMenuItem.Visible = true;
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
            List<FormObject> listAV = Form1.AsigurareModel.join(Form1.AsigurareVModel, "id_asigurare",
                new AsigurareViata().FullTable(), "id_utilizator='" + user.Id+"'");
            List<FormObject> listAB = Form1.AsigurareModel.join(Form1.AsigurareBModel, "id_asigurare",
                new AsigurareBunuri().FullTable(), "id_utilizator='" + user.Id+"'");
            if (listAV.Count > 0)
                viewAsigurari1.addAsigurareViata((AsigurareViata)((Asigurare)listAV[0]));
            if(listAB.Count > 0)
            {
                foreach(FormObject item in listAB)
                {
                    viewAsigurari1.addAsigurareBunuri((AsigurareBunuri)((Asigurare)item));
                }
            }

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.SessionModel.delete(string.Format("id_sesiune = '{0}'",this.sesiune1.Id));
            Sesiune.emptySession("sesiune.xml");
            this.DialogResult = DialogResult.Abort;
        }
    }
}
