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

namespace OkulProjesi
{
    public partial class FrmKulupIslemleri : Form
    {
        public FrmKulupIslemleri()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-LJ8041UU\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");
        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Kulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmKulupIslemleri_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            liste();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into Tbl_Kulupler (KULUPAD) Values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp listeye eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightPink;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); 
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Tbl_Kulupler where KULUPID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp silme işlemi gerçekleşti");
            liste();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Kulupler set KULUPAD=@p1 where KULUPID=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp güncelleme işlemi gerçekleşti");
            liste();
        }

      
    }
}
