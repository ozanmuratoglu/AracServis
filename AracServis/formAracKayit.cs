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
    public partial class formAracKayit : Form
    {
        Arac_Servis arac_servis = new Arac_Servis();
        public formAracKayit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle = "insert into arac(plaka,marka,seri,yil,renk,km,yakit,ucreti,tarih,durumu,musteritc) values(@plaka,@marka,@seri,@yil,@renk,@km,@yakit,@ucreti,@tarih,@durumu,@musteritc)";

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
            komut2.Parameters.AddWithValue("@durumu", "BOŞ");
            komut2.Parameters.AddWithValue("@musteritc", musteritcCombo.Text);
            arac_servis.ekle_sil_guncelle(komut2, cumle);
            SeriCombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
        }


        private void formAracKayit_Load(object sender, EventArgs e)
        {
            string sorgu2 = "SELECT * FROM musteri";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            arac_servis.tcGetir(musteritcCombo,sorgu2);
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
