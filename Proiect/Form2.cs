using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Proiect
{
    public partial class Form2 : Form
    {
        string pass1 = "";
        string pass2 = "";
        public Form2()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void is_user_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void is_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '\b');
        }

        private void is_nume_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) &&  (e.KeyChar != '\b') && (e.KeyChar != ' ');
        }

        private void is_prenume_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && (e.KeyChar != '\b') && (e.KeyChar != ' ');
        }

        private void is_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void is_telefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && (e.KeyChar != '\b');
        }

        private void is_pass1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';

        }

        private void is_pass2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';

        }

        private void is_sex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 'M' || e.KeyChar == 'F' && is_sex.Text.Length < 1) && e.KeyChar!='\b')
                e.Handled = true;
        }
        private void clearError()
        {
            errorProvider1.SetError(is_user, "");
            errorProvider1.SetError(is_nume, "");
            errorProvider1.SetError(is_prenume, "");
            errorProvider1.SetError(is_pass1, "");
            errorProvider1.SetError(is_pass2, "");
            errorProvider1.SetError(is_email, "");
            errorProvider1.SetError(is_telefon, "");
            errorProvider1.SetError(is_sex, "");
            errorProvider1.SetError(is_data, "");
            errorProvider1.SetError(is_salariul, "");
        }

        private void signup_Click(object sender, EventArgs e)
        {
            clearError();
            string emptyStr = "Campul nu a fost completat";
            bool found = false;
            if (is_user.Text.Equals(""))
            {
                errorProvider1.SetError(is_user, emptyStr);
                found = true;
            }
            if (is_nume.Text.Equals(""))
            {
                errorProvider1.SetError(is_nume, emptyStr);
                found = true;
            }
            if (is_prenume.Text.Equals(""))
            {
                errorProvider1.SetError(is_prenume, emptyStr);
                found = true;
            }
            if(is_telefon.Text.Equals(""))
            { 
                errorProvider1.SetError(is_telefon, emptyStr);
                found = true;
            }
            if (is_email.Text.Equals(""))
            { errorProvider1.SetError(is_email, emptyStr); found = true; }
            if(is_pass1.Text.Equals(""))
            { errorProvider1.SetError(is_pass1, emptyStr); found = true; }
            if (is_pass2.Text.Equals(""))
            { errorProvider1.SetError(is_pass2, emptyStr); found = true; }
            if (is_sex.Text.Equals(""))
            { errorProvider1.SetError(is_sex, emptyStr); found = true; }
            if (is_salariul.Text.Equals(""))
            { errorProvider1.SetError(is_salariul, emptyStr); found = true; }

            if (found)
                return;

            if(is_user.Text.Length<5)
            { 
                errorProvider1.SetError(is_user, "Numele Utilizatorului trebuie sa aiba mai mult de 5 caractere");
                found = true;
            }
            if (is_telefon.Text.Length < 7)
            {
                errorProvider1.SetError(is_user, "Numarul de telefon trebuie sa aiba mai mult de 7 caractere");
                found = true;
            }

            if(is_pass1.Text.Length < 8)
            {
                errorProvider1.SetError(is_pass1, "Parola trebuie sa aiba mai mult de 8 caractere");
                found = true;
            }
            if (found)
                return;
            if(Convert.ToDouble(is_salariul.Text)<1000)
            {
                errorProvider1.SetError(is_salariul, "Salariul nu poate fi mai mic de 1000 de lei");
                found = true;
            }
            DateTime date = DateTime.Parse(is_data.Text);
            DateTime youngest = DateTime.Now;
            youngest = youngest.AddYears(-18);
            if(date.CompareTo(youngest) > 0)
            {
                errorProvider1.SetError(is_data, "Utilizatorul trebuie sa aiba mai mult de 18 ani");
                found = true;
            }
            if(!is_pass1.Text.Equals(is_pass2.Text))
            {
                errorProvider1.SetError(is_pass1, "Parolele nu coincid");
                errorProvider1.SetError(is_pass2, "Parolele nu coincid");
                found = true;
            }
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|ro)$";
            if(!Regex.IsMatch(is_email.Text, regex, RegexOptions.IgnoreCase))
            {
                errorProvider1.SetError(is_email, "Email Incorect");
                found = true;
            }
            List<FormObject> users = Form1.UserModel.select(new Utilizator(),
                string.Format("username = '{0}'",is_user.Text));
            if(users.Count > 0)
            {
                errorProvider1.SetError(is_user, "Utilizator Existent");
                found = true;
            }

            if (found)
                return;
            Utilizator u = new Utilizator(is_nume.Text,is_pass1.Text,is_prenume.Text,is_user.Text,
              is_sex.Text[0],is_email.Text,Convert.ToDouble(is_salariul.Text),date,is_telefon.Text);
            Form1.UserModel.insert(u);
            MessageBox.Show("Utilizatorul a fost creat", "User created", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;
        }

        private void is_salariul_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && is_salariul.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar!='.' && (e.KeyChar != '\b');
        }
    }
}
