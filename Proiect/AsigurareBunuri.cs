using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class AsigurareBunuri : Asigurare
    {
        private string denumire_bun;
        private double valoare; // 0-5000 5000-10000 10000+
        private char istoric_defectiuni; //0-risc scazut 1-risc mediu 2-resc crescut
        public string Denumire_bun
        {
            get { return denumire_bun; }
            set { denumire_bun = value; }
        }
        public double Valoare
        {
            get { return valoare; }
            set {  valoare = value; }
        }
        public char Istoric_defectiuni
        {
            get { return istoric_defectiuni; }
            set { istoric_defectiuni = value; }
        }
        public AsigurareBunuri(int id_asigurare,string denumire_bun, double valoare, char istoric_defectiuni):base()
        {
            this.id_asigurare = id_asigurare;
            this.denumire_bun = denumire_bun;
            this.valoare = valoare;
            this.istoric_defectiuni = istoric_defectiuni;
            tip_asigurare = 'b';
        }
        public AsigurareBunuri():base()
        {
            this.denumire_bun = "";
            this.istoric_defectiuni = '0';
            this.valoare = 0.0;
            tip_asigurare = 'b';
         }
        public AsigurareBunuri(int id_asigurare, char acoperire, string id_utilizator, string denumire_bun,double valoare,char istoric_defectiuni) :
            base(id_asigurare, 'b', acoperire, id_utilizator)
        {
            this.denumire_bun = denumire_bun;
            this.istoric_defectiuni = istoric_defectiuni;
            this.valoare = valoare;
            this.cost_calculat = this.calcul_cost();
        }
        public AsigurareBunuri(int id_asigurare, char acoperire, string id_utilizator) :
            base(id_asigurare, 'b', acoperire, id_utilizator)
        {
            this.denumire_bun = "";
            this.istoric_defectiuni = '0';
            this.valoare = 0.0;
        }
        public override MapField<string, string> fieldValue()
        {
            if(usingInterface == 1)
                return base.fieldValue();
            if(usingInterface == 0)
            {
                MapField<string,string> map = new MapField<string,string>();
                map.Add("id_asigurare", id_asigurare.ToString());
                map.Add("denumire_bun", denumire_bun);
                map.Add("valoare", valoare.ToString());
                map.Add("istoric_defectiuni", istoric_defectiuni.ToString());
                return map;
            }

            MapField<string, string> map1 = base.fieldValue(); ;
            map1.Add("id_asigurare", id_asigurare.ToString());
            map1.Add("denumire_bun", denumire_bun);
            map1.Add("valoare", valoare.ToString());
            map1.Add("istoric_defectiuni", istoric_defectiuni.ToString());
            return map1;
        }

        public override FormObject genObject(MapField<string, string> fieldValue)
        {
            Asigurare a = new AsigurareBunuri();
            if (usingInterface == 0 || usingInterface == 2)
            {
                ((AsigurareBunuri)a).Id_asigurare = Convert.ToInt32(fieldValue["id_asigurare"]);
                ((AsigurareBunuri)a).Istoric_defectiuni = fieldValue["istoric_defectiuni"][0];
                ((AsigurareBunuri)a).Denumire_bun = fieldValue["denumire_bun"];
                ((AsigurareBunuri)a).Valoare = Convert.ToDouble(fieldValue["valoare"]);
            }
            if (usingInterface == 1 || usingInterface == 2)
            {
                a.Id_asigurare = Convert.ToInt32(fieldValue["id_asigurare"]);
                a.Cost_calculat = Convert.ToDouble(fieldValue["cost_calculat"]);
                a.Tip_asigurare = fieldValue["tip_asigurare"][0];
                a.Id_utilizator = fieldValue["id_utilizator"];
                a.Acoperire = fieldValue["acoperire"][0];
            }
            return (FormObject)a;
        }

        protected override double calcul_cost()
        {
            // Ci - 100*Ia - 100*Vi
            double c;
            if (this.acoperire == 'b')
                c = 150;
            else if (this.acoperire == 'n')
                c = 250;
            else
                c = 350;
            double i = 0.25 * Convert.ToInt32(istoric_defectiuni.ToString());
            double v = 0.25 * ((Math.Min(10000, Math.Abs(10000 - valoare)) / 10000));
            return c - 100.0f*v - 100.0f*i;
        }
        public override string ToString()
        {
            if(usingInterface == 1)
                return base.ToString();

            string risc = "scazut";

            if(istoric_defectiuni == '1')
                risc = "mediu";
            if (istoric_defectiuni == '2')
                risc = "ridicat";

            if(usingInterface == 0)
            {
                return "Bun: " + Denumire_bun + " cu costul " + valoare.ToString() + "Grad de risc: " + risc;
            }
            return "Asigurare de Bunuri " + "Cost: " + cost_calculat + "Bun: " + Denumire_bun + " cu costul " + valoare.ToString() + "Grad de risc: " + risc;
        }   


    }
}
