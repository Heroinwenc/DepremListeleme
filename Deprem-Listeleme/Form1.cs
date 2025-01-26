using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Deprem_Listeleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DepremListesiHazirla();
        }

        private async void btnListele_Click(object sender, EventArgs e)
        {
            listViewDepremler.Items.Clear();

            try
            {
                string html = await HtmlIndir("http://www.koeri.boun.edu.tr/scripts/lst0.asp");
                HtmlParseEt(html);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async Task<string> HtmlIndir(string url)
        {
            using (HttpClient istemci = new HttpClient())
            {
                istemci.DefaultRequestHeaders.Add("User-Agent", "DepremListelemeUygulamasi");
                return await istemci.GetStringAsync(url);
            }
        }

        private void HtmlParseEt(string html)
        {
            using (StringReader okuyucu = new StringReader(html))
            {
                string satir;
                bool veriBasladi = false;

                while ((satir = okuyucu.ReadLine()) != null)
                {
                    if (satir.Contains("----------"))
                    {
                        veriBasladi = true;
                        continue;
                    }

                    if (!veriBasladi || string.IsNullOrWhiteSpace(satir)) continue;

                    // HTML etiketlerini temizlemek için satırı işliyoruz
                    satir = RemoveHtmlTags(satir);

                    string[] kolonlar = satir.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (kolonlar.Length >= 9)
                    {
                        string tarih = kolonlar[0];
                        string saat = kolonlar[1];
                        string enlem = kolonlar[2];
                        string boylam = kolonlar[3];
                        string derinlik = kolonlar[4];
                        string siddet = kolonlar[6];
                        string yer = string.Join(" ", kolonlar.Skip(8));

                        var eleman = new ListViewItem(tarih + " " + saat) // Tarih ve saat tek bir sütunda birleşti
                        {
                            BackColor = double.TryParse(siddet, out double siddetDeger) && siddetDeger >= 4.5 ? System.Drawing.Color.LightCoral : System.Drawing.Color.White
                        };

                        eleman.SubItems.Add(yer); // Yer ikinci sütuna yerleştirildi
                        eleman.SubItems.Add(siddet); // Büyüklük (şiddet) üçüncü sütuna yerleştirildi
                        eleman.SubItems.Add(enlem); // Enlem dördüncü sütuna yerleştirildi
                        eleman.SubItems.Add(boylam); // Boylam beşinci sütuna yerleştirildi
                        eleman.SubItems.Add(derinlik); // Derinlik altıncı sütuna yerleştirildi

                        listViewDepremler.Items.Add(eleman);
                    }
                }
            }
        }



        // HTML etiketlerini temizleyen metod
        private string RemoveHtmlTags(string input)
        {
            var regex = new System.Text.RegularExpressions.Regex("<.*?>");
            return regex.Replace(input, string.Empty);
        }


        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKelimesi = txtAra.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(aramaKelimesi))
            {
                MessageBox.Show("Lütfen arama yapmak için bir kelime giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in listViewDepremler.Items)
            {
                bool eslesen = false;

                // Her sütundaki veriyi kontrol edelim
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToUpper().Contains(aramaKelimesi))
                    {
                        eslesen = true;
                        break;
                    }
                }

                // Eşleşen veriye göre arama sonuçlarını gösterelim
                item.BackColor = eslesen ? System.Drawing.Color.LightGreen : System.Drawing.Color.White;
            }
        }


        private void DepremListesiHazirla()
        {
            // Varsayılan değerler veya arayüz ayarları yapılabilir.
            listViewDepremler.Items.Clear(); // Listeyi boşaltır.
            txtAra.Text = string.Empty; // Arama kutusunu temizler.
        }

        // Türkçe karakterleri normalize eden metod
        private string NormalizeText(string text)
        {
            // Türkçe karakterleri doğru bir şekilde karşılaştırabilmek için normalize ediyoruz.
            string normalizedText = text.Normalize(System.Text.NormalizationForm.FormD);
            return new string(normalizedText.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());
        }
    }
}
