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
            BekertEvAdatai();
            LegkorabbiEv();
            Volte2000utan();
            HanyJohnVan();
            Statisztika();

            Console.ReadLine();
        }

        private static void Statisztika()
        {
            Dictionary<string, int> konyvtar = new Dictionary<string, int>();
            foreach (var jatekos in jatekosLista)
            {
                string[] resz = jatekos.nev.Split(' ');
                if (konyvtar.ContainsKey(resz[0]))
                {
                    konyvtar[resz[0]]++;               
                }
                else
                {                  
                    konyvtar.Add(resz[0], 1);
                }
            }
            StreamWriter iro = new StreamWriter("kernevek.txt", false, Encoding.UTF8);
            foreach (var item in konyvtar)
            {
                iro.WriteLine(item.Key+ " - "+ item.Value);
            }
            iro.Close();
        }

        private static void HanyJohnVan()
        {
            Console.WriteLine("7. feladat:");
            foreach (var jatekos in jatekosLista)
            {
                if (jatekos.nev.Contains("John"))
                {
                    Console.WriteLine($"\t{jatekos.nev}");
                }
            }
        }

        private static void Volte2000utan() //rossz megoldás
        {
            bool igaze = false;
            foreach (var jatekos in jatekosLista)
            {
                if (jatekos.utolso.Contains("200"))
                {
                    igaze = true;
                }            
            }
            if (igaze)
                Console.WriteLine("NEM minden jatekos 2000 elott lepett pályára ");
            else
                Console.WriteLine("Minden jatekos 2000 elott lepett palyara");
        }

        private static void LegkorabbiEv()
        {
            int minindex = 0;
            int hossz = jatekosLista.Count;
            jatekosLista.OrderBy(x => x.elso);
            Console.WriteLine($"5. feldadat: A legelső pályárálépés: {jatekosLista[0].elso}");
        }

        private static void BekertEvAdatai()
        {
            Console.WriteLine("4. feladat:");
            int evszam;
            bool mehet = true;
            do
            {
                Console.Write("Kérek egy számot 1900 és 1999 között: ");
                evszam = int.Parse(Console.ReadLine());
                if (evszam>1900 && evszam<1999)
                {
                    mehet = false;
                }
                else
                {
                    Console.WriteLine("probalkozzon ujra");
                }
            } while (mehet);
            foreach (var jatekos in jatekosLista)
            {
                if (jatekos.elso.Contains(evszam.ToString()))
                {
                    Console.WriteLine($"\t{jatekos.nev},{jatekos.elso},{jatekos.utolso},{jatekos.suly},{jatekos.magassag}");
                }
            }
        }

        private static void BekertSpecJatekos()
        {
            Console.Write("3. feladat: Kérek egy játékos nevet: ");
            string bekertJatekos = Console.ReadLine();

            int listahossz = jatekosLista.Count;
            int index = 0;
            int i = 0;
            for (i = 0; i < listahossz; i++)
            {
                if (Specjatekosok.Contains(bekertJatekos) && jatekosLista[i].nev.Contains(bekertJatekos))
                    index = i;
            }
            if (index > 0)
            {
                Console.WriteLine($"A bekert játékos {bekertJatekos} magassága {jatekosLista[index].magassag * 2.56:N1}");
            }
            else
            {
                Console.WriteLine("hibás adat.");
            }

        }

        private static void ElsoVersenyzok(string adottEv)
        {
            Console.WriteLine("2. feladat: Az adott első évükben pályára lépett jatékosok: ");
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
