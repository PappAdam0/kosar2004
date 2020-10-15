using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
    class Program

    {
        static List<Meccs> meccsek = new List<Meccs>();
        static Dictionary<string, int> stadion = new Dictionary<string, int>();

        static void masodik()
        {
            StreamReader be = new StreamReader("eredmenyek.csv");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                
                meccsek.Add(new Meccs(be.ReadLine()));
            }
            be.Close();
            Console.WriteLine(meccsek.Count);
        }

        static void harmadik()
        {
            int hazai = 0;
            int vendeg = 0;
            foreach (var i in meccsek)
            {
                if (i.Hazai == "Real Madrid")
                {
                    hazai++;
                }
                if (i.Idegen == "Real Madrid")
                {
                    vendeg++;
                }
            }
            Console.WriteLine($"3. Feladat: Real Madrid: Hazai:{hazai} Vendég:{vendeg}");

        }

        static void negyedik()
        {
            bool dontetlen = false;
            foreach (var i in meccsek)
            {
                if (i.HPont == i.IPont)
                {
                    dontetlen = true;
                }
            }
            if (dontetlen)
            {
                Console.WriteLine("4. Feladat: Volt döntetlen? Igen");
            }
            else
            {
                Console.WriteLine("4. Feladat: Volt döntetlen? Nem");
            }
        }

        static void otodik()
        {
            string bnev = "";
            foreach (var i in meccsek)
            {
                if (i.Hazai.Contains("Barcelona"))
                {
                    bnev = i.Hazai;
                }
            }
            Console.WriteLine($"5. Feladat: barcelonai csapat teljes neve: {bnev}");
        }

        static void hatodik()
        {
            Console.WriteLine("6.Feladat:");
            var nov = from n in meccsek
                      where n.Ido == "2004-11-21"
                      select n;

            foreach (var i in nov)
            {
                Console.WriteLine($"\t{i.Hazai} - {i.Idegen} ({i.HPont}:{i.IPont})");
            }
        }
        static void hetedik()
        {
            Console.WriteLine("7.Feladat: ");
            foreach (var i in meccsek)
            {
                if (!stadion.ContainsKey(i.Hely))
                {
                    stadion.Add(i.Hely, 0);
                }
            }
            foreach (var i in meccsek)
            {
                stadion[i.Hely]++;
            }
            foreach (var i in stadion)
            {
                if (i.Value > 20)
                {
                    Console.WriteLine($"\t{i.Key}: {i.Value}");
                }
            }
        }
        static void Main(string[] args)
        {
            
            //var h = new Meccs("7up Joventut", "Adecco Estudiantes", 81, 73, "Palacio Mun. De Deportes De Badalona", "2005 - 04 - 03");
            //Console.WriteLine($"{h.Hazai} - {h.Idegen} {h.HPont}:{h.IPont}");
            masodik();
            harmadik();
            negyedik();
            otodik();
            hatodik();
            hetedik();
            Console.ReadKey();
        }
    }
}
