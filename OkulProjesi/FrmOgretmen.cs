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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void BtnKulup_Click(object sender, EventArgs e)
        {
            FrmKulupIslemleri fr = new FrmKulupIslemleri();
            fr.Show();
            this.Hide();
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
            this.Hide();
        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr = new FrmOgrenci();
            fr.Show();
        }

        private void BtnSınav_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar fr = new FrmSınavNotlar();
            fr.Show();
        } 
    }
}
