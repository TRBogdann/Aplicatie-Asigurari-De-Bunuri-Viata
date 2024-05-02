using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Google.Protobuf.Collections;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;

namespace Proiect
{
    public class Utilizator : FormObject
    {
        private string id;
        private string nume;
        private string passHash;
        private string prenume;
        private string user;
        private char sex;
        private string email;
        private double salariu;
        private DateTime data_nastere;
        private string telefon;
        private string genId()
        {
            Random rdr = new Random();
            int mul = rdr.Next(100, 999);
            id = "U" + nume[0].ToString() + prenume[0].ToString() + sex.ToString();
            DateTime date = DateTime.Now;
            id += date.Day.ToString() + date.Month.ToString() + date.Year.ToString().Substring(2) + date.Hour.ToString() + date.Minute.ToString();
            id += mul.ToString();
            return id;
        }
        public static string genHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string passwordHash = Convert.ToBase64String(hashBytes);
            return passwordHash;
        }

        public override MapField<string, string> fieldValue()
        {
            MapField<string, string> map = new MapField<string, string>();
            map.Add("id_utilizator", id);
            map.Add("nume", nume);
            map.Add("prenume", prenume);
            map.Add("username", user);
            map.Add("pass_hash", passHash);
            map.Add("email", email);
            map.Add("telefon", telefon);
            map.Add("data_nastere", data_nastere.ToString("yyyy/MM/dd"));
            map.Add("salariul", salariu.ToString());
            map.Add("sex", sex.ToString());
            return map;
        }

        public static bool checkPassword(string savedHash,string password)
        {

            byte[] hashBytes = Convert.FromBase64String(savedHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }
        public override FormObject genObject(MapField<string, string> fieldValue)
        {
            FormObject u = new Utilizator();
            ((Utilizator)u).Id = fieldValue["id_utilizator"];
            ((Utilizator)u).Email = fieldValue["email"];
            ((Utilizator)u).Nume = fieldValue["nume"];
            ((Utilizator)u).Prenume = fieldValue["prenume"];
            ((Utilizator)u).PassHash = fieldValue["pass_hash"];
            ((Utilizator)u).Salariul = Convert.ToDouble(fieldValue["salariul"]);
            ((Utilizator)u).Data_nastere = DateTime.Parse(fieldValue["data_nastere"]);
            ((Utilizator)u).User = fieldValue["username"];
            ((Utilizator)u).Sex = fieldValue["sex"][0];
            ((Utilizator)u).Telefon = fieldValue["telefon"];
            return u;
        }
        public Utilizator()
        {
            this.id = "";
            this.salariu = 0.0f;
            this.email = "";
            this.nume = "";
            this.prenume = "";
            this.sex = 'M';
            this.telefon = "";
            this.user = "";
            this.passHash = "";
            this.data_nastere = DateTime.Now;
        }

        public Utilizator(string nume, string password, string prenume, string user, char sex, string email, double salariu, DateTime data_nastere, string telefon) : base()
        {
            
            this.nume = nume;
            this.prenume = prenume;
            this.user = user;
            this.sex = sex;
            this.email = email;
            this.salariu = salariu;
            this.data_nastere = data_nastere;
            this.telefon = telefon;
            this.id = genId();
            this.passHash = genHash(password);
        }
        public static Utilizator UtilizatorExistent(string id,string nume, string passHash, string prenume, string user, char sex, string email, double salariu, DateTime data_nastere, string telefon)
            {
            Utilizator u = new Utilizator();
            u.id = id;
            u.nume = nume;
            u.passHash = passHash;
            u.prenume = prenume;
            u.user = user;
            u.sex = sex;
            u.email = email;
            u.salariu = salariu;
            u.data_nastere = data_nastere;
            u.telefon = telefon;
            return u;
            }
        public string Id
       {
            set { id = value; }
            get { return id; }
        }
        public string User
        {
            set { user = value; }
            get { return user; }
        }
        public string PassHash
        {
            set { passHash = value; }
            get { return passHash; }
        }
        public string Nume
        {
            set { nume = value; }
            get { return nume; }
        }
        public string Prenume
        {
            set { prenume = value; }
            get { return prenume; }
        }
        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        public string Telefon
        {
            set { telefon = value; }
            get { return telefon; }
        }
        public char Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        public DateTime Data_nastere
        {
            set { data_nastere = value; }
            get { return data_nastere; }
        }
        public double Salariul
        {
            set { salariu = value; }
            get { return salariu; }
        }
        override public string ToString()
        {
            return "Id: " + this.Id + " User: " + this.User + " Nume: " + this.Nume + " Prenume: " + this.Prenume +
                " Hash: " + this.passHash + " Sex: " + this.sex.ToString() + " Email: " + this.Email +" Telefon: " + this.telefon +
                " Salariul: "+this.salariu+" Data: "+this.data_nastere;
        }
    }
}
