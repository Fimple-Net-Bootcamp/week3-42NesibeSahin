using hafta3.Entities;

namespace hafta3.DTOs
{
    public class KullaniciDTO
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TC { get; set; }
    }

    public class KullaniciEkleDTO
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TC { get; set; }
    }
}
