using hafta3.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace hafta3.DTOs
{
    public class SaglikDurumlariDTO
    {
        public string DurumAdi { get; set; }
        public bool HastaMi { get; set; }
        public int EvcilHayvanID { get; set; }
    }

    public class SaglikDurumlariCevapDTO
    {
        public string DurumAdi { get; set; }
        public bool HastaMi { get; set; }
        public int EvcilHayvanID { get; set; }
        public DateTime Tarih { get; set; }
    }
}
