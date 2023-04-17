using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bir_kelime_Bir_islem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rastgele = new Random();
        int harfsayac = 0;
        string karakter1, karakter2, karakter3, karakter4, karakter5, karakter6, karakter7, karakter8,karakter9;
         int harfler;
         string[] dizi = { "a", "b", "c", "ç", "d", "e", "f", "g", "ğ", "h", "i", "i", "j", "k", "l", "m", "n", "o", "ö", "p", "r", "s", "ş", "t", "u", "ü", "v", "y", "z" };
       
        private void Btnharfgetir_Click(object sender, EventArgs e)
        {
            harfsayac++;
            
            if(harfsayac==1)
            {
                harfler=rastgele.Next(0,dizi.Length);
                karakter1 = (dizi[harfler]);// rastegele değişkeni dizinin içerisinden seçecek.
                Btnharf1.Text = karakter1.ToString();
                Btnharf1.Visible = true;
            }
            if (harfsayac == 2)
            {
                harfler = rastgele.Next(0, dizi.Length);
                karakter2 = (dizi[harfler]);
                Btnharf2.Text = karakter2.ToString();
                Btnharf2.Visible = true;
            }
            if (harfsayac == 3)
            {
                harfler = rastgele.Next(0, dizi.Length);
                karakter3 = (dizi[harfler]);
                Btnharf3.Text = karakter3.ToString();
                Btnharf3.Visible = true;
            }
            if (harfsayac == 4)
            {
                harfler = rastgele.Next(0, dizi.Length);
                karakter4 = (dizi[harfler]);
                Btnharf4.Text = karakter4.ToString();
                Btnharf4.Visible = true;
            }
            if (harfsayac == 5)
            {
                harfler = rastgele.Next(0, dizi.Length);
                karakter5 = (dizi[harfler]);
                Btnharf5.Text = karakter5.ToString();
                Btnharf5.Visible = true;
            }
            if (harfsayac == 6)
            {
                harfler = rastgele.Next(0, dizi.Length);
                karakter6= (dizi[harfler]);
                Btnharf6.Text = karakter6.ToString();
                Btnharf6.Visible = true;
            }
            if (harfsayac == 7)
            {
                harfler = rastgele.Next(0, dizi.Length);
                karakter7 = (dizi[harfler]);
                Btnharf7.Text = karakter7.ToString();
                Btnharf7.Visible = true;
            }
            if (harfsayac == 8)
            {
                harfler = rastgele.Next(0, dizi.Length);
                karakter8 = (dizi[harfler]);
                Btnharf8.Text = karakter8.ToString();
                Btnharf8.Visible = true;
                Btnharf9.Text = "?";
                Btnharf9.Visible = true;
            }




        }

        private void Btnyenioyun_Click(object sender, EventArgs e)
        {
            harfsayac = 0;
            Bulduklarınız.Items.Clear();
            Txtistenilenharf.Enabled = true;
            Txtkelime.Clear();
            Txtistenilenharf.Clear();
            Lblgirilenkelime.Text = "";
            Lblpuan.Text = "";
             


            Btnharf1.Visible = false;
            Btnharf2.Visible = false;
            Btnharf3.Visible = false;
            Btnharf4.Visible = false;
            Btnharf5.Visible = false;
            Btnharf6.Visible = false;
            Btnharf7.Visible = false;
            Btnharf8.Visible = false;
            Btnharf9.Visible = false;
        }

        private void Txtkelime_TextChanged(object sender, EventArgs e)
        {
            
        }
        // KONTROL BUTONUNA TIKLANDIĞINDA KELİMENİN DOSYADA VAR OLUP OLMADIĞI KONTROLÜ YAPsr.
        private int puan = 0;
        private void Btnkontrol_Click(object sender, EventArgs e)
        {
            string kelime = Txtkelime.Text.Trim().ToLower();
            Lblgirilenkelime.Text = kelime;
            Btnharf9.Text = Txtistenilenharf.Text.Trim().ToLower();
            karakter9 = Btnharf9.Text;
            
            

            // metin kutusuunun boş olup olomadığını kontrol ediyor
            if (string.IsNullOrWhiteSpace(Txtistenilenharf.Text))
            {
                Txtistenilenharf.Enabled = true; 
                
            }
            else
            {
                Txtistenilenharf.Enabled = false; 
            }



            bool kelimeMevcut = false;

            if (kelime.Length >= 3)
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = desktopPath + "\\metinler.txt";

                if (File.Exists(filePath))
                {
                    string[] kelimeListesi = File.ReadAllText(filePath).ToLower().Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string dosyaKelimesi in kelimeListesi)
                    {
                        if (kelime == dosyaKelimesi)
                        {
                            kelimeMevcut = true;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı.");
                    return; // Dosya bulunamadığında kontrol işlemini durdur
                }
            }

            List<string> randomHarfler = new List<string> { karakter1, karakter2, karakter3, karakter4, karakter5, karakter6, karakter7, karakter8, karakter9 };

            bool harfMevcut = true;
            List<char> eksikHarfler = new List<char>();
            // kelimenin içindeki tüm harfleri kontrool eder
            foreach (char harf in kelime)
            {
                if (!randomHarfler.Contains(harf.ToString()))
                {
                    harfMevcut = false;
                    eksikHarfler.Add(harf);
                }
            }

            if (kelimeMevcut && harfMevcut)
            {
               
                MessageBox.Show("Tebrikler");
                int kelimePuan = 0; 

                switch (kelime.Length)
                {
                    case 3:
                        kelimePuan = 3;

                        break;
                    case 4:
                        kelimePuan = 4;
                        break;
                    case 5:
                        kelimePuan = 5;
                        break;
                    case 6:
                        kelimePuan = 6;
                        break;
                    case 7:
                        kelimePuan = 7;
                        break;
                    case 8:
                        kelimePuan = 8;
                        break;
                    case 9:
                        kelimePuan = 9;
                        break;
                    default:
                        break;
                }
                Bulduklarınız.Items.Add(kelime+" "+kelimePuan+" puan");
                puan += kelimePuan;
                Lblpuan.Text=puan.ToString();  



            }
            else if (!kelimeMevcut)
            {
                MessageBox.Show("Kelime dosyada mevcut değil.");
            }
            else// kelime listte var ama hatalı harf girişi olursa
            {
                MessageBox.Show($"Olmayan bir harf girişi. Eksik harfler: {string.Join(", ", eksikHarfler)}");
            }

            
            
        }


    }
}
