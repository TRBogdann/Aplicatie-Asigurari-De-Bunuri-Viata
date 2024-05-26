using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Proiect
{
    public partial class FormGrafic : Form
    {
        List<AsigurareBunuri> ab;
        AsigurareViata av;
        Bitmap memoryImage;
        public void InitChart()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            Series series = new Series("Costuri");
            Series series1 = new Series("Grupe de Risc");
            Series series2 = new Series("Tip Asigurare");

            double s = 0.0;
            int[] grupeDeRisc = new int[] {0,0,0 };
            int[] grupeDeAcoperire = new int[] { 0, 0, 0 };
            foreach (AsigurareBunuri m in ab)
            {
                series.Points.AddXY(m.Denumire_bun,m.Cost_calculat);
                s += m.Cost_calculat;
                switch(m.Acoperire)
                {
                    case 'n':
                        grupeDeAcoperire[1]++;
                        break;
                    case 'e':
                        grupeDeAcoperire[2]++;
                        break;
                    default:
                        grupeDeAcoperire[0]++;
                        break;
                }
                switch(m.Istoric_defectiuni)
                {
                    case '1':
                        grupeDeRisc[1]++;
                        break;
                    case '2':
                        grupeDeRisc[2]++;
                        break;
                    default:
                        grupeDeRisc[0]++;
                        break;
                }
            }
            if (av != null)
            {
                series.Points.AddXY("Asigurare Viata", av.Cost_calculat);
                switch (av.Acoperire)
                {
                    case 'n':
                        grupeDeAcoperire[1]++;
                        break;
                    case 'e':
                        grupeDeAcoperire[2]++;
                        break;
                    default:
                        grupeDeAcoperire[0]++;
                        break;
                }
                switch (av.Istoric_afectiuni)
                {
                    case '1':
                        grupeDeRisc[1]++;
                        break;
                    case '2':
                        grupeDeRisc[2]++;
                        break;
                    default:
                        grupeDeRisc[0]++;
                        break;
                }
            }
                s += av.Cost_calculat;


            
            series.Points.AddXY("Total", s);


            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


            series1.Points.AddXY("Scazut", grupeDeRisc[0]);
            series1.Points.AddXY("Moderat", grupeDeRisc[1]);
            series1.Points.AddXY("Ridicat", grupeDeRisc[2]);

            series2.Points.AddXY("De baza", grupeDeAcoperire[0]);
            series2.Points.AddXY("Normal", grupeDeAcoperire[1]);
            series2.Points.AddXY("Extins", grupeDeAcoperire[2]);

            chart2.Series.Add(series1);
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart3.Series.Add(series2);
            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

        }
        public FormGrafic(List<AsigurareBunuri> ab, AsigurareViata av)
        {
            InitializeComponent();
            this.ab = ab;
            this.av = av;
            InitChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }



        private void print_Document(object sender, EventArgs e)
        {
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height);
            this.DrawToBitmap(memoryImage, new Rectangle(this.ClientRectangle.X + 100, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height));
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.Print();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            print_Document(sender, e);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
