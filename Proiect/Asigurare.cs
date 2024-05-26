using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Tabel preturi CI:50-150 CII:150-250 CIII:250-350
namespace Proiect
{
    abstract public class Asigurare:FormObject
    {
        protected int id_asigurare;
        protected char tip_asigurare; //b-bunuri //v-viata
        protected double cost_calculat;
        protected char acoperire; //b-baza CI //n-normala CII //e-extins Ciii
        protected string id_utilizator;
        abstract protected double calcul_cost();

        protected int usingInterface = 0;
        public Asigurare ParentTable()
        {
            this.usingInterface = 1;
            return (Asigurare)this;
        }
        public Asigurare ChildTable()
        {
            this.usingInterface = 0;
            return (Asigurare)this;
        }
        public Asigurare FullTable()
        {
            this.usingInterface = 2;
            return (Asigurare)this;
        }

        public int Id_asigurare
        { get { return id_asigurare;} set { id_asigurare = value; } }
        public char Acoperire
        { get { return acoperire; } set {  acoperire = value; } }
        public char Tip_asigurare
        { get { return tip_asigurare; } set { tip_asigurare = value; } }
        public double Cost_calculat
        { get { return cost_calculat; } set {  cost_calculat = value; } }
        public string Id_utilizator
        { get { return id_utilizator; } set { id_utilizator = value; } }
        public Asigurare()
        {
            this.id_asigurare = 0;
            this.tip_asigurare = '\0';
            this.cost_calculat = 0.0;
            this.acoperire = 'b';
            this.id_utilizator = "";
        }
        public Asigurare(int id_asigurare,char tip_asigurare,char acoperire,string id_utilizator)
        {
            this.cost_calculat = 0.0;
            this.id_asigurare = id_asigurare;
            this.tip_asigurare = tip_asigurare;
            this.acoperire = acoperire;
            this.id_utilizator = id_utilizator;
        }
        public override MapField<string, string> fieldValue()
        {
            MapField<string, string> map = new MapField<string, string>();
            map.Add("id_asigurare", id_asigurare.ToString());
            map.Add("tip_asigurare", tip_asigurare.ToString());
            map.Add("cost_calculat", cost_calculat.ToString());
            map.Add("acoperire", acoperire.ToString());
            map.Add("id_utilizator", id_utilizator);
            return map;
        }
        public override string ToString()
        {
            string tip = tip_asigurare == 'b' ? "De Bunuri" : "De Viata";
            string acop = " de baza ";
            if (acoperire == 'n')
                acop = " normala ";
            if (acoperire == 'e')
                acop = "cextinsa ";

            return "Asigurare " + tip + acop+ "cu costul " + cost_calculat.ToString() ;

        }


    }
}
