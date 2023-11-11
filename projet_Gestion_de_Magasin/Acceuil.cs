using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet_Gestion_de_Magasin
{
    public partial class Acceuil : Form
    {
        public Acceuil()
        {
            InitializeComponent();
        }
        public void panel_show(object Form)
        {
            if (this.show_Forms.Controls.Count > 0)
                this.show_Forms.Controls.RemoveAt(0);
            Form h = Form as Form;
            h.TopLevel = false;
            h.Dock = DockStyle.Fill;
            this.show_Forms.Controls.Add(h);
            this.show_Forms.Tag = h;
            h.Show();

        }

        private void Acceuil_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Text = "User";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "User";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_show(new Categorie());
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Text = "";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Text = "Catégorie";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_show(new Client_form());

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel_show(new User_Form());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
