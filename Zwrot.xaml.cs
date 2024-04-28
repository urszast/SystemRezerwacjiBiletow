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
    /// Logika interakcji dla klasy Zwrot.xaml
    /// </summary>
    public partial class Zwrot : Window
    {
        private ZarzadzanieBiletami zarzadzanieBiletami;
        public Zwrot()
        {
            InitializeComponent();
            zarzadzanieBiletami = new ZarzadzanieBiletami();
            ZwrotCb.ItemsSource = zarzadzanieBiletami.listaBiletowUlgowych.Cast<Bilet>().Concat(zarzadzanieBiletami.listaBiletowNormalnych.Cast<Bilet>()).ToList();
            ZwrotCb.DisplayMemberPath = "IdBiletu";
        }

        private void PowrotBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Close();
        }

        private void ZwrotBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ZwrotCb.SelectedItem != null)
            {
                Bilet biletDoZwrotu = (Bilet)ZwrotCb.SelectedItem;
                var zarzadzanieBiletami = new ZarzadzanieBiletami();
                if (biletDoZwrotu.Rodzaj == RodzajBiletu.ulgowy)
                {
                    bool sukces = zarzadzanieBiletami.ZwrocBiletUlgowy(biletDoZwrotu.IdBiletu);
                    if (sukces)
                    {
                        MessageBoxResult result = MessageBox.Show("Bilet ulgowy został zwrócony.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (result == MessageBoxResult.OK)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Nie udało się zwrócić biletu ulgowego.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

                        if (result == MessageBoxResult.OK)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                    }
                }
                else if (biletDoZwrotu.Rodzaj == RodzajBiletu.normalny)
                {
                    bool sukces = zarzadzanieBiletami.ZwrocBiletNormalny(biletDoZwrotu.IdBiletu);
                    if (sukces)
                    {
                        MessageBoxResult result = MessageBox.Show("Bilet normalny został zwrócony.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (result == MessageBoxResult.OK)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Nie udało się zwrócić biletu normalnego.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

                        if (result == MessageBoxResult.OK)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Nie udało się zwrócić biletu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

                    if (result == MessageBoxResult.OK)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }

                }
            }
        }

        private void ZwrotCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
