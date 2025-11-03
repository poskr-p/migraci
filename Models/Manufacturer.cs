using migraci.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace migraci.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        [Range(1800, 2024)]
        public int FoundedYear { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}