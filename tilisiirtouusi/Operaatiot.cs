using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laskutusohjelma
{

    

    public class Operaatiot
    {
        private int Koodi (int arvo)//numero->ISO 8859-1
        	//Code 128 sisältää 107 symbolia
        	//mutta vastaavuus ei ole yksiselitteinen
        	//vastaavuus vaihtuu riippuen fonttitiedostosta
        	//esimerkkejä:
        	//arvo=ISO 8859-1 symboli=positio
        	//1=!=33 (sic)
        	//40=H=72
        	//94=~=126
        	//95=Ã=195 (hyppy tapahtunut)
        	//START CODE A=Ë=203 (tämä ei ole aloituskoodimme, lue lähteestä oikea)
        	//STOP PATTERN=Î=206 (päättää koodin)
        	//0=Ï=207 tai 32 (viimeinen eli ensimmäinen)
        {
            int x=new int();

            if (arvo<=94) {

                x = arvo+32;

            }
            
            if (arvo>=95)
            {
                x = arvo+100;
            }






            return x;


        }

        public int[] Koodaa(int[] arvot)
        {
            int pit = arvot.Length;

            int[] koodattu = new int[pit];


            


            for (int i = 0; i < pit; i++)
            {
                koodattu[i] = Koodi(arvot[i]);
            }


            return koodattu;


        }

        public int LaskeTarkiste(int[] arvot,int aloitus)
        {
            int pit = arvot.Length+1;
            int[] kertoimet = new int[pit];
            kertoimet[0] = aloitus;

            int kerroin = 1;
            

            for (int i = 1;i<pit;i++)
            {
                kertoimet[i] = kerroin * arvot[i-1];

                kerroin++;
            }

            int summa = kertoimet.Sum();
            return summa % 103;
            

        }


        public int[] JaaPareihin(string jono){

            
            int[] tulos = new int[jono.Length / 2];

            for (int i = 0; i < tulos.Length; i++) { tulos[i] = 10*(jono[2 * i]-48) + jono[2 * i + 1]-48; }
            return tulos;


        }


        public int[] LaskeKoodatut(Lasku lasku, Laskuttaja laskuttaja)
        {
            string tilinumero = laskuttaja.tilinumero;
            string eurot = lasku.euro.ToString().PadLeft(6, '0');
            string sentit = lasku.sentti.ToString().PadLeft(2,'0');
            string varalla = "000";
            string viitenumero = lasku.viite.PadLeft(20,'0');
            string versio = "4";
            string era = (lasku.eräpäivä.Year % 100).ToString().PadLeft(2,'0') + lasku.eräpäivä.Month.ToString().PadLeft(2,'0') + lasku.eräpäivä.Day.ToString().PadLeft(2,'0');
            int aloitus = 105;
            int lopetus = 106;


            string total = versio + tilinumero + eurot + sentit + varalla + viitenumero + era;


            int [] jaettu= JaaPareihin(total);
            int tarkiste = LaskeTarkiste(jaettu, aloitus);
            int[] koodaamaton = new int[jaettu.Length + 3];

            koodaamaton[0] = aloitus;
            for (int i = 1; i <= jaettu.Length; i++) { koodaamaton[i] = jaettu[i - 1]; }
            koodaamaton[jaettu.Length+1] = tarkiste;
            koodaamaton[jaettu.Length + 2] = lopetus;
            return Koodaa(koodaamaton);



        }




        public int LaskeViiteTarkiste(string a)
        {

            int kerroin = 7, summa = 0, tarkiste = 0;


            for (int i = a.Length - 1; i >= 0; i--)
            {
                summa = summa + (a[i] - 48) * kerroin;
                if (kerroin == 7)
                    kerroin = 3;
                else if (kerroin == 3)
                    kerroin = 1;
                else
                    kerroin = 7;
                tarkiste = 10 - summa % 10;
                tarkiste = tarkiste % 10;




            }

            return tarkiste;

        }













    }
}
