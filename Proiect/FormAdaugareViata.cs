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
    public partial class FormAdaugareViata : Form
    {
        Utilizator user;
        public FormAdaugareViata(Utilizator user)
        {
            InitializeComponent();
            this.user = user;
        }
        private int genId()
        {
            int id = -1;
            List<FormObject> list = Form1.AsigurareModel.select(new AsigurareViata().ParentTable());
            foreach (FormObject obs in list)
            {
                if (id <= ((AsigurareViata)obs).Id_asigurare)
                    id = ((AsigurareViata)obs).Id_asigurare;
            }
            return id + 1;
        }

        private void btAdauga_Click(object sender, EventArgs e)
        {
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
            AsigurareViata v = new AsigurareViata(genId(), (char)(cbTip.Text[0] + ct), user.Id, risc);
            Form1.AsigurareModel.insert(v.ParentTable());
            Form1.AsigurareVModel.insert(v.ChildTable());
            this.DialogResult = DialogResult.OK;
        }
    }
}
