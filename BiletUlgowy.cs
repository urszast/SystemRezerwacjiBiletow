using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRezerwacjiBiletow
{
    public class BiletUlgowy:Bilet
    {
        //private RodzajBiletu rodzaj = RodzajBiletu.ulgowy;
        private decimal cena = 5.50m;
        public override RodzajBiletu Rodzaj => RodzajBiletu.ulgowy;
        //public RodzajBiletu Rodzaj { get => rodzaj; set => rodzaj = value; }
        public decimal Cena { get => cena; set => cena = value; }

    }
}
