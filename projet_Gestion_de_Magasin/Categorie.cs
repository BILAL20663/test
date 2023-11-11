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
    public partial class Categorie : Form
    {
        int trouve;
        public Categorie()
        {
            InitializeComponent();
        }
        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KFJGHN9;Initial Catalog=GESTION_MAGASIN;Integrated Security=True");
        public void Afficher()
        {
           
     
            SqlCommand command = new SqlCommand("select * from famille", conn);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
             dataGridView1.DataSource = dt;
        }

        private void Categorie_Load(object sender, EventArgs e)
        {
            conn.Open();
            this.Afficher();
            this.show();
            DataGridViewColumn column = dataGridView1.Columns[0];
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column.Width = 220;
            column1.Width = 220;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir votre champs");
            }
            else { 
                 SqlCommand command = new SqlCommand("insert into famille values('"+textBox1.Text+"') ", conn);
                int ligne = command.ExecuteNonQuery();
                MessageBox.Show("vous avez ajoute "+ligne+"ligne");
                textBox1.Text = "";
                this.Afficher();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("voulez vous vraiment supprimer cette ligne ","Attetion",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (DialogResult.Yes==dr)
            {
                SqlCommand command = new SqlCommand("delete from famille where idFamille =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), conn);
                int ligne = command.ExecuteNonQuery();
                MessageBox.Show("vous avez supprime " + ligne + "ligne");
                textBox1.Text = "";
                this.Afficher();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int index;
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("update famille set libelleFamille='" + textBox1.Text + "' where idFamille =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), conn);
                command.ExecuteNonQuery();
                this.Afficher();
                textBox1.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtidserch_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void show()
        {
            ElipseControl nn = new ElipseControl();
            nn.TargetControl = panel1;
            nn.CornerRadius = 40;

            ElipseControl MM = new ElipseControl();
            nn.TargetControl = textBox1;
            nn.CornerRadius = 40;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    class ElipseControl : Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
            (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse
            );
        private Control _cntrl;
        private int _CornerRadius = 30;

        public Control TargetControl
        {
            get { return _cntrl; }
            set
            {
                _cntrl = value;
                _cntrl.SizeChanged += (sender, eventArgs) => _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
            }
        }

        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                _CornerRadius = value;
                if (_cntrl != null)
                    _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
            }
        }
    }

}
