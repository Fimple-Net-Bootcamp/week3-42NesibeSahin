using System.ComponentModel.DataAnnotations.Schema;

namespace hafta3.Entities
{
	public class Besinler : Entity<int>
	{
		public string Adi { get; set; }
		public int EvcilHayvanID { get; set; }

		[ForeignKey("EvcilHayvanID")]
		public EvcilHayvanlar EvcilHayvanlar { get; set; }
	}
}

