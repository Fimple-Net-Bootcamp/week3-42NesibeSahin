using System.ComponentModel.DataAnnotations.Schema;

namespace hafta3.Entities
{
	public class Kullanici:Entity<int>
	{
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TC { get; set; }

        public List<EvcilHayvanlar> EvcilHayvanlar { get; set; }


    }
}
