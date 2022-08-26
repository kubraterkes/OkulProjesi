using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProjesi
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtDersAd.Text);
            MessageBox.Show("Ders ekleme işlemi yapılmıştır");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(TxtDersId.Text));
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtDersAd.Text, byte.Parse(TxtDersId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
