using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laskutusohjelma
{

    public class Lasku {


        public DateTime eräpäivä;
        public int laskunumero;
        public string viite;
        public int euro;
        public int sentti;
        








    }



    public class Henkilo
    {
      public int id;
      public string nimi;
      public string osoite;
      public string puhelinnumero;


      public List<Lasku> laskut;



    }

    public class Laskuttaja
    {
        public string tilinumero;
        public string bic;
        public int id;
        public string nimi;
        public string osoite;
        public string puhelinnumero;

        public List<Henkilo> laskutettavat;

    }


}
