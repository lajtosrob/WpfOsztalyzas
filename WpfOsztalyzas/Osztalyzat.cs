﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOsztalyzas
{
    public class Osztalyzat
    {
        String nev;
        String datum;
        String tantargy;
        int jegy;

        public Osztalyzat(string nev, string datum, string tantargy, int jegy)
        {
            this.nev = nev;
            this.datum = datum;
            this.tantargy = tantargy;
            this.jegy = jegy;
        }

        public string Nev { get => nev; }
        public string Datum { get => datum; }
        public string Tantargy { get => tantargy; }
        public int Jegy { get => jegy; }

        //public String VezetekNev { get => nev.Split(' ')[0];}
    }
}
