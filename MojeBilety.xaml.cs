using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy MojeBilety.xaml
    /// </summary>
    public partial class MojeBilety : Window
    {
        private ZarzadzanieBiletami zarzadzanieBiletami;
        public MojeBilety()
        {
            InitializeComponent();
            zarzadzanieBiletami = new ZarzadzanieBiletami();

            lbMojeBilety.ItemsSource = zarzadzanieBiletami.listaBiletow;
            

            //zespol = (Zespol)Zespol.OdczytXml("zespol.xml"); // nazwa pliku + właściwa ścieżka!
            //if (zespol is object)
            //{
            //    lstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.Czlonkowie);
            //    txtNazwa.Text = zespol.Nazwa;
            //    txtKierownik.Text = zespol.Kierownik.ToString();
            //}
        }

        private void BtnDataKupnaSort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
