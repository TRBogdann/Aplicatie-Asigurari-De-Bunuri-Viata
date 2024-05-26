using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{

    public partial class FormInfo : Form
    {
        private Font printFont;
        private PrintPreviewDialog printPreviewDialog1;
        public PrintDocument pd;
        PageSetupDialog PageSetupDialog1 = new PageSetupDialog();

        Bitmap bitmap;
        PrintDialog PrintDialog1 = new PrintDialog();

        string path = "..\\imagine.txt";
        List<AsigurareBunuri> abunuri;
        AsigurareViata av;
        Utilizator user;
        int nr_Asigurari;
        int nr_Bunuri;
        double total;
        public FormInfo(List<AsigurareBunuri> abunuri, AsigurareViata av, Utilizator user)
        {
            InitializeComponent();
            this.printPreviewDialog1 = new PrintPreviewDialog();
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(14, 0, pictureBox1.Width - 30, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;

            StreamReader fileStream = File.OpenText(path);
            string image = fileStream.ReadLine();
            if (image != null)
            {
                pictureBox1.Image = Image.FromFile(image);
            }
            fileStream.Close();
            this.abunuri = abunuri;
            this.av = av;
            this.user = user;

            total = 0;
            nr_Asigurari = 0;
            nr_Bunuri = 0;
            if (av != null) {
                nr_Asigurari = 1;
                total += av.Cost_calculat;
            }
            foreach(AsigurareBunuri ab in  abunuri)
            {
                nr_Asigurari++;
                total += ab.Cost_calculat;
            }
            label1.Text = "Nume: " + user.Nume + " " + user.Prenume;
            label2.Text = "Email: " + user.Email;
            label3.Text = "Data Nasterii: " + user.Data_nastere.ToString();
            label7.Text = "Telefon: " + user.Telefon;
            label4.Text = "Sex: " + user.Sex.ToString();
            label5.Text = "Salariul: " + user.Salariul.ToString();
            label6.Text = user.User;

            label8.Text = "Asigurare de Viata: " + (nr_Asigurari == nr_Bunuri ? "Da":"Nu");
            label9.Text = "Nr Asigurari de Bunuri" + nr_Bunuri.ToString();
            label10.Text = "Valoare Cost Lunar: " + total.ToString(); 
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("..\\ProfDefault.png");
            File.WriteAllText(path, string.Empty);
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File|*.jpg;*.jpeg;*.png";
            openFileDialog.CheckFileExists = true;
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
                StreamWriter write =new StreamWriter(path);
                write.WriteLine(imagePath);
                write.Close();
            }
        }

        private void afisareGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGrafic g = new FormGrafic(abunuri, av);
            g.ShowDialog();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {

            string linie_txt = "Date utilizator";

            SolidBrush pns = new SolidBrush(Color.Black);

            float x = 150.0F; float y = 150.0F;

            ev.Graphics.DrawString(linie_txt, printFont, pns, x, y);
            ev.HasMorePages = true;
            float linesPerPage = 0;
            float yPos = 0;
            int count = 10;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string[] date = new string[] {label6.Text,label1.Text,label2.Text,label3.Text,
            label4.Text,label5.Text,label7.Text,label8.Text,label9.Text,label10.Text};

            linesPerPage = ev.MarginBounds.Height /
                printFont.GetHeight(ev.Graphics);
            int i = 0;
            while (count < linesPerPage && (i<date.Count()))
            {
                linie_txt = date[i];
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(linie_txt, printFont, Brushes.Black,
                    leftMargin, yPos, new StringFormat());
                count++;
                i++;
            }

            ev.HasMorePages = false;

        }

        private void salvareDateToolStripMenuItem_Click(object sender, EventArgs e)
        {

                printFont = new Font("Arial", 12);
                pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(this.PrintPage);

                PageSetupDialog1.PageSettings =
                    new System.Drawing.Printing.PageSettings();

                PageSetupDialog1.PrinterSettings =
                    new System.Drawing.Printing.PrinterSettings();

                PageSetupDialog1.ShowNetwork = true;

                DialogResult result = PageSetupDialog1.ShowDialog();
                pd.DefaultPageSettings = PageSetupDialog1.PageSettings;
                pd.Print();

        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printFont = new Font("Arial", 16);
            pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintPage);
            printPreviewDialog1.Document = pd;

            printPreviewDialog1.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg,
                               Keys keyData)
        {
            bool handled = false;
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    salvareDateToolStripMenuItem_Click(null, null);
                    handled = true;
                    break;
                case Keys.Control | Keys.P:
                    previewToolStripMenuItem_Click(null, null);
                    handled = true;
                    break;
            }
            return handled;
        }
    }
}
