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
    public partial class Form3 : Form
    {
        Utilizator user;
        public Form3(Utilizator user)
        {
            InitializeComponent();
            this.user = user;
            this.label1.Text = user.ToString();
        }
    }
}
