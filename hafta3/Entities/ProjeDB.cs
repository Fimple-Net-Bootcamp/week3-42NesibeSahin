using hafta3.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace hafta3.Entities
{
	public class ProjeDB:DbContext
	{
		
		public ProjeDB(DbContextOptions<ProjeDB> options) : base(options)
		{

		}
        public DbSet<Aktiviteler> Aktiviteler { get; set; }
        public DbSet<Besinler> Besinler { get; set; }
        public DbSet<EvcilHayvanlar> EvcilHayvanlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
		public DbSet<SaglikDurumlari> SaglikDurumlari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
