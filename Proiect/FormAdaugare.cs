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
    public partial class FormAdaugare : Form
    {
        private Utilizator user;
        private AsigurareBunuri asigurare;
  
        public FormAdaugare(Utilizator user)
        {
            InitializeComponent();
            this.user = user;
        }

        private int genId()
        {
            int id=-1;
           List<FormObject> list = Form1.AsigurareModel.select(new AsigurareBunuri().ParentTable());
           foreach(FormObject obs in list)
            {
                if (id <= ((AsigurareBunuri)obs).Id_asigurare)
                    id = ((AsigurareBunuri)obs).Id_asigurare;
            }
            return id+1;
        }

        private void btAdauga_Click(object sender, EventArgs e)
        {
            if (tbDenumire.Text.Equals(""))
                return;
            if (tbValoare.Text.Equals(""))
                return;
            if (cbRisc.Text.Equals(""))
                return;
            if (cbTip.Text.Equals(""))
                return;

            char risc = '0';
            if (cbRisc.Text.Equals("Mediu"))
                risc = '1';
            if (cbRisc.Text.Equals("Ridicat"))
                risc = '2';

            int ct = 'a' - 'A';
            AsigurareBunuri b = new AsigurareBunuri(genId(), (char)(cbTip.Text[0]+ct),user.Id,tbDenumire.Text,
                Convert.ToDouble(tbValoare.Text),risc);
            Form1.AsigurareModel.insert(b.ParentTable());
            Form1.AsigurareBModel.insert(b.ChildTable());
            this.DialogResult = DialogResult.OK;
        }

        private void tbValoare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;
            if (e.KeyChar == '.' && !tbValoare.Text.Contains('.'))
                return;
            e.Handled = true;
                   
        }
    }
}
