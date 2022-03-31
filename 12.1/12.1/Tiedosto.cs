using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using ElainLuokat;
//StreamReader - luokasta. "using StreamReader;


//t.12.1 - 12.3

/*
namespace _12._1
{
    public class Tiedosto
    { 
        static void Main(string[] args)
        {
            FileInfo fi = new("Hello.txt");
            using (TextWriter z = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                z.Write("");
            }

            using (StreamWriter y = new("Hello.txt"))
            {
                y.WriteLine("Hello world");
                y.WriteLine("Uusi rivi tässä");
            }
            string readText = File.ReadAllText("Hello.txt");
            Console.WriteLine(readText);

            Console.WriteLine("Anna tiedoston nimi: ");
            string x = Console.ReadLine();

            //etsittävä tiedosto on Hello.txt
            if (File.Exists(x))
            {
                Console.WriteLine("Tiedosto " + x + " on olemassa");
                bool w = true;
                if (w == true)
                {
                    Console.WriteLine("Taulukkona; ");
                    foreach (string s in LueRivitTaulukoksi(x))
                        Console.WriteLine(s);

                    Console.WriteLine("Listana; ");
                    foreach(string z in LueRivitListaksi(x))
                        Console.WriteLine(z);

                    Console.WriteLine("Merkkijonona; ");
                    Console.WriteLine(LueRivitMerkkijonoksi(x));
                }
            }
            else
            {
                Console.WriteLine("Tiedosto " + x + " ei ole olemassa");
            }
        }
        
        public static string[] LueRivitTaulukoksi(string filename)
        {
            string[] rivit;
            rivit = File.ReadAllLines(filename);
            return rivit;
        }
        public static List<string> LueRivitListaksi(string filename)
        {
            string[] rivit = LueRivitTaulukoksi(filename);
            List<string> rivilistat = new List<string>(rivit);
            return rivilistat;
        }
        public static string LueRivitMerkkijonoksi(string filename)
        {
            string [] rivit = LueRivitTaulukoksi(filename);
            string z = "";
            foreach (string rivi in rivit)
            {
                z += rivi;
            }
            return z;
        }
        
    }
}
*/


//t.12.4 - 12.5

/*
namespace _12._1
{
    public class Tiedosto
    {
        public static void Main()
        {
            string path = @"C:\Users\gr265789\OneDrive - Jyväskylän koulutuskuntayhtymä Gradia\C#\Tiedostojen käsittely\12.1\12.1\bin\Debug\net5.0\Hello.txt";

           
                Console.WriteLine("Nykyinen sisältö; ");
                foreach (string ss in LueRivitTaulukoksi(path))
                    Console.WriteLine(ss);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("Huuhaa!");
            }

            Console.WriteLine("Nykyinen sisältö; ");
            string[] s = LueRivitTaulukoksi(path);
            foreach (string ss in s)
                Console.WriteLine(ss);

            foreach (string ss in s)
                foreach (char ch in ss)
                {
                    Console.Write(ch+ ",");
                }

            if (!File.Exists(path))
            {
                Console.WriteLine("File exists");
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello world");
                    sw.WriteLine("uusi rivi tässä");
                }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string ss = "";
                while ((ss = sr.ReadLine()) != null)
                {
                    Console.WriteLine(ss);
                }
            }
        }
        public static string[] LueRivitTaulukoksi(string filename)
        {
            string[] rivit;
            rivit = File.ReadAllLines(filename);
            return rivit;
        }
        public static List<string> LueRivitListaksi(string filename)
        {
            string[] rivit = LueRivitTaulukoksi(filename);
            List<string> rivilistat = new List<string>(rivit);
            return rivilistat;
        }
        public static string LueRivitMerkkijonoksi(string filename)
        {
            string[] rivit = LueRivitTaulukoksi(filename);
            string z = "";
            foreach (string rivi in rivit)
            {
                z += rivi;
            }
            return z;
        }
    }
}
*/


//t 12.6

/*
namespace _12._1
{
    public class Tiedosto
    {
        static void Main(string[] args)
        {
            int x = -1;
            double y = 3.14159265;

            using (BinaryWriter binWriter =
                new BinaryWriter(File.Open("binary.bin", FileMode.Create)))
            { 
                binWriter.Write(x);
                binWriter.Write(y);
            }
            Console.WriteLine("Nykyinen sisältö; ");
            string[] s = LueRivitTaulukoksi("binary.bin");
            foreach (string ss in s)
                Console.WriteLine(ss);

            foreach (string ss in s)
                foreach (char ch in ss)
                {
                    Console.Write(((byte)ch).ToString() + ",");
                }
        }
        public static string[] LueRivitTaulukoksi(string filename)
        {
            string[] rivit;
            rivit = File.ReadAllLines(filename);
            return rivit;
        }
        //notepad näkymä "ÿÿÿÿñÔÈSû!	@"
    }
}
*/


//t 12.7

/*
class Tiedosto
{
    static void Main()
    {
        string path = Directory.GetCurrentDirectory();
        IEnumerable<string> lista = Directory.EnumerateFiles(path);
        foreach (string file in lista)
        {
            Console.Write(file + " ");
            FileInfo fi = new FileInfo(file);
            Console.Write(fi.Length + " ");
            Console.WriteLine(fi.CreationTime);
        }
    }
}
*/


//t 12.8

class Tiedosto
{
    static void Main()
    {
        using (FileStream fs = new FileStream("Elainluokat.dll", FileMode.Open, FileAccess.Read))
        {
            long size = fs.Length;
            Console.WriteLine("File Size in Bytes: {0}", size);
            long a = size - 1;
            while (true)
            {
                fs.Seek(a, SeekOrigin.Begin);
                int x = fs.ReadByte();
                Console.Write("{0:X2} ", x);
                a = a - 10;
                //lasketaan uusi paikka
                if (a <= -1) { break; }
            }
        }
    }
}

/*
 ## 12.8 
Käytä C#-kielen FileStream luokkia hyväksesi seuraavassa tehtävässä. 
-Tee ohjelma, joka tulostaa ElainLuokka.dll tiedoston sisällön 
 joka kymmenennen tavun takaperin, välilyönneillä erotettuina 
 heksadesimaalikoodeina. 

Esim:
0xFE 0xA7 0x00 …
 */