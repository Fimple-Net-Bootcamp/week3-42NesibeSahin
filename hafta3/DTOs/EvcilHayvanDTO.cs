using hafta3.Entities;

namespace hafta3.DTOs
{
    public class EvcilHayvanDTO
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public int Kodu { get; set; }
        public string Tur { get; set; }
        public int KullaniciID { get; set; }
    }
    public class EvcilHayvanEkleDTO
    {
        public string Isim { get; set; }
        public int Kodu { get; set; }
        public string Tur { get; set; }
        public int KullaniciID { get; set; }
    }
}
