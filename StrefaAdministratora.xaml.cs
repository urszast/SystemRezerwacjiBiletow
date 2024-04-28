using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy StrefaAdministratora.xaml
    /// </summary>
    public partial class StrefaAdministratora : Window
    {
        private ZarzadzanieBiletami zarzadzanieBiletami;
        public StrefaAdministratora()
        {
            InitializeComponent();
            zarzadzanieBiletami = new ZarzadzanieBiletami();
            lbZakupioneBilety.ItemsSource = zarzadzanieBiletami.listaBiletowUlgowych.Cast<Bilet>().Concat(zarzadzanieBiletami.listaBiletowNormalnych.Cast<Bilet>()).ToList();

        }

        private void BtnDataKupnaSort_Click(object sender, RoutedEventArgs e)
        {
            this.lbZakupioneBilety.Items.SortDescriptions.Clear();
            this.lbZakupioneBilety.Items.SortDescriptions.Add(
                new SortDescription(nameof(Bilet.DataKupna), ListSortDirection.Ascending));
        }

        private void BtnImieNazwiskoSort_Click(object sender, RoutedEventArgs e)
        {
            this.lbZakupioneBilety.Items.SortDescriptions.Clear();
            this.lbZakupioneBilety.Items.SortDescriptions.Add(
                new SortDescription(nameof(Bilet.ImieNazwisko), ListSortDirection.Ascending));
        }

        private void BtnIdKursuSort_Click(object sender, RoutedEventArgs e)
        {
            this.lbZakupioneBilety.Items.SortDescriptions.Clear();
            this.lbZakupioneBilety.Items.SortDescriptions.Add(
                new SortDescription(nameof(Bilet.IdKursu), ListSortDirection.Ascending));
        }

        private void BtnIdBiletuSort_Click(object sender, RoutedEventArgs e)
        {
            this.lbZakupioneBilety.Items.SortDescriptions.Clear();
            this.lbZakupioneBilety.Items.SortDescriptions.Add(
                new SortDescription(nameof(Bilet.IdBiletu), ListSortDirection.Ascending));
        }

        private void BtnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Close();
        }
    }
}
