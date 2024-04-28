using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SystemRezerwacjiBiletow
{
    public class ListaBiletow
    {
        public List<BiletUlgowy> listaBiletowUlgowych;
        public List<BiletNormalny> listaBiletowNormalnych;

        public string sciezkaBilety = "Bilety.xml";
        public List<BiletUlgowy> ListaBiletowUlgowych { get; set; }
        public List<BiletNormalny> ListaBiletowNormalnych { get; set; }

        public ListaBiletow()
        {
            listaBiletowUlgowych = new List<BiletUlgowy>();
            listaBiletowNormalnych = new List<BiletNormalny>();
        }

        public void ZapiszBilety()
        {
            var listaBiletow = new ListaBiletow
            {
                ListaBiletowUlgowych = listaBiletowUlgowych,
                ListaBiletowNormalnych = listaBiletowNormalnych
            };

            var serializer = new XmlSerializer(typeof(ListaBiletow));
            using (var stream = new FileStream(sciezkaBilety, FileMode.Create))
            {
                serializer.Serialize(stream, listaBiletow);
            }
        }
        public void WczytajBilety()
        {
            var serializer = new XmlSerializer(typeof(ListaBiletow));
            using (var stream = new FileStream(sciezkaBilety, FileMode.Open))
            {
                var daneBiletow = (ListaBiletow)serializer.Deserialize(stream);
                listaBiletowUlgowych = daneBiletow.ListaBiletowUlgowych;
                listaBiletowNormalnych = daneBiletow.ListaBiletowNormalnych;
            }
        }
    }
}
