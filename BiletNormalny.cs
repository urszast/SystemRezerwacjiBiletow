using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRezerwacjiBiletow
{
    public class BiletNormalny:Bilet
    {
        //private RodzajBiletu rodzaj = RodzajBiletu.normalny;
        private decimal cena=7.00m;
        public override RodzajBiletu Rodzaj => RodzajBiletu.normalny;
        //public RodzajBiletu Rodzaj { get => rodzaj; set => rodzaj = value; }
        public decimal Cena { get => cena; set => cena = value; }
    }
}
