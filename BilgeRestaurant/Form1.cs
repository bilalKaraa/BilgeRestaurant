using BilgeRestaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeRestaurant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Siparis spr;
        List<Icecek> icecekler;
        List<Tatli> tatlilar;
        List<AraSicak> araSicaklar;
        List<AnaYemek> anaYemekler;
        int adetİcecek = 0, adetTatli = 0, adetAraSicak = 0, adetAnaYemek = 0;
        decimal ToplamCiro = 0;
      

        public void CiroHesapla()
        {
            if (spr != null)
            {
                foreach (Tatli tatli in spr.SecilenTatli)
                {
                    ToplamCiro += tatli.Adet * tatli.Fiyat;
                }
                foreach (AnaYemek anaYemek in spr.SecilenAnaYemek)
                {
                    ToplamCiro += anaYemek.Adet * anaYemek.Fiyat;
                }
                foreach (AraSicak araSicak in spr.SecilenArasicak)
                {
                    ToplamCiro += araSicak.Adet * araSicak.Fiyat;
                }
                foreach (Icecek icecek in spr.SecilenIcecek)
                {
                    ToplamCiro += icecek.Adet * icecek.Fiyat;
                }
                MessageBox.Show("Toplam Ciro : " + ToplamCiro.ToString());
               
            }
        }
        private void btnCiro_Click(object sender, EventArgs e)
        {
          
            CiroHesapla();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            icecekler = new List<Icecek>
            { new Icecek{ Ad="Kola",Fiyat=10,Aciklama="Soğuk 330ml"},
            new Icecek{ Ad="Fanta",Fiyat=10,Aciklama="Soğuk 330ml"},
            new Icecek{ Ad="Ayran",Fiyat=8,Aciklama="Yayık ayran"},
            new Icecek{ Ad="Şalgam",Fiyat=8,Aciklama="Acılı"},
            };
            cmbİcecek.DataSource = icecekler;
            cmbİcecek.SelectedIndex = -1;
            tatlilar = new List<Tatli>
            { new Tatli{ Ad="Sütlaç",Fiyat=20,Aciklama="Fırın Sütlaç"},
            new Tatli{ Ad="Kazan Dibi",Fiyat=30,Aciklama="Muhallebi Kazandibi"},
            new Tatli{ Ad="Profiterol",Fiyat=35,Aciklama="Krema dolgulu Çikolatalı"},
            new Tatli{ Ad="Kabak Tatlısı",Fiyat=55,Aciklama="Tahin ve Ceviz ile Servis Edilir"},
            };
            cmbTatlilar.DataSource = tatlilar;
            cmbTatlilar.SelectedIndex = -1;
            araSicaklar = new List<AraSicak>
            { new AraSicak{ Ad="Çıtır Patates",Fiyat=20,Aciklama="Afyon Patatesi"},
            new AraSicak{ Ad="Soğan Halkası",Fiyat=30,Aciklama="Enfes çıtırtı"},
            new AraSicak{ Ad="Çıtır Tavuk",Fiyat=35,Aciklama="Özel Soslu"},
            new AraSicak{ Ad="Tarhana Çorbası",Fiyat=35,Aciklama="Uşak Tarhanası Eşliğinde"},

            };
            cmbAraSicak.DataSource = araSicaklar;
            cmbAraSicak.SelectedIndex = -1;
            anaYemekler = new List<AnaYemek>
            { new AnaYemek{ Ad="Adana",Fiyat=50,Aciklama="Acılı Adana"},
            new AnaYemek{ Ad="Siverek Kebabı",Fiyat=60,Aciklama="Özel Patlıcanlı"},
            new AnaYemek{ Ad=" Diyarbakır Ciğeri",Fiyat=70,Aciklama="Kuzu Ciğeri"},
            new AnaYemek{ Ad="Tavuk kanat",Fiyat=45,Aciklama="Gezen Tavuk Kanadı"},
            };
            cmbAnaYemek.DataSource = anaYemekler;
            cmbAnaYemek.SelectedIndex = -1;
            spr = new Siparis();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (txtMasa.Text != "")
            {
                lstSiparis.Items.Add("Masa :" + txtMasa.Text);
                if (cmbAnaYemek.SelectedIndex != -1)
                {
                    if (nmrAnaYemek.Value > 0)
                    {
                        AnaYemek aymk = anaYemekler[cmbAnaYemek.SelectedIndex];
                        aymk.Adet = nmrAnaYemek.Value;
                        spr.SecilenAnaYemek.Add(aymk);
                        lstSiparis.Items.Add(nmrAnaYemek.Value + "X" + aymk + " Toplam: " + aymk.Adet * aymk.Fiyat);
                        cmbAnaYemek.SelectedIndex = -1;
                        nmrAnaYemek.Value = 1;
                    }
                    else
                    {
                        lblAnaAdet.Text = "Adet giriniz";
                    }


                }
                if (cmbAraSicak.SelectedIndex != -1)
                {
                    if (nmrArasicak.Value > 0)
                    {
                        AraSicak arsck = araSicaklar[cmbAraSicak.SelectedIndex];
                        arsck.Adet = nmrArasicak.Value;
                        spr.SecilenArasicak.Add(arsck);
                        lstSiparis.Items.Add(nmrArasicak.Value + "X" + arsck + " Toplam: " + arsck.Adet * arsck.Fiyat);
                        cmbAraSicak.SelectedIndex = -1;
                        nmrArasicak.Value = 1;
                    }
                    else
                    {
                        lblAraAdet.Text = "Adet giriniz";
                    }
                }
                if (cmbTatlilar.SelectedIndex != -1)
                {
                    if (nmrTatli.Value > 0)
                    {
                        Tatli ttl = tatlilar[cmbTatlilar.SelectedIndex];
                        ttl.Adet = nmrTatli.Value;
                        spr.SecilenTatli.Add(ttl);
                        lstSiparis.Items.Add(nmrTatli.Value + "X" + ttl + " Toplam: " + ttl.Adet * ttl.Fiyat);
                        cmbTatlilar.SelectedIndex = -1;
                        nmrTatli.Value = 1;
                    }
                    else
                    {
                        lblTatliAdet.Text = "Adet giriniz";
                    }
                }
                if (cmbİcecek.SelectedIndex != -1)
                {
                    if (nmrİcecek.Value > 0)
                    {
                        Icecek icck = icecekler[cmbİcecek.SelectedIndex];
                        icck.Adet = nmrİcecek.Value;
                        spr.SecilenIcecek.Add(icck);
                        lstSiparis.Items.Add(nmrİcecek.Value + "X" + icck + " Toplam:" + icck.Adet * icck.Fiyat);
                        cmbİcecek.SelectedIndex = -1;
                        nmrİcecek.Value = 1;
                    }
                    else
                    {
                        lblIcecekAdet.Text = "Adet giriniz";
                    }
                }
            }
            else
            {
                MessageBox.Show("Masa Numranızı Giriniz!");
            }
        }
    }
}
