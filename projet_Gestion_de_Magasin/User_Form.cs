using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace projet_Gestion_de_Magasin
{
    public partial class User_Form : Form
    {


        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-DJR5LN8\SQLEXPRESS;Initial Catalog=GESTION_MAGASIN;Integrated Security=True");
        

        public User_Form()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void show(Button bt)
        {
            ElipseControl nn = new ElipseControl();
            nn.TargetControl = bt;
            nn.CornerRadius = 40;
        }

        private void User_Form_Load(object sender, EventArgs e)
        {

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from User_GM", sqlConnection);
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
                picture.BackgroundImage = Image.FromFile(dt.Rows[i][5].ToString());
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
                if (cpt==4)
                {
                    cpt = 0;
                    top += pn.Height;
                }
            }
        }
        public void click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Info f = new Info(int.Parse(bt.Name));
            f.Show();
        }
    }
}
