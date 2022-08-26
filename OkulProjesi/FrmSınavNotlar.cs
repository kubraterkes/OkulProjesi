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
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-LJ8041UU\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");

        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter(); 

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtId.Text));

        }

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "DERSAD";
            CmbDers.ValueMember = "DERSID";
            CmbDers.DataSource = dt;
            baglanti.Close();
        }
        int notid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        int sinav1, sinav2, sinav3, proje;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        double ortalama;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
           
            //string durum;
            sinav1 = Convert.ToInt16(TxtSınav1.Text);
            sinav2 = Convert.ToInt16(TxtSınav2.Text);
            sinav3 = Convert.ToInt16(TxtSınav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            TxtOrtalama.Text = ortalama.ToString();
            if(ortalama >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";    
            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(TxtId.Text), byte.Parse(TxtSınav1.Text), byte.Parse(TxtSınav2.Text), byte.Parse(TxtSınav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text), notid);

        }
    }
}
