using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRezerwacjiBiletow
{
    public class Kurs:ICloneable
    {
        private Autobus autobus;
        private int dostepneMiejsca;
        private Trasa trasa;
        private DateTime dataKursu;
        private string godzina;
        private string idKursu;
        public string IdKursu
        {
            get => $"{DataKursu:yyyyMMdd}_{Godzina.Replace(":", "")}_{Trasa}";
            set => idKursu = value; 
        }

        public Autobus Autobus { get => autobus; set => autobus = value; }
        public DateTime DataKursu { get => dataKursu; set => dataKursu = value; }
        public int DostepneMiejsca { get => dostepneMiejsca; set => dostepneMiejsca = value; }
        public Trasa Trasa { get => trasa; set => trasa = value; }
        public string Godzina { get => godzina; set => godzina = value; }

        public object Clone()
        {
            return MemberwiseClone();
            //throw new NotImplementedException();
        }
    }
    public enum Autobus
    {
        LLE10470,
        LLE10471,
        LLE42357,
        LLE42358
    }

    public enum Trasa
    {
        Leczna_Lublin,
        Lublin_Leczna
    }
}
