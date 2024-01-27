using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LearnVocabulary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Baha YOLAL\Desktop\C# Project7 İngilizce kelime öğrenme\dbSozluk.accdb"";Persist Security Info=True");
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source="C:\Users\Baha YOLAL\Desktop\C# Project7 İngilizce kelime öğrenme\dbSozluk.accdb";Persist Security Info=True
        
        Random rast = new Random();
        int süre = 90;
        int kelime = 0;
        void getir()
        {

            int sayi;
            sayi = rast.Next(1, 2490);

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from sozluk where id = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", sayi);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                TxtEnglish.Text = dr[1].ToString();
                LblAnswer.Text = dr[2].ToString();
                LblAnswer.Text = LblAnswer.Text.ToLower();
            }
            baglanti.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            getir();
            TxtTurkish.Focus();
            timer1.Start();
        }

        private void TxtTurkish_TextChanged(object sender, EventArgs e)
        {
            if(TxtTurkish.Text==LblAnswer.Text)
            {
                kelime++;
                LblWord.Text = kelime.ToString();
                getir();
                TxtTurkish.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            süre--;
            LblTime.Text = süre.ToString();
            if(süre == 0)
            {
                TxtTurkish.Enabled=false;
                TxtEnglish.Enabled=false;
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getir();
            TxtTurkish.Clear();

        }
    }
}
