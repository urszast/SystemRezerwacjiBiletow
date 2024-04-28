using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRezerwacjiBiletow
{

    public abstract class Bilet : IComparable<Bilet>, IEquatable<Bilet>
    {
        private static int idStatic = 2137;
        private string imieNazwisko;
        private string email;
        private int idBiletu;
        private string nrTelefonu;
        private RodzajBiletu rodzaj;
        private DateTime dataKupna;
        private string idKursu;
        //private decimal cena;

        public string ImieNazwisko { get => imieNazwisko; set => imieNazwisko = value; }
        public string Email { get => email; set => email = value; }
        public string NrTelefonu { get => nrTelefonu; set => nrTelefonu = value; }
        public abstract RodzajBiletu Rodzaj { get; }
        public DateTime DataKupna { get => dataKupna; set => dataKupna = value; }
        //public decimal Cena { get => cena; set => cena = value; }
        public string IdKursu { get => idKursu; set => idKursu = value; }
        public static int IdStatic { get => idStatic; set => idStatic = value; }
        public int IdBiletu { get => idBiletu; set => idBiletu = value; }

        public Bilet()
        {
            IdBiletu = idStatic++;
        }

        public int CompareTo(Bilet? other)
        {
            if (other == null) { return -1; }
            int cmp = ImieNazwisko.CompareTo(other.ImieNazwisko);
            if (cmp != 0) { return cmp; }
            return IdBiletu.CompareTo(other.IdBiletu);
            //throw new NotImplementedException();
        }

        public bool Equals(Bilet? other)
        {
            if (other == null) { return false; }
            return IdBiletu.Equals(other.IdBiletu);
            //throw new NotImplementedException();
        }
    }

    public enum RodzajBiletu { normalny, ulgowy }
}
