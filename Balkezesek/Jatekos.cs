using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    class Jatekos
    {
        public string nev { get; set; }
        public string elso { get; set; }
        public string utolso { get; set; }
        public int suly { get; set; }
        public int magassag { get; set; }
        public Jatekos(string adatsor)
        {
            string[] reszek = adatsor.Split(';');
          
            nev = reszek[0];
            elso = reszek[1];
            utolso = reszek[2];
            suly = int.Parse(reszek[3]);
            magassag = int.Parse(reszek[4]);
        }
    }
}
