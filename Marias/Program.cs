using System;
using System.Collections.Generic;
using System.Text;

namespace Marias
{
    public enum Szin
    {
        Zold, Makk, Piros, Tok
    }

    public enum FiguraErtek
    {
        Het = 7,
        Nyolc = 8,
        Kilenc = 9,
        Tiz = 10,
        Also = 2,
        Felso = 3,
        Kiraly = 4,
        Asz = 11
    }

    public class Kartya

    {
        //Tagok, mezők
        private readonly Szin szin;
        private readonly FiguraErtek figuraErtek;

        //Propertyk
        public Szin Szin { get { return szin; } }
        public FiguraErtek FiguraErtek { get { return figuraErtek; } }

        //Konstruktor
        public Kartya(Szin szin, FiguraErtek figuraErtek)
        {
            this.szin = szin;
            this.figuraErtek = figuraErtek;
        }


        // Override
        public override string ToString()
        {
            return "The " + figuraErtek.ToString() + " of " + szin.ToString();
        }
    }


    public class Pakli
    {
        //Tagok, mezők
        private string sPakli;
        protected List<Kartya> kartyak = new List<Kartya>();
        private Random random;

        //Propertyk
        public Kartya this [int position] { get { return (Kartya)kartyak[position]; }}
        public int Kartyak { get { return kartyak.Count; }}

        //Konstruktor
        public Pakli()
        {
            foreach (Szin sz in Enum.GetValues(typeof(Szin)))
            {
                foreach (FiguraErtek f in Enum.GetValues(typeof(FiguraErtek)))
                {
                    kartyak.Add(new Kartya(sz, f));
                }
            }
        }

        private void KartyaCsere(int index1, int index2)
        {
            Kartya kartya = kartyak[index1];
            kartyak[index1] = kartyak[index2];
            kartyak[index2] = kartya;
        }


        public override string ToString()
        {
            foreach (Kartya k in kartyak)
            {
                sPakli += string.Format("{0}\n", k);
            }
            return sPakli;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Pakli p = new Pakli();
            Console.Write("Kártyák száma: " + Pakli());


        }
    }
}
