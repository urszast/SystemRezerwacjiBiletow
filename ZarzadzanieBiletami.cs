using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using System;
using QuestPDF.Infrastructure;
using QuestPDF;
using QuestPDF.Drawing;
using QuestPDF.Elements;
using QuestPDF.Fluent;
using static SystemRezerwacjiBiletow.ZarzadzanieBiletami;
using System.ComponentModel;
using QuestPDF.Helpers;


namespace SystemRezerwacjiBiletow
{
    [Serializable]
    public class ZarzadzanieBiletami: ListaBiletow
    {
        private List<Kurs> listaKursow;
        public ZarzadzanieBiletami()
        {
            listaKursow = new List<Kurs>();
            InicjalizujKursy();
            WczytajBilety();
        }

        private void InicjalizujKursy()
        {
            for (int i = 1; i <= 31; ++i) {
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE10470, DostepneMiejsca = 60, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Lublin_Leczna, Godzina = "05:40" });
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE42358, DostepneMiejsca = 30, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Leczna_Lublin, Godzina = "06:22" });
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE10471, DostepneMiejsca = 50, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Lublin_Leczna, Godzina = "07:10" });
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE10471, DostepneMiejsca = 50, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Leczna_Lublin, Godzina = "09:50" });
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE10470, DostepneMiejsca = 60, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Leczna_Lublin, Godzina = "11:47" });
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE42357, DostepneMiejsca = 40, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Lublin_Leczna, Godzina = "12:36" });
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE10471, DostepneMiejsca = 50, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Leczna_Lublin, Godzina = "13:45" });
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE10470, DostepneMiejsca = 60, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Lublin_Leczna, Godzina = "17:19" });
            listaKursow.Add(new Kurs { Autobus = Autobus.LLE42358, DostepneMiejsca = 30, DataKursu = new DateTime(2024, 5, i), Trasa = Trasa.Leczna_Lublin, Godzina = "22:22" });
        }
        }

        public List<Kurs> PobierzDostepneKursy()
        {
            return listaKursow.Where(kurs => kurs.DostepneMiejsca > 0).ToList();
        }
        public bool KupBiletUlgowy(BiletUlgowy nowyBilet)
        {
            Kurs wybranyKurs = listaKursow.FirstOrDefault(kurs => kurs.IdKursu == nowyBilet.IdKursu);

            if (wybranyKurs != null && wybranyKurs.DostepneMiejsca > 0)
            {
                nowyBilet.DataKupna = DateTime.Now;
                listaBiletowUlgowych.Add(nowyBilet);
                wybranyKurs.DostepneMiejsca--;
                ZapiszBilety();
                GenerujPdfUlgowy(nowyBilet);
                return true;
            }

            else
            {
                MessageBox.Show("Nie można kupić biletu!");
                return false;
            }
        }


        public bool KupBiletNormalny(BiletNormalny nowyBilet)
        {
            Kurs wybranyKurs = listaKursow.FirstOrDefault(kurs => kurs.IdKursu == nowyBilet.IdKursu);

            if (wybranyKurs != null && wybranyKurs.DostepneMiejsca > 0)
            {
                nowyBilet.DataKupna = DateTime.Now;
                listaBiletowNormalnych.Add(nowyBilet);
                wybranyKurs.DostepneMiejsca--;
                ZapiszBilety();
                GenerujPdfNormalny(nowyBilet);
                return true;
            }

            else
            {
                MessageBox.Show("Nie można kupić biletu!");
                return false;
            }
        }
        public bool ZwrocBiletUlgowy(int biletId)
        {
            BiletUlgowy zwroconyBilet = listaBiletowUlgowych.FirstOrDefault(bilet => bilet.IdBiletu == biletId);

            if (zwroconyBilet != null)
            {
                Kurs odpowiadajacyKurs = listaKursow.FirstOrDefault(kurs => kurs.IdKursu == zwroconyBilet.IdKursu);

                if (odpowiadajacyKurs != null)
                {
                    odpowiadajacyKurs.DostepneMiejsca++;
                    listaBiletowUlgowych.Remove(zwroconyBilet);
                    ZapiszBilety();
                    return true;
                }
            }

            return false;
        }
        public bool ZwrocBiletNormalny(int biletId)
        {
            BiletNormalny zwroconyBilet = listaBiletowNormalnych.FirstOrDefault(bilet => bilet.IdBiletu == biletId);

            if (zwroconyBilet != null)
            {
                Kurs odpowiadajacyKurs = listaKursow.FirstOrDefault(kurs => kurs.IdKursu == zwroconyBilet.IdKursu);

                if (odpowiadajacyKurs != null)
                {
                    odpowiadajacyKurs.DostepneMiejsca++;
                    listaBiletowNormalnych.Remove(zwroconyBilet);
                    ZapiszBilety();
                    return true;
                }
            }

            return false;
        }
        public void GenerujPdfUlgowy(BiletUlgowy nowyBilet)
        {
            Settings.License = LicenseType.Community;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("Bilet na przejazd")
                        .SemiBold().FontSize(19).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {

                            x.Item().Text($"-----\nData zakupu: {nowyBilet.DataKupna}\nTwoje dane: {nowyBilet.ImieNazwisko}\nID Kursu: {nowyBilet.IdKursu}\nRodzaj biletu: {nowyBilet.Rodzaj}\n-----");

                        });
                });
            })
            .GeneratePdf($"Bilet_{nowyBilet.IdBiletu}.pdf");
        }
        public void GenerujPdfNormalny(BiletNormalny nowyBilet)
        {
            Settings.License = LicenseType.Community;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("Bilet na przejazd")
                        .SemiBold().FontSize(19).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {

                            x.Item().Text($"-----\nData zakupu: {nowyBilet.DataKupna}\nTwoje dane: {nowyBilet.ImieNazwisko}\nID Kursu: {nowyBilet.IdKursu}\nRodzaj biletu: {nowyBilet.Rodzaj}\n-----");

                        });
                });
            })
            .GeneratePdf($"Bilet_{nowyBilet.IdBiletu}.pdf");
        }
    }
}

