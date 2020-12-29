using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using laskutusohjelma;


//Ohjelman pääform
namespace tilisiirto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            Operaatiot op = new Operaatiot();
            Numerosarjat ns = new Numerosarjat();
			

            textBoxviite.Text = textBoxviite.Text.Replace(" ", "");
            if ( ns.TarkastaMerkit(textBoxviite.Text)==false) { textBoxviite.Text = "Virhe!";return; };



            textBoxtili.Text = textBoxtili.Text.Replace(" ", "");
            if (ns.TarkastaMerkit(textBoxtili.Text) == false) { textBoxtili.Text = "Virhe!";return; };
            if ( textBoxtili.Text!="" && ns.TarkastaIBAN(textBoxtili.Text) == false) { textBoxtili.Text = "Virhe!"; return; };




            PrivateFontCollection fc = new PrivateFontCollection();
            fc.AddFontFile("c:\\temp\\code128.ttf");
            Font fonttiviiva = new Font(fc.Families[0], 60, FontStyle.Regular);
            


            Lasku lasku = new Lasku();
            Laskuttaja laskuttaja = new Laskuttaja();
            Henkilo henkilö = new Henkilo();
            


            lasku.eräpäivä = dateTimePicker1.Value;

            try { lasku.euro = int.Parse(textBoxeuro.Text); }  catch{ lasku.euro = 0; textBoxeuro.Text = "";  }
            if (lasku.euro > 999999) { lasku.euro = 0; textBoxeuro.Text = "0"; return; }
            if (lasku.euro < 0) { lasku.euro = 0; textBoxeuro.Text = "0"; return; }

            try { lasku.sentti = int.Parse(textBoxsentti.Text); } catch { lasku.sentti = 0; textBoxsentti.Text = "";  }
            if (lasku.sentti > 99) { lasku.sentti = 0; textBoxsentti.Text = "0"; return; }
            if (lasku.sentti < 0) { lasku.sentti = 0; textBoxsentti.Text = "0"; return; }

            


            laskuttaja.tilinumero = textBoxtili.Text;
            laskuttaja.nimi = textBoxsaaja.Text;
            laskuttaja.bic = textBoxbic.Text;


            henkilö.nimi = textBoxmaksaja.Text;
            henkilö.osoite = textBoxosoite.Text;


            string eurosentti = lasku.euro.ToString() + "," + lasku.sentti.ToString().PadLeft(2, '0');

            
            
            if (textBoxviite.Text.Length >= 3) {

                lasku.viite = textBoxviite.Text + op.LaskeViiteTarkiste(textBoxviite.Text);

            };




            string viivakoodi = "";
            string viivakoodijaoteltuna="";
              if(textBoxviite.Text.Length >= 3 && textBoxtili.Text != "")  {
                int[] viivat = op.LaskeKoodatut(lasku, laskuttaja);

                foreach (int merkki in viivat)
                {
                    viivakoodi += (char)merkki;
                    viivakoodijaoteltuna+=""+merkki+" | ";
                }

            }
            


            





            


            Form2 kuva = new Form2();
            kuva.Show();

            //File.Create("c:\\temp\\tilisiirtocanvas.bmp");
            Bitmap canvas= new Bitmap("c:\\temp\\tilisiirtocanvas.bmp");
            
            Graphics gs = Graphics.FromImage(canvas);

            

            Font font = new Font("Tahoma", 30);
            Brush brush = Brushes.Black;

            gs.DrawString("FI"+ns.JaotteleTili(laskuttaja), font, brush,140,50);
            gs.DrawString(laskuttaja.nimi, font, brush,140,140);
            gs.DrawString(henkilö.nimi, font, brush,140,250-25);
            gs.DrawString(henkilö.osoite, font, brush, 140, 310-25);
            gs.DrawString(laskuttaja.bic, font, brush,770,50);
            gs.DrawString(ns.JaotteleViite(lasku), font, brush,810-15,380-10);
            gs.DrawString(lasku.eräpäivä.ToShortDateString(), font, brush,810-15,440-10);
            gs.DrawString(eurosentti, font, brush,1080-20,440-10);
            
            //debug jos eri versio code 128 fonttitiedostosta
            //gs.DrawString(viivakoodi, font, brush, 100, 570);
			//gs.DrawString(viivakoodijaoteltuna, font, brush, 100, 620);
 			gs.DrawString(viivakoodi, fonttiviiva, brush, 100, 550);
			


            kuva.pictureBox1.Image = canvas;

            

            canvas.Save("c:\\temp\\tilisiirtotallenne.bmp");
            
            
            

            
            





        }
    }
}
