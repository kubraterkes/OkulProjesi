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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-LJ8041UU\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

       
        

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbOgrenciKulup.DisplayMember = "KULUPAD";
            CmbOgrenciKulup.ValueMember = "KULUPID";
            CmbOgrenciKulup.DataSource = dt;
            baglanti.Close();
                
        }
        string c = "";

        private void BtnEkle_Click(object sender, EventArgs e)
        {
         
            ds.OgrenciEkle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(CmbOgrenciKulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci ekleme yapıldı.");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void CmbOgrenciKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtOgrenciId.Text = CmbOgrenciKulup.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrenciId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //CmbOgrenciKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(CmbOgrenciKulup.SelectedValue.ToString()), c,int.Parse(TxtOgrenciId.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
         
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        { 

            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= ds.OgrenciGetir(TxtAra.Text);
        }

       
    }
}
