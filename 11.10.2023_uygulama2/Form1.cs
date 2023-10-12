using System.Security.Cryptography;

namespace _11._10._2023_uygulama2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
        }
        Person kisi = new Person();
        List<Person> list = new List<Person>();

        private void btnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Jpg (.jpg)|*.jpg|Png (.png)|*.png";
            ofd.ShowDialog();
            string dosyaYolu = ofd.FileName;
            pictureBox1.ImageLocation = dosyaYolu;
            kisi.ResimYolu = dosyaYolu;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kisi.Ad = txtIsim.Text;
            kisi.Soyad = txtSoyIsim.Text;
            kisi.Email = txtMail.Text;
            kisi.PersonelID = txtID.Text;
            kisi.DogumTarihi = dateTimeDogumtarihi.Value;
            kisi.Telefon = txtTelefon.Text;
            kisi.Adres = txtAdres.Text;
            kisi.IseGirisTarihi = dateTimeIs.Value;


            int yas = (int)DateTime.Now.Year - kisi.DogumTarihi.Year;
            int result = DateTime.Compare(DateTime.Now, kisi.IseGirisTarihi);
            //EĞER result 0 dan küçükse işe giriş tarihi şuanki zamandan öncedir, 0 a eşitse aynı zamanı ifade der, 0 dan büyükse daha geç

            if (kisi.PersonelID.Length >= 5 && kisi.Email.Contains("@hotmail.com") && yas >= 18 && result >= 0)
            {
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
                list.Add(kisi);
                ListViewDoldur();
                MessageBox.Show("Kayıt başarılı");
                txtAdres.Clear();
                txtID.Clear();
                txtIsim.Clear();
                txtMail.Clear();
                txtSoyIsim.Clear();
                txtTelefon.Clear();
                pictureBox1.Image = null;
                
            }
            //else if (txtAdres.Text== " " || txtID.Text==" " || txtIsim.Text=" ")
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız, lütfen tekrar deneyiniz");
            }




        }
        private void ListViewDoldur()
        {
            listView1.Items.Clear();
            foreach (Person kisi in list)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = kisi.PersonelID;
                lvi.SubItems.Add(kisi.Ad);
                lvi.SubItems.Add(kisi.Soyad);
                lvi.SubItems.Add(kisi.DogumTarihi.ToShortDateString());//sadece string kabul ediyor, int ları otomatşk strşnge dönüştürüyor ama datetime da yapamıyor
                lvi.SubItems.Add(kisi.Telefon);
                lvi.SubItems.Add(kisi.Email);
                lvi.SubItems.Add(kisi.ResimYolu);

                listView1.Items.Add(lvi);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            List<int> seciliIndexler = new List<int>();

            foreach (int index in listView1.SelectedIndices)
            {

                ListViewItem selectedItem = listView1.Items[index];
                string itemText = selectedItem.Text;



                seciliIndexler.Add(index);

            }
            foreach (int index in seciliIndexler)
            {
                listView1.Items.RemoveAt(index);
                list.RemoveAt(index);
                kisi.Ad = txtIsim.Text;
                kisi.Soyad = txtSoyIsim.Text;
                kisi.Email = txtMail.Text;
                kisi.PersonelID = txtID.Text;
                kisi.DogumTarihi = dateTimeDogumtarihi.Value;
                kisi.Telefon = txtTelefon.Text;
                kisi.Adres = txtAdres.Text;
                kisi.IseGirisTarihi = dateTimeIs.Value;
                int yas = (int)DateTime.Now.Year - kisi.DogumTarihi.Year;
                int result = DateTime.Compare(DateTime.Now, kisi.IseGirisTarihi);
                if (kisi.PersonelID.Length >= 5 && kisi.Email.Contains("@hotmail.com") && yas >= 18 && result >= 0)
                {
                    btnGuncelle.Enabled = true;
                    btnSil.Enabled = true;
                    list.Add(kisi);
                    ListViewDoldur();
                    MessageBox.Show("Kayıt başarılı");
                    txtAdres.Clear();
                    txtID.Clear();
                    txtIsim.Clear();
                    txtMail.Clear();
                    txtSoyIsim.Clear();
                    txtTelefon.Clear();
                    pictureBox1.Image = null;
                }
                
                else
                {
                    MessageBox.Show("Hatalı giriş yaptınız, lütfen tekrar deneyiniz");
                }


            }









        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            List<int> seciliIndexler = new List<int>();

            foreach (int index in listView1.SelectedIndices)
            {
                
                ListViewItem selectedItem = listView1.Items[index];
                string itemText = selectedItem.Text;

                
                
                    seciliIndexler.Add(index);
                
            }
            foreach (int index in seciliIndexler)
            {
                listView1.Items.RemoveAt(index);
                list.RemoveAt(index);

            }
        }
    }
}