using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet_Gestion_de_Magasin
{
    public partial class Client_form : Form
    {
        public Client_form()
        {
            InitializeComponent();
        }

        private void show(Button bt)
        {
            ElipseControl nn = new ElipseControl();
            nn.TargetControl = bt;
            nn.CornerRadius = 40;
        }
        public void click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Client f = new Client(int.Parse(bt.Name));
   
            f.Show();
            f.Show();
        }

        private void Client_form_Load(object sender, EventArgs e)
        {

            Connexion.open();
            SqlCommand cmd = new SqlCommand("select * from Client", Connexion.sqlConnection);
            SqlDataReader red = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(red);
            int cpt = 0;
            int left = 0;
            int top = 0;

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                cpt++;

                Panel pn = new Panel();
                pn.BackColor = Color.Plum;
                pn.Left += left + (cpt * 200);
                pn.Width = 200;
                pn.Height = 300;
                pn.BackColor = Color.Transparent;
                pn.Top = top;
                this.Controls.Add(pn);

                PictureBox picture = new PictureBox();
                picture.BackgroundImage = Image.FromFile(dt.Rows[i][6].ToString());
                picture.Top = 25;
                picture.Height = 100;
                picture.Width = 100;
                picture.Left = 50;
                picture.BackgroundImageLayout = ImageLayout.Stretch;
                pn.Controls.Add(picture);

                Label label = new Label();
                label.ForeColor = Color.Black;
                label.Font = new Font("Arial", 10.20F, FontStyle.Italic);
                label.Text = dt.Rows[i][1].ToString();
                label.Location = new Point(75, 150);
                pn.Controls.Add(label);

                Button bt = new Button();
                bt.Text = "Info";
                bt.ForeColor = Color.Black;
                bt.Font = new Font("Times New Roman", 10.20F, FontStyle.Italic);
                bt.Top = 200;
                bt.Height = 30;
                bt.Width = 150;
                bt.Left = 25;
                pn.Controls.Add(bt);
                bt.Name = dt.Rows[i][0].ToString();
                show(bt);

                bt.Click += new System.EventHandler(this.click);
                if (cpt == 4)
                {
                    cpt = 0;
                    top += pn.Height;
                }
            }
        }
    }
}
