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
    public partial class Form4 : Form
    {
        private Utilizator user;
        private Sesiune sesiune1;
        public Form4(Utilizator user,Sesiune sesiune)
        {
            InitializeComponent();
            this.user = user;
            this.sesiune1 = sesiune;
            label1.Text = user.ToString();
        }
    }
}
