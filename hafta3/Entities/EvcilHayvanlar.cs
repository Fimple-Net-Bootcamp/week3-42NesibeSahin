using hafta3.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace hafta3.Entities
{
	public class EvcilHayvanlar : Entity<int>
	{
		
		public string Isim { get; set; }
		public int Kodu { get; set; }
        public string Tur { get; set; }
		public int KullaniciID { get; set; }

		[ForeignKey("KullaniciID")]
		public Kullanici Kullanici { get; set; }


        public List<SaglikDurumlari> SaglikDurumlari { get; set; }
		public List<Aktiviteler> Aktiviteler { get; set; }
		public List<Besinler> Besinler { get; set; }
    }
}
