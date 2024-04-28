using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace SystemRezerwacjiBiletow
{
    /// <summary>
    /// Logika interakcji dla klasy ZakupBiletu.xaml
    /// </summary>
    public partial class ZakupBiletu : Window
    {
        private Kurs wybranyKurs;
        private List<Kurs> listaKursow;

        public ZakupBiletu()
        {
            InitializeComponent();
            listaKursow = PobierzDostepneKursy();
            TrasaCb.ItemsSource = Enum.GetValues(typeof(Trasa));
            GodzinaCb.SelectionChanged += GodzinaCb_SelectionChanged;
        }

        private void DalejBtn_Click(object sender, RoutedEventArgs e)
        {
            //SprawdzPola();

            if (wybranyKurs == null)
            {
                MessageBox.Show("Wybierz kurs przed kontynuacją!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            //if (NRbtn.IsChecked == true)
            //{
            //    BiletNormalny nowyBilet = new BiletNormalny()
            //    {
            //        ImieNazwisko = NazwiskoTb.Text,
            //        Email = EmailTb.Text,
            //        NrTelefonu = TelefonTb.Text,
            //        IdKursu = wybranyKurs.IdKursu,
            //        DataKupna = DateTime.Now,
            //    };
            //    //nowyBilet.Rodzaj = RodzajBiletu.normalny;
            //    //nowyBilet.Cena = ObliczCeneBiletu(RodzajBiletu.normalny);
            //}
            //else if (URbtn.IsChecked == true)
            //{
            //    BiletUlgowy nowyBilet = new BiletUlgowy()
            //    {
            //        ImieNazwisko = NazwiskoTb.Text,
            //        Email = EmailTb.Text,
            //        NrTelefonu = TelefonTb.Text,
            //        IdKursu = wybranyKurs.IdKursu,
            //        DataKupna = DateTime.Now,
            //    };
            //    nowyBilet.Rodzaj = RodzajBiletu.ulgowy;
            //    nowyBilet.Cena = ObliczCeneBiletu(RodzajBiletu.ulgowy);
            //}
            //else
            //{
            //    MessageBox.Show("Wybierz rodzaj biletu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            //    //return;
            //}

            if(SprawdzPola()==true)
            {
                //Bilet nowyBilet = new Bilet()
                ////Bilet nowyBilet = new Bilet(NazwiskoTb.Text, wybranyKurs.IdKursu)
                //{
                //    ImieNazwisko = NazwiskoTb.Text,
                //    Email = EmailTb.Text,
                //    NrTelefonu = TelefonTb.Text,
                //    IdKursu = wybranyKurs.IdKursu,
                //    DataKupna = DateTime.Now,
                //};
                if (NRbtn.IsChecked == true)
                {
                    BiletNormalny nowyBilet = new BiletNormalny()
                    {
                        ImieNazwisko = NazwiskoTb.Text,
                        Email = EmailTb.Text,
                        NrTelefonu = TelefonTb.Text,
                        IdKursu = wybranyKurs.IdKursu,
                        DataKupna = DateTime.Now,
                    };
                    PotwierdzenieN potwierdzenie = new PotwierdzenieN(nowyBilet);
                    if (potwierdzenie.ShowDialog() == true)
                    {
                        var zarzadzanieBiletami = new ZarzadzanieBiletami();
                        if (zarzadzanieBiletami.KupBiletNormalny(nowyBilet))
                        {
                            MessageBoxResult result = MessageBox.Show("Bilet został pomyślnie kupiony.\nBilet PDF został zapisany na urządzeniu.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                            if (result == MessageBoxResult.OK)
                            {
                                MainWindow mainW = new();
                                mainW.Show();
                                this.Close();
                            }
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Nie można kupić biletu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //nowyBilet.Rodzaj = RodzajBiletu.normalny;
                    //nowyBilet.Cena = ObliczCeneBiletu(RodzajBiletu.normalny);
                }
                else if (URbtn.IsChecked == true)
                {
                    BiletUlgowy nowyBilet = new BiletUlgowy()
                    {
                        ImieNazwisko = NazwiskoTb.Text,
                        Email = EmailTb.Text,
                        NrTelefonu = TelefonTb.Text,
                        IdKursu = wybranyKurs.IdKursu,
                        DataKupna = DateTime.Now,
                    };
                    PotwierdzenieU potwierdzenie = new PotwierdzenieU(nowyBilet);
                    if (potwierdzenie.ShowDialog() == true)
                    {
                        var zarzadzanieBiletami = new ZarzadzanieBiletami();
                        if (zarzadzanieBiletami.KupBiletUlgowy(nowyBilet))
                        {
                            MessageBoxResult result = MessageBox.Show("Bilet został pomyślnie kupiony.\nBilet PDF został zapisany na urządzeniu.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                            if (result == MessageBoxResult.OK)
                            {
                                MainWindow mainW = new();
                                mainW.Show();
                                this.Close();
                            }
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Nie można kupić biletu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //nowyBilet.Rodzaj = RodzajBiletu.ulgowy;
                    //nowyBilet.Cena = ObliczCeneBiletu(RodzajBiletu.ulgowy);
                }
                else
                {
                    MessageBox.Show("Wybierz rodzaj biletu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    //return;
                }

                //if (NRbtn.IsChecked == true)
                //{
                //    nowyBilet.Rodzaj = RodzajBiletu.normalny;
                //    nowyBilet.Cena = ObliczCeneBiletu(RodzajBiletu.normalny);
                //}
                //else if (URbtn.IsChecked == true)
                //{
                //    nowyBilet.Rodzaj = RodzajBiletu.ulgowy;
                //    nowyBilet.Cena = ObliczCeneBiletu(RodzajBiletu.ulgowy);
                //}

                //Potwierdzenie potwierdzenie = new Potwierdzenie(nowyBilet);

                //if (potwierdzenie.ShowDialog() == true)
                //{
                //    var zarzadzanieBiletami = new ZarzadzanieBiletami();
                //    if (zarzadzanieBiletami.KupBilet(nowyBilet))
                //    {
                //        MessageBoxResult result = MessageBox.Show("Bilet został pomyślnie kupiony.\nBilet PDF został zapisany na urządzeniu.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                //        if (result == MessageBoxResult.OK)
                //        {
                //            MainWindow mainW = new();
                //            mainW.Show();
                //            this.Close();
                //        }
                //        return;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Nie można kupić biletu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                //    }
                //}
            }
        }
        bool SprawdzImieNazwisko(string imienazwisko) //ZADANIE 4 - metoda sprawdzajaca za pomoca Regex, czy numer telefonu ma postac 000-000-000
        {
            string wzorzec = @"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+ [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+$";
            return Regex.IsMatch(imienazwisko, wzorzec);
        }
        bool SprawdzEmail(string email) //ZADANIE 4 - metoda sprawdzajaca za pomoca Regex, czy numer telefonu ma postac 000-000-000
        {
            string wzorzec = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, wzorzec);
        }
        bool SprawdzNumer(string numer) //ZADANIE 4 - metoda sprawdzajaca za pomoca Regex, czy numer telefonu ma postac 000-000-000
        {
            string wzorzec = @"^\d{3}-\d{3}-\d{3}$";
            return Regex.IsMatch(numer, wzorzec);
        }

        private bool SprawdzPola()
        {
            if (string.IsNullOrWhiteSpace(NazwiskoTb.Text) ||
                string.IsNullOrWhiteSpace(EmailTb.Text) ||
                string.IsNullOrWhiteSpace(TelefonTb.Text) ||
                TrasaCb.SelectedIndex == -1 ||
                GodzinaCb.SelectedIndex == -1)
            {
                MessageBox.Show("Wypełnij wszystkie pola przed kontynuacją!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SprawdzImieNazwisko(NazwiskoTb.Text) == false)
            {
                MessageBox.Show("Wpisz poprawne imię i nazwisko!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SprawdzEmail(EmailTb.Text) == false)
            {
                MessageBox.Show("Wpisz poprawny adres email!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SprawdzNumer(TelefonTb.Text) == false)
            {
                MessageBox.Show("Wpisz numer telefonu w poprawnym formacie (000-000-000)!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NRbtn.IsChecked==false && URbtn.IsChecked==false)
            {
                MessageBox.Show("Wybierz rodzaj biletu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else { return true; }
        }


        
        private List<Kurs> PobierzDostepneKursy()
        {
            ZarzadzanieBiletami zarzadzanieBiletami = new(); 
            return zarzadzanieBiletami.PobierzDostepneKursy(); 
        }
        private decimal ObliczCeneBiletu(RodzajBiletu rodzajBiletu)
        {
            if (rodzajBiletu == RodzajBiletu.normalny)
            {
                return 7.0m; 
            }
            else if (rodzajBiletu == RodzajBiletu.ulgowy)
            {
                return 5.50m; 
            }
            return 0.0m;
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            OdswiezKursy();
        }

        private void TrasaCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OdswiezKursy();
        }


        private void OdswiezKursy()
        {
            DateTime wybranaData = DatePicker.SelectedDate ?? DateTime.Now;

            Trasa? wybranaTrasa = (Trasa?)TrasaCb.SelectedItem;           

            var zarzadzanieBiletami = new ZarzadzanieBiletami();
            var dostepneKursy = zarzadzanieBiletami.PobierzDostepneKursy()
                .Where(kurs =>
                    kurs.Trasa == wybranaTrasa &&
                    kurs.DataKursu.Date == wybranaData.Date).ToList();

            GodzinaCb.ItemsSource = dostepneKursy;

            if (DatePicker.SelectedDate == null)
            {
                // Jeśli data nie została jeszcze wybrana, dezaktywuj kontrolkę GodzinaCb
                GodzinaCb.IsEnabled = false;
            }
            else
            {
                // Jeśli data została wybrana, aktywuj kontrolkę GodzinaCb
                GodzinaCb.IsEnabled = true;
                GodzinaCb.DisplayMemberPath = "Godzina";
            }
        }

        private void GodzinaCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GodzinaCb.SelectedItem != null)
                {
                    wybranyKurs = (Kurs)GodzinaCb.SelectedItem;
                }
            
        }
    }
}
