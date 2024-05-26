using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI;
using Oracle.ManagedDataAccess.Client;

//  AsigurareB().ParentTable()
//  AsigurareB().FullTable()
//  AsigurareB().ChildTable()
// Model.join(Model2,field,resulting object type,filter)

namespace Proiect
{
    public partial class Form1 : Form
    {
         public static Model UserModel;
         public static Model SessionModel;
         public static Model AsigurareModel;
         public static Model AsigurareBModel;
         public static Model AsigurareVModel;
   
        string dateSesiune = "sesiune.xml";
        Database date = new Database("193.226.34.57",1521, "orclpdb.docker.internal", "TRASCAUT_65","STUD");
        private bool allowshowdisplay = false;

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        public Form1()
        {

            InitializeComponent();

            date.Connect();
            if(!date.GetError().Equals(""))
            {
                MessageBox.Show(date.GetError(), "Eroare Server", MessageBoxButtons.AbortRetryIgnore);
            }
            
            string[] userFields = {"id_utilizator","username","nume","prenume","pass_hash",
            "email","telefon","data_nastere","salariul","sex"};
            
            FieldTypeSQL[] userTypes = {FieldTypeSQL.character,FieldTypeSQL.character,FieldTypeSQL.character,FieldTypeSQL.character,
            FieldTypeSQL.character,FieldTypeSQL.character,FieldTypeSQL.character,FieldTypeSQL.date,FieldTypeSQL.numeric,FieldTypeSQL.character};
            
            string[] sessionFields = {"id_sesiune","data_conectare","ip","id_utilizator"};
            FieldTypeSQL[] sessionTypes = {FieldTypeSQL.character,FieldTypeSQL.date,FieldTypeSQL.character,FieldTypeSQL.character};

            string[] assigFields = {"id_asigurare","tip_asigurare", "cost_calculat", "acoperire", "id_utilizator" };
            FieldTypeSQL[] assigTypes = { FieldTypeSQL.numeric, FieldTypeSQL.character, FieldTypeSQL.numeric, FieldTypeSQL.character, FieldTypeSQL.character };

            string[] assigvFields = { "id_asigurare", "istoric_afectiuni" };
            FieldTypeSQL[] assigvTypes = { FieldTypeSQL.numeric, FieldTypeSQL.character };

            string[] assigbFields = { "id_asigurare", "denumire_bun", "valoare", "istoric_defectiuni" };
            FieldTypeSQL[] assigbTypes = { FieldTypeSQL.numeric, FieldTypeSQL.character, FieldTypeSQL.numeric, FieldTypeSQL.character };
            
            UserModel = new Model(date,userFields,userTypes,"c_utilizatori");
            SessionModel = new Model(date, sessionFields, sessionTypes, "c_sesiune");
            AsigurareModel = new Model(date, assigFields, assigTypes,"c_asigurari");
            AsigurareBModel = new Model(date, assigbFields, assigbTypes, "c_abunuri");
            AsigurareVModel = new Model(date, assigvFields, assigvTypes, "c_aviata");
            allowshowdisplay = false;
 
            TryLogIn();
        }
        public void TryLogIn()
        {
            if (!File.Exists(dateSesiune))
            {
                Sesiune.emptySession(dateSesiune);
            }
            Sesiune sesiune = Sesiune.restore(dateSesiune);
            int count = SessionModel.select(new Sesiune(),"id_sesiune='"+sesiune.Id+"'").Count;
            if (!sesiune.User_id.Equals("") && sesiune.Ip == Sesiune.getIpAdress() && count>0)
            {
                List<FormObject> list = UserModel.select(new Utilizator(), string.Format("id_utilizator = '{0}'", sesiune.User_id));
                Form4 mainForm = new Form4((Utilizator)list[0], sesiune);
                this.DialogResult = DialogResult.OK;
                this.allowshowdisplay = false;
                this.Hide();
                mainForm.ShowDialog();
                if (mainForm.DialogResult == DialogResult.Abort)
                {
                    allowshowdisplay = true;
                    this.Visible = true;
                }
                else
                {
                    this.Dispose();
                    this.Close();
                    Environment.Exit(0);
                }
            }
            else
            {
                Sesiune.emptySession(dateSesiune);
                allowshowdisplay = true;
                this.Visible = true;
            }
        }
         ~Form1()
        {
            date.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 signForm = new Form2();
            this.DialogResult = DialogResult.OK;
            this.Hide();
            signForm.ShowDialog();
            if (signForm.DialogResult == DialogResult.OK)
            {
                this.Visible = true;
            }
            else
                this.Close();
            

        }

        private void login_Click(object sender, EventArgs e)
        {
            if (il_pass.Text.Equals(""))
                return;
            if (il_user.Text.Equals(""))
                return;
            bool ok = true;
            string hash = Utilizator.genHash(il_pass.Text);
            List<FormObject> list = UserModel.select(new Utilizator(),string.Format("username = '{0}'",il_user.Text));
            if (list.Count > 0)
            {
                Utilizator user = (Utilizator)list[0];
                if (Utilizator.checkPassword(user.PassHash, il_pass.Text))
                {
                    Sesiune s = new Sesiune(user.Id);
                    SessionModel.insert(s);
                    s.save(dateSesiune);
                    Form4 mainForm = new Form4(user, s);
                    this.Hide();
                    mainForm.ShowDialog();
                    if (mainForm.DialogResult == DialogResult.Abort)
                    {
                        this.allowshowdisplay = true;
                        this.Show();
                    }
                    else {
                        this.Dispose();
                        this.Close();
                    }
                }
                else ok = false;
            }
            else
                ok = false;
            if(!ok)
            {
                MessageBox.Show("Utilizator inexistent sau parola incorecta", "Eroare", MessageBoxButtons.OKCancel);
            }
        }
    }
}
