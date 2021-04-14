using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Balkezesek
{
    class Program
    {
        static List<Jatekos> jatekosLista = new List<Jatekos>();
        static void Main(string[] args)
        {
            string[] sor = File.ReadAllLines("balkezesek.csv", Encoding.Default);
            int sorhossz = sor.Length;
            for (int i = 1; i < sorhossz; i++)
            {
                jatekosLista.Add(new Jatekos(sor[i]));
            }
            OsszesVersenyzo();

            Console.ReadLine();
        }

        private static void OsszesVersenyzo()
        {
            int db = jatekosLista.Count;
            Console.WriteLine($"1. feladat: Összesen {db} versenyző van.");
        }
    }
}
