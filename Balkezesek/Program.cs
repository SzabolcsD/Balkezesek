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
        static List<string> Specjatekosok = new List<string>();
        static void Main(string[] args)
        {
            string[] sor = File.ReadAllLines("balkezesek.csv", Encoding.Default);
            int sorhossz = sor.Length;
            for (int i = 1; i < sorhossz; i++)
            {
                jatekosLista.Add(new Jatekos(sor[i]));
            }
            OsszesVersenyzo();
            ElsoVersenyzok("1980");
            BekertSpecJatekos();

            Console.ReadLine();
        }

        private static void BekertSpecJatekos()
        {
            Console.Write("Kérek egy játékos nevet: ");
            string bekertJatekos = Console.ReadLine();
            double magassag;

            foreach (var jatekos in jatekosLista)
            {
                if (Specjatekosok.Contains(bekertJatekos)&& jatekos.nev.Contains(bekertJatekos))
                {
                    magassag=jatekos.magassag*2.56;
                    Console.WriteLine($"A bekert játékos {bekertJatekos} magassága {jatekos.magassag*2.56:N1}");
                }
            }
        }

        private static void ElsoVersenyzok(string adottEv)
        {
            Console.WriteLine("Az adott első évükben pályára lépett jatékosok: ");
            foreach (var jatekos in jatekosLista)
            {
                if (jatekos.elso.Contains(adottEv))
                {
                    Console.WriteLine($"\t{jatekos.nev}");
                    Specjatekosok.Add(jatekos.nev);
                }
            }
        }

        private static void OsszesVersenyzo()
        {
            int db = jatekosLista.Count;
            Console.WriteLine($"1. feladat: Összesen {db} versenyző van.");
        }
    }
}
