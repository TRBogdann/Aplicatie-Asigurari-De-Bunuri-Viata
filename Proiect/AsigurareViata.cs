using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    internal class AsigurareViata : Asigurare
    {
        private char istoric_afectiuni; //0-rist scazut //1-risc mediu //2-risc mare;
        public char Istoric_afectiuni
        { get { return istoric_afectiuni; } set { istoric_afectiuni = value; } }

        public override MapField<string, string> fieldValue()
        {
            if (usingInterface == 1)
                return base.fieldValue();
            if (usingInterface == 0)
            {
                MapField<string, string> map = new MapField<string, string>();
                map.Add("id_asigurare", this.Id_asigurare.ToString());
                map.Add("istoric_afectiuni", this.istoric_afectiuni.ToString());
                return map;
            }
            MapField<string, string> map1 = base.fieldValue();
            map1.Add("id_asigurare", this.Id_asigurare.ToString());
            map1.Add("istoric_afectiuni", this.istoric_afectiuni.ToString());
            return map1;

        }
        public AsigurareViata(): base()
        {
            this.istoric_afectiuni = '0';
        }
        public AsigurareViata(int id_asigurare, char acoperire, string id_utilizator,char istoric_afectiuni):
            base(id_asigurare, 'v',acoperire, id_utilizator)
        {
            this.istoric_afectiuni = istoric_afectiuni;
            this.cost_calculat = calcul_cost();
        }
        public AsigurareViata(int id_asigurare,char istoric_afectiuni):base()
        {
            this.istoric_afectiuni = istoric_afectiuni;
            this.id_asigurare = id_asigurare;
        }
        public AsigurareViata(int id_asigurare, char acoperire, string id_utilizator)
            : base(id_asigurare, 'v', acoperire, id_utilizator)
        {
            this.istoric_afectiuni = '0';

        }

        public override FormObject genObject(MapField<string, string> fieldValue)
        {
            Asigurare a = new AsigurareViata();
            if (usingInterface == 0 || usingInterface == 2)
            {
                ((AsigurareViata)a).Id_asigurare = Convert.ToInt32(fieldValue["id_asigurare"]);
                ((AsigurareViata)a).Istoric_afectiuni = fieldValue["istoric_afectiuni"][0];
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
            // Ci-100*IA
            // I1 = 0 I2 = 0.5 I3 = 1.0
            double c;
            if (this.acoperire == 'b')
                c = 150;
            else if (this.acoperire == 'n')
                c = 250;
            else
                c = 350;
            double i = 0.5 * Convert.ToInt32(istoric_afectiuni.ToString());

            return c - 100.0f * i;
        }

        public override string ToString()
        {
            if(usingInterface == 1)
                return base.ToString();

            string risc = "scazut";

            if (istoric_afectiuni == '1')
                risc = "mediu";
            if (istoric_afectiuni == '2')
                risc = "ridicat";

            if (usingInterface == 0)
            {
                return "Asigurare de viata" + " Grad de risc " + risc;
            }

            return "Asigurare de viata" + " Cost: " + cost_calculat.ToString() + " Grad de risc " + risc;
        }
    

    }
}
