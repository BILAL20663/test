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
    public partial class Client : Form
    {
        private int idc;
        public Client(int idc)
        {
            this.idc = idc;
            InitializeComponent();
        }

        SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-DJR5LN8\SQLEXPRESS;Initial Catalog=GESTION_MAGASIN;Integrated Security=True");


        private void ajouter_Click(object sender, EventArgs e)
        {
            if (ajouter.Text == "")
            {
                MessageBox.Show("vous devez remplir votre champ");
            }
            else
            {
                SqlCommand command = new SqlCommand("insert into Client");


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                sql.Open();
                string Query = "UPDATE Client SET NomClient= '" + textBox4.Text + "' ,AdresseClient='" + textBox5.Text + "',TelClientl='" + textBox1.Text + "'WHERE idClient=" + idc + "";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Connexion.sqlConnection);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Modifier avec succes");
                this.Close();
                Connexion.close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
            finally
            {
                sql.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("voulez vous vraiment supprimer les information", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == dr)
            {

                sql.Open();
                SqlCommand cmd = new SqlCommand("delete from Client where idClient=" + idc, sql);
                int a = cmd.ExecuteNonQuery();
                MessageBox.Show(1 + "ligne a été supprimé");
                sql.Close();
                
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            textBox2.Text =  idc.ToString();
            textBox2.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Connexion.sqlConnection.Close();
            this.Close();
        }
    }
}
