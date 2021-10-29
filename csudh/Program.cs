using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csudh
{
    class Program
    {

        #region beolvas
        static List<Csudh> domainAdatok = new List<Csudh>();
        static void Beolvas()
        {
            string[] sorok = File.ReadAllLines("csudh.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                domainAdatok.Add(new Csudh(sorok[i]));
            }
        }
        #endregion

        #region 3. feladat
        static void feladat3()
        {
            Console.WriteLine($"3. feladat: Domainek száma: {domainAdatok.Count} db");
        }
        #endregion


        #region 4. feladat
        public static String Domain(String domain_nev, int szint)
        {
            string[] szoveg = domain_nev.Split('.');
            int index = szoveg.Length;
            if (index < szint)
            {
                return "nincs";
            }
            else
            {
                return szoveg[index - szint];
            }
        }
        #endregion


        #region 6. feladat
        static void feladat6()
        {
            Console.WriteLine($"6. feladat: table.html");
            FileStream tablazatFajl = new FileStream("table.html", FileMode.Create);
            StreamWriter fajlIras = new StreamWriter(tablazatFajl, Encoding.UTF8);
            fajlIras.Write("<!doctype html>");
            fajlIras.Write("<html>");
            fajlIras.Write("<head></head>");

            fajlIras.Write("<style>table {background-color: powderblue;} </style>");       //  szegély

            fajlIras.Write("<body>");

            fajlIras.Write("<table>");
            fajlIras.Write("<tr>");
            fajlIras.Write("<th style='text-align:left'>Ssz</th>");
            fajlIras.Write("<th style='text-align:left'>Host domain neve</th>");
            fajlIras.Write("<th style='text-align:left'>Host IP címe</th>");
            fajlIras.Write("<th style='text-align:left'>1. szint</th>");
            fajlIras.Write("<th style='text-align:left'>2. szint</th>");
            fajlIras.Write("<th style='text-align:left'>3. szint</th>");
            fajlIras.Write("<th style='text-align:left'>4. szint</th>");
            fajlIras.Write("<th style='text-align:left'>5. szint</th>");
            fajlIras.WriteLine("</tr>");
            int adatokszama = domainAdatok.Count;
            for (int i = 0; i < adatokszama; i++)
            {
                fajlIras.Write($"<tr><th style='text-align:center'>{i + 1}</th><td>{domainAdatok[i].DomainNev}</td><td>{domainAdatok[i].IpCim}</td>");
                for (int j = 0; j < 5; j++)
                {
                    fajlIras.Write($"<td>{ Domain(domainAdatok[i].DomainNev, j + 1)}</td>");
                }

                fajlIras.WriteLine("</tr>");
            }
            fajlIras.Write("</table>");
            fajlIras.Write("</body>");
            fajlIras.Write("</html>");
            fajlIras.Close();
            tablazatFajl.Close();
        }
        #endregion


        static void Main(string[] args)
        {
            Beolvas();
            feladat3();
            #region 5. feladat
            Console.WriteLine($"\n5. feladat: Az első domain felépítése:");
            for (int i = 1; i < 5+1; i++)
            {
                Console.WriteLine($"\t{i} szint: {Domain(domainAdatok[0].DomainNev, i)}");
            }
            #endregion
            feladat6();
            Console.ReadKey();
        }
    }
}
