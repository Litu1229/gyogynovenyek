using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace gyogynovenyek
{
    class Program
    {
        static List<Noveny> lista = new List<Noveny>();
        static Dictionary<string, int> reszek = new Dictionary<string, int>();

        static void Beolvas()
        {
            StreamReader sr = new StreamReader("noveny.csv");
            while (!sr.EndOfStream)
            {
                lista.Add(new Noveny(sr.ReadLine()));
            }
            sr.Close();
            foreach (var i in lista)
            {
                Console.WriteLine(i.Nev);
            }
        }

        static void dbSzam()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("A növények száma: {0}",lista.Count);
        }
        static void feladat2()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Gyűjthető részek:");
            foreach (var n in lista)
            {
                if (!reszek.ContainsKey(n.Resz))
                {
                    reszek.Add(n.Resz, 0);
                }
            }
            foreach (var i in lista)
            {
                reszek[i.Resz]++;
            }
            foreach (var r in reszek)
            {
                Console.WriteLine($"{r.Key}: {r.Value}");
            }
        }
        static void Max()
        {
            int max = 0;
            string noveny = "";
            foreach (var i in lista)
            {
                if (i.Idotartam > max)
                {
                    max = i.Idotartam;
                    noveny = i.Nev;
                }
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("A legtöbb idő amíg gyűjthető: {0}",max);
            Console.WriteLine("Növény(ek): {0}",noveny);
        }

        static void negyedik()
        {
            double osszeg = 0;
            double atlag = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                osszeg = osszeg + lista[i].Idotartam;
            }
            atlag = osszeg / lista.Count;
            Console.WriteLine("--------------------");
            Console.WriteLine("Átlagos gyűjthető időtartam: {0}",atlag);
        }
        static void Main(string[] args)
        {
            var N = new Noveny("Acsalapu; levél; 6; 8");
            Beolvas();
            dbSzam();
            feladat2();
            Max();
            negyedik();
            Console.ReadKey();
        }
    }
}
