using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aplikacija_Samoposluga;

namespace Samoposluga
{
    public partial class Glavni_prozor : Form
    {
        public Glavni_prozor()
        {
            InitializeComponent();
            CenterToScreen();
            radioButton1.Checked = true;
        }
        string kategorija;
        string trazeni_proizvod;

        public void Pisanje(string kategorija,string podatak,string putanja)
        {
            string kategorija2 = kategorija;
            kategorija += ".txt";
            using (StreamWriter sr = File.AppendText(kategorija))
            {
                if (textBoxNaziv.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Morate uneti naziv");

                }
                else if (textBoxCena.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Morate uneseti cenu");

                }
                else
                {
                    sr.WriteLine(podatak);
                    sr.WriteLine(putanja);
                }
                sr.Close();
                Lista(kategorija2);

            }
        }


        public void Brisanje(string trazeni_proizvod,string kategorija)
        {
            int i = 0;
            string trenutna_linija = "";
            string kategorija2 = kategorija;
            kategorija += ".txt";
            using (StreamReader reader = new StreamReader(kategorija))
            {
                using (StreamWriter writer = new StreamWriter("Pomocni.txt"))
                {
                    while ((trenutna_linija = reader.ReadLine()) != null)
                    {
                        if (String.Compare(trenutna_linija, trazeni_proizvod) == 0)
                        {
                            i = 1;
                            continue;
                           

                        }
                        if (i != 0)
                        {
                            i = 0;
                            continue;
                        }

                        writer.WriteLine(trenutna_linija);
                        
                    }
                }
            }
            File.Delete(kategorija);
            File.Move( "Pomocni.txt",kategorija);
            Lista(kategorija2);
            panelPrikaz.BackgroundImage = null;

        }

       

        public void Lista(string kategorija)
        {
            kategorija += ".txt";
            
            listBoxLista.Items.Clear();
            using (StreamReader stream = File.OpenText(kategorija))
            {
                String s = "";
                while ((s = stream.ReadLine()) != null)
                {

                    string proizvod = s;
                    listBoxLista.Items.Add(s);
                    stream.ReadLine();
                }
                stream.Close();
            }
           
        }

        public void Pretraga(string trazeni_proizvod, string kategorija)
        {
            try
            {
                kategorija += ".txt";
                using (StreamReader stream = File.OpenText(kategorija))
                {
                    string putanja;
                    String s = "";
                    while ((s = stream.ReadLine()) != null)
                    {

                        if (trazeni_proizvod == s)
                        {
                            putanja = stream.ReadLine();
                            panelPrikaz.BackgroundImage = Image.FromFile(putanja);
                            break;
                        }
                        else stream.ReadLine();

                    }

                    stream.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Doslo je do neocekivane greske");
            }
        }

        
        private void comboBoxKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            kategorija=comboBoxKategorija.SelectedItem.ToString();
            labelKategorija.Text = kategorija;
            Lista(kategorija);


            switch(kategorija)
            {
                case("Voće"):
                    groupBox3.Visible = true;
                    groupBox4.Visible = false;
                    labelOstalo.Text = "Zemlja uvoza";
                    break;
                case "Povrće":
                    groupBox3.Visible = true;
                    groupBox4.Visible = false;
                    labelOstalo.Text = "Zemlja uvoza";
                    break;
                case "Mlečni proizvodi i jaja":
                    groupBox3.Visible = true;
                    groupBox4.Visible = false;
                    labelOstalo.Text = "Rok upotrebe (jos x dana)";
                    break;
                case "Peciva":
                    groupBox3.Visible = true;
                    groupBox4.Visible = false;
                    labelOstalo.Text = "Naziv pekare";
                    break;
                case "Meso":
                    groupBox4.Visible = true;
                    groupBox3.Visible = false;
                    labelOstalo.Text = "Kosti";
                    break;
                case "Pića":
                    groupBox4.Visible = true;
                    groupBox3.Visible = false;
                    labelOstalo.Text = "Alkohol";
                    break;
                case "Umaci i začini":
                    groupBox3.Visible = true;
                    groupBox4.Visible = false;
                    labelOstalo.Text = "Zemlja uvoza";
                    break;
                case "Ostalo":
                    groupBox3.Visible = true;
                    groupBox4.Visible = false;
                    labelOstalo.Text = "Opis:";
                    break;
                default:
                    MessageBox.Show("Neočekivana greška pri odabiru kategorije","Greška",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }
        }

        private void listBoxLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                trazeni_proizvod = listBoxLista.SelectedItem.ToString();
                Pretraga(trazeni_proizvod, kategorija);
            }
            catch 
            {
                MessageBox.Show("Neocekivana greska!Pokusajte ponovo","Greska",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Brisanje(trazeni_proizvod,kategorija);
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {   
            string naziv="";
            double cena=0;
            string ostalo = "";
            string podatak="";
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
            string filename = openFileDialog1.FileName;
            try
            {
                naziv =textBoxNaziv.Text;
                cena = Convert.ToDouble(textBoxCena.Text);
                ostalo = textBoxOstalo.Text;
                switch (labelKategorija.Text)
                {
                    case "Voće":
                        string uvoz = textBoxOstalo.Text;
                        Proizvodi p = (Proizvodi)(new VocePovrce(naziv, cena, uvoz));
                        podatak = p.Prikaz();
                        break;
                    case "Povrće":
                        string uvoz1 = textBoxOstalo.Text;
                        Proizvodi p1 = (Proizvodi)(new VocePovrce(naziv, cena, uvoz1));
                        podatak = p1.Prikaz();
                        break;
                    case "Mlečni proizvodi i jaja":
                        int rok = Convert.ToInt32(textBoxOstalo.Text);
                        Proizvodi p2 = (Proizvodi)(new Mlecni(naziv, cena, rok));
                        podatak = p2.Prikaz();
                        break;
                    case "Peciva":
                        string pekara = textBoxOstalo.Text;
                        Proizvodi p3 = (Proizvodi)(new Peciva(naziv, cena, pekara));
                        podatak = p3.Prikaz();
                        break;
                    case "Meso":
                        bool kosti;
                        if (radioButton1.Checked == true) kosti = true;
                        else kosti = false;
                        Proizvodi p4 = (Proizvodi)(new Meso(naziv, cena, kosti));
                        podatak = p4.Prikaz();
                        break;

                    case "Pića":
                        bool alkohol;
                        if (radioButton1.Checked == true) alkohol = true;
                        else alkohol = false;
                        Proizvodi p5 = (Proizvodi)(new Pica(naziv, cena, alkohol));
                        podatak = p5.Prikaz();
                        break;
                    case "Umaci i začini":
                        string uvoz2 = textBoxOstalo.Text;
                        Proizvodi p6 = (Proizvodi)(new VocePovrce(naziv, cena, uvoz2));
                        podatak = p6.Prikaz();
                        break;
                    case "Ostalo":
                        string opis = textBoxOstalo.Text;
                        Ostalo p7 = new Ostalo(naziv, cena, opis);
                        podatak = p7.Prikaz();
                        break;
                }
                Pisanje(kategorija, podatak, filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
           
            

        }
    }
}
