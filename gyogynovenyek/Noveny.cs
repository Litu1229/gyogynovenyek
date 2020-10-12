using System;
using System.Security.Cryptography.X509Certificates;

namespace gyogynovenyek
{
    internal class Noveny
    {
        public string Nev { get; private set; }
        public string Resz { get; private set; }
        public int Kezd { get; private set; }
        public int Veg { get; private set; }
        public int Idotartam { get; private set; }
        public Noveny(string sor)
        {
            string[] adat = sor.Split(';');
            Nev = adat[0];
            Resz = adat[1];
            Kezd = Convert.ToInt32(adat[2]);
            Veg = Convert.ToInt32(adat[3]);
            if (Veg > Kezd)
            {
                Idotartam = Veg - Kezd + 1;
            }
            else
            {
                Idotartam = 12 - (Veg + Kezd) + 1;
            }
        }
    }
}