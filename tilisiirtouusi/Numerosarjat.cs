using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laskutusohjelma
{
    public class Numerosarjat
    {



        public bool TarkastaIBAN(string tili)
        {
            bool tarkiste = true;


            try
            {
                int len = tili.Length;
                string siirretty = "";

                for (int i = 2; i < len; i++)
                {
                    siirretty = siirretty + tili[i];


                }

                siirretty = siirretty + "1518" + tili[0] + tili[1];

                decimal sarja = decimal.Parse(siirretty);

                if (sarja % 97M == 1M) { tarkiste = true; }
                else { tarkiste = false; }

            }
            catch { tarkiste = false; }

          




            return tarkiste;
        }


        public string JaotteleViite(Lasku lasku)
        {

            string jaoteltu = "";

            try
            {
                int len = lasku.viite.Length;



                for (int i = 0, k = 1; i < len; i++)

                {
                    jaoteltu = lasku.viite[len - i - 1] + jaoteltu;

                    k++;
                    if (k == 6 && i != len - 1) { jaoteltu = " " + jaoteltu; k = 1; }

                }

            }
            catch { }//viitelenghtwasnull



            return jaoteltu;

        }




        public string JaotteleTili(Laskuttaja laskuttaja)
        {

            int len = laskuttaja.tilinumero.Length;

            string jaoteltu = "";


            for (int i = 0, k = 3; i < len; i++)

            {
                jaoteltu = jaoteltu + laskuttaja.tilinumero[i];

                k++;
                if (k == 5 && i != len - 1) { jaoteltu = jaoteltu + " "; k = 1; }


            }





            return jaoteltu;

        }




        public bool TarkastaMerkit(string a)
        {
            bool palaute = true;

            if (a != "")
                try
                {
                    decimal.Parse(a); palaute = true;
                }
                catch
                {
                   palaute=false; 

                }


            return palaute;



        }









    }
}
