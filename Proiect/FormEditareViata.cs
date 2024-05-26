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
    public partial class FormEditareViata : Form
    {
        Asigurare a;
        public FormEditareViata(Asigurare a)
        {
            InitializeComponent();
            this.a = a;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            if(a.Tip_asigurare == 'b')
            {
                AsigurareBunuri old = (AsigurareBunuri)a;
                AsigurareBunuri b = new AsigurareBunuri(old.Id_asigurare, (char)(cbTip.Text[0] + ct), old.Id_utilizator, old.Denumire_bun, old.Valoare, risc);
                Form1.AsigurareBModel.update(b.ChildTable(),new string[]{"istoric_defectiuni"},"id_asigurare="+b.Id_asigurare.ToString());
                Form1.AsigurareModel.update(b.ParentTable(),new string[] { "cost_calculat", "acoperire" }, "id_asigurare=" + b.Id_asigurare.ToString());
            }
            else
            {
                AsigurareViata old = (AsigurareViata)a;
                AsigurareViata v = new AsigurareViata(old.Id_asigurare, (char)(cbTip.Text[0] + ct), old.Id_utilizator, risc);
                Form1.AsigurareVModel.update(v.ChildTable(), new string[] { "istoric_afectiuni" }, "id_asigurare=" + v.Id_asigurare.ToString());
                Form1.AsigurareModel.update(v.ParentTable(), new string[] { "cost_calculat", "acoperire" }, "id_asigurare=" + v.Id_asigurare.ToString());
            }
            DialogResult = DialogResult.OK;
        }
    }
}
