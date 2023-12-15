using System.ComponentModel.DataAnnotations.Schema;

namespace hafta3.Entities
{
	public class SaglikDurumlari : Entity<int>
	{
		public string DurumAdi { get; set; }
        public DateTime Tarih { get; set; }
        public bool HastaMi { get; set; }
        public int EvcilHayvanID { get; set; }

		[ForeignKey("EvcilHayvanID")]
		public EvcilHayvanlar EvcilHayvanlar { get; set; }

	}
}

