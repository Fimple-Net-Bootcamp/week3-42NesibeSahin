using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hafta3.Entities
{
	public abstract class Entity<T>
	{
        public T ID { get; set; }
        public bool isSilindi { get; set; }
    }
}
