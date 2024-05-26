using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    internal class ViewAsigurari:TreeView
    {
        public bool exB = false;
        public bool exV = false;

        public ViewAsigurari():base() {

            string vText = "Asigurare de viata";
                TreeNode treeNode = new TreeNode();
                treeNode.Text = vText;
                treeNode.Tag = vText;
                treeNode.Nodes.Add(new TreeNode("None"));
                this.Nodes.Add(treeNode);
            

                string bText = "Asigurari de bunuri";
                TreeNode treeNode2 = new TreeNode();
                treeNode2.Text = bText;
                treeNode2.Tag = bText;
                treeNode2.Nodes.Add(new TreeNode("None"));
                this.Nodes.Add(treeNode2);



        }
       public void Clear()
        {

            if (exV)
            {
                ContextMenuStrip strip = new ContextMenuStrip();
                ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
                deleteLabel.Text = "Delete";
                strip.Items.Add(deleteLabel);
                this.Nodes[0].Remove();
                string vText = "Asigurare de viata";
                TreeNode treeNode = new TreeNode();
                treeNode.Text = vText;
                treeNode.Tag = vText;
                treeNode.Nodes.Add(new TreeNode("None"));
                if (this.Nodes.Count>0)
                {
                    TreeNode t = this.Nodes[0];
                    this.Nodes[0].Remove();
                    this.Nodes.Add(treeNode); this.Nodes.Add(t);
                }
                else
                    this.Nodes.Add(treeNode);
                this.Nodes[0].ContextMenuStrip = strip;
                exV = false;
            }

            if (exB)
            {
                this.Nodes[1].Remove();
                string bText = "Asigurari de bunuri";
                TreeNode treeNode2 = new TreeNode();
                treeNode2.Text = bText;
                treeNode2.Tag = bText;
                treeNode2.Nodes.Add(new TreeNode("None"));
                this.Nodes.Add(treeNode2);
                exB = false;
            }
        }
        public void addAsigurareBunuri(AsigurareBunuri b)
        {
            if (b == null)
                return;
            if (!exB) {
                this.Nodes[1].Nodes[0].Remove();
                exB = true;
            }
            TreeNode t = new TreeNode();
            t.Text = b.Denumire_bun;
            t.Tag = b;

            t.Nodes.Add(new TreeNode("Id Asigurare: " + b.Id_asigurare.ToString()));
            t.Nodes.Add(new TreeNode("Cost: " + b.Cost_calculat.ToString()));
            string acop = "De Baza";
            if (b.Acoperire == 'n')
                acop = "Normala";
            if (b.Acoperire == 'e')
                acop = "Extinsa";
            t.Nodes.Add(new TreeNode("Tip Asigurare: " + acop));
            t.Nodes.Add(new TreeNode("Valoare Bun: " + b.Valoare.ToString()));


            string risc = "Scazut";
            if (b.Istoric_defectiuni == '1')
                risc = "Mediu";
            if (b.Istoric_defectiuni == '2')
                risc = "Ridicat";

            t.Nodes.Add(new TreeNode("Grad de Risc: " + risc));
            this.Nodes[1].Nodes.Add(t);
        }
        public void addAsigurareViata(AsigurareViata v)
        {
            if (exV || v==null)
                return;
            this.Nodes[0].Nodes[0].Remove();
            this.Nodes[0].Tag = v;
            this.Nodes[0].Nodes.Add(new TreeNode("Id Asigurare: "+v.Id_asigurare.ToString()));
            this.Nodes[0].Nodes.Add(new TreeNode("Cost: " + v.Cost_calculat.ToString()));
            string acop = "De Baza";
            if (v.Acoperire == 'n')
                acop = "Normala";
            if (v.Acoperire == 'e')
                acop = "Extinsa";
            this.Nodes[0].Nodes.Add(new TreeNode("Tip Asigurare: "+acop));
            
            string risc = "Scazut";
            if (v.Istoric_afectiuni == '1')
                risc = "Mediu";
            if (v.Istoric_afectiuni == '2')
                risc = "Ridicat";

            this.Nodes[0].Nodes.Add(new TreeNode("Grad de Risc: " + risc));
            exV = true;
        }
            public void removeData() 
        { 
        
        }
        public void motifyData()
        {

        }
    }
}
