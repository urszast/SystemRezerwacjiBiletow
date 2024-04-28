using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SystemRezerwacjiBiletow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRegulamin_Click(object sender, RoutedEventArgs e)
        {
            string regulamin = "Zakup biletów możliwy na 15 minut przed odjazdem autobusu. \nBilet nie daje gwarancji miejsca siedzącego. \nZwrot biletu możliwy na godzinę przed odjazdem autobusu.\nBilet upoważnia do ubezpieczenia na trasie przejazdu.\n";
            MessageBox.Show(regulamin, "Regulamin firmy Łęcz-Trans");
        }

        private void BtnKup_Click(object sender, RoutedEventArgs e)
        {
            ZakupBiletu zakup = new ();
            zakup.Show();
            this.Close();
        }

        private void BtnZwroc_Click(object sender, RoutedEventArgs e)
        {
            Zwrot zwrot = new ();
            zwrot.Show();   
            this.Close();   
        }

        private void BtnMojeBilety_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStrefa_Click(object sender, RoutedEventArgs e)
        {
            StrefaAdministratora strefaAdministratora = new();
            strefaAdministratora.Show();
            this.Close();
        }
    }
}