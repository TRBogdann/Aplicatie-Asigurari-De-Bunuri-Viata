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
        public Form4(Utilizator user,Sesiune sesiune)
        {
            InitializeComponent();
            this.user = user;
            this.sesiune1 = sesiune;
            label1.Text = user.ToString();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.SessionModel.delete(string.Format("id_sesiune = '{0}'",this.sesiune1.Id));
            Sesiune.emptySession("sesiune.xml");
            this.DialogResult = DialogResult.Abort;
        }
    }
}
