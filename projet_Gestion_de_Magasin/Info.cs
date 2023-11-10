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
    public partial class Info : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-DJR5LN8\SQLEXPRESS;Initial Catalog=GESTION_MAGASIN;Integrated Security=True");
        private int id;

        public Info(int id )
        {
            this.id = id;
            InitializeComponent();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            textBox5.Text = id.ToString();
            textBox5.Enabled = false;
           
            cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from User_GM where idUser =" +id, cnx);
            SqlCommand cmd_remplir_combobox= new SqlCommand("select * from Type_User" , cnx);
            SqlDataReader reder = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reder);
            reder.Close();
            SqlDataReader rederInfo = cmd_remplir_combobox.ExecuteReader();
            DataTable dtInfo = new DataTable(); 
            dtInfo.Load(rederInfo);
            rederInfo.Close();
            cnx.Close();

           nom.Text= dt.Rows[0][1].ToString();
           mot_de_passe.Text = dt.Rows[0][3].ToString();
           email.Text = dt.Rows[0][2].ToString();
            Type_user.DataSource = dtInfo;
            Type_user.DisplayMember = "NomType_User";
            Type_user.ValueMember = "idType_User";
            image.BackgroundImage = Image.FromFile(dt.Rows[0][5].ToString());
            image.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void modiffier_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("voulez vous vraiment modifier cet utilisateur", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == ds)
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("update  User_GM set nomUser='"+nom.Text+"' , EmailUser='"+email.Text+ "' , PasswordUser='" + mot_de_passe.Text+ "' , Type_User_idType_User='" + Type_user.SelectedValue+"' , image='"+lien.Text+"' where idUser=" + id, cnx);
                int a = cmd.ExecuteNonQuery();
                cnx.Close();

            }
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("voulez vous vraiment supprimer les information", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == dr)
            {

                cnx.Open();
                SqlCommand cmd = new SqlCommand("delete from User_GM where idUser=" + id, cnx);
               int a= cmd.ExecuteNonQuery();
                MessageBox.Show(1+"ligne a été supprimé");
                cnx.Close();
                Application.Restart();
                this.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ("Image Png|*.png|Image Jpg|*.jpg|Image jpeg|*.jpeg");
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                image.BackgroundImage = Image.FromFile(dialog.FileName);

                lien.Text = dialog.FileName;
            }
        }

        private void image_Click(object sender, EventArgs e)
        {

        }
    }
}
