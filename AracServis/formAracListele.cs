using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracServis
{
    public partial class formAracListele : Form
    {
        Arac_Servis arac_servis = new Arac_Servis();
        public formAracListele()
        {
            InitializeComponent();
        }

        private void formAracListele_Load(object sender, EventArgs e)
        {
            YenileAraçListesi();
            comboAraclar.SelectedIndex = 0;
        }
        private void YenileAraçListesi()
        {
            string cumle = "select *from arac";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac_servis.listele(adtr2, cumle);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            Plakatxt.Text = satir.Cells["plaka"].Value.ToString();
            MarkaCombo.Text = satir.Cells["marka"].Value.ToString();
            SeriCombo.Text = satir.Cells["seri"].Value.ToString();
            Yiltxt.Text = satir.Cells["yil"].Value.ToString();
            Renktxt.Text = satir.Cells["renk"].Value.ToString();
            Kmtxt.Text = satir.Cells["km"].Value.ToString();
            YakitCombo.Text = satir.Cells["yakit"].Value.ToString();
            Ucrettxt.Text = satir.Cells["ucreti"].Value.ToString();
            durumutxt.Text = satir.Cells["durumu"].Value.ToString();


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string cumle = "update arac set marka=@marka, seri=@seri, yil=@yil, renk=@renk, km=@km, yakit=@yakit, ucreti=@ucreti, tarih=@tarih, durumu=@durumu where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", MarkaCombo.Text);
            komut2.Parameters.AddWithValue("@seri", SeriCombo.Text);
            komut2.Parameters.AddWithValue("@yil", Yiltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakit", YakitCombo.Text);
            komut2.Parameters.AddWithValue("@ucreti", Ucrettxt.Text);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now).ToString();
            komut2.Parameters.AddWithValue("@durumu", durumutxt.Text);
            arac_servis.ekle_sil_guncelle(komut2, cumle);
            SeriCombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            YenileAraçListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            string cumle = "delete from arac where plaka= '" + satir.Cells["plaka"].Value.ToString()+"'";
            SqlCommand komut2 = new SqlCommand();
            arac_servis.ekle_sil_guncelle(komut2, cumle);
            YenileAraçListesi();
            SeriCombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
        }

        private void SeriCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MarkaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SeriCombo.Items.Clear();
                if (MarkaCombo.SelectedIndex == 0)
                {
                    SeriCombo.Items.Add("Astra");
                    SeriCombo.Items.Add("Vectra");
                    SeriCombo.Items.Add("Corsa");
                }
                else if (MarkaCombo.SelectedIndex == 1)
                {
                    SeriCombo.Items.Add("Megane");
                    SeriCombo.Items.Add("Clio");
                }
                else if (MarkaCombo.SelectedIndex == 2)
                {
                    SeriCombo.Items.Add("Linea");
                    SeriCombo.Items.Add("Egea");
                }
                else if (MarkaCombo.SelectedIndex == 3)
                {
                    SeriCombo.Items.Add("Fiesta");
                    SeriCombo.Items.Add("Focus");
                }
            }
            catch
            {
                ;
            }
        }

        private void comboAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboAraclar.SelectedIndex == 0)
                {
                    YenileAraçListesi();
                }
                if (comboAraclar.SelectedIndex == 1)
                {
                    string cumle = "select *from arac where durumu= 'BOŞ'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arac_servis.listele(adtr2, cumle);
                }
                if (comboAraclar.SelectedIndex == 2)
                {
                    string cumle = "select *from arac where durumu= 'İşlemde'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arac_servis.listele(adtr2, cumle);
                }
                if (comboAraclar.SelectedIndex == 3)
                {
                    string cumle = "select *from arac where durumu= 'Verildi'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arac_servis.listele(adtr2, cumle);
                }
            }
            catch
            {
                ;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
