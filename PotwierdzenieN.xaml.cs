using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemRezerwacjiBiletow
{
    /// <summary>
    /// Logika interakcji dla klasy Potwierdzenie.xaml
    /// </summary>
    public partial class PotwierdzenieN : Window
    {
        private BiletNormalny nowyBilet;

        public bool CzyPotwierdzono { get; private set; } = false;

        public PotwierdzenieN(BiletNormalny nowyBilet)
        {
            InitializeComponent();
            this.nowyBilet = nowyBilet;
            WyswietlCene();
        }

        private void WyswietlCene()
        {
            CenaLbl.Content = $"Bilet nr: {nowyBilet.IdBiletu}\nRodzaj biletu: {nowyBilet.Rodzaj}\nCena: {nowyBilet.Cena:C2}";
        }

        private void AnulujBtn_Click(object sender, RoutedEventArgs e)
        {
            CzyPotwierdzono = false;
            this.Close(); 
        }

        private void PotwierdzamBtn_Click(object sender, RoutedEventArgs e)
        {
            CzyPotwierdzono = true;
            this.DialogResult = true;
            this.Close();
        }
    }
}
