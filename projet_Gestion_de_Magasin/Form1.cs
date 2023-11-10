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

namespace projet_Gestion_de_Magasin
{
    public partial class Form1 : Form
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-DJR5LN8\SQLEXPRESS;Initial Catalog=GESTION_MAGASIN;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Fermer_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            timer1.Stop();
            this.Close();
        }
        private Button buttonOK;
        private void button1_Click(object sender, EventArgs e)
        {
            bool test =false;
            if (textBox1.Text != "" && textBox2.Text !="" && comboBox2.Text !="")
            {
                string query = "select * from User_GM";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable data_user = new DataTable();
                data_user.Load(reader);

                for (int i = 0; i <= data_user.Rows.Count - 1; i++)
                {
                    if (data_user.Rows[i]["Type_User_idType_User"].ToString() == comboBox2.SelectedValue.ToString() && data_user.Rows[i]["nomUser"].ToString() == textBox1.Text && data_user.Rows[i]["PasswordUser"].ToString() == textBox2.Text)
                    {
                        test = true;
                        Acceuil Acceuil_GM = new Acceuil();
                        Acceuil_GM.Show();
                        break;

                        sqlConnection.Close();
                    }
                    else
                    {
                        test = false;
                        
                    }
                }
                if(test==false)
                {
                    MessageBox.Show("utilisateur non existe");
                }

            }
            else
            {
                MessageBox.Show("vous devez entrez vos informations");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             timer1.Start();
            ; sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("select * from Type_User", sqlConnection);
            SqlDataReader red = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(red);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "NomType_User"; 
            Time.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
    