using migraci.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace migraci.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; } = null!;

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(1950, 2024)]
        public int ProductionYear { get; set; }

        [Required]
        [Range(1000, 1000000)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Color { get; set; } = null!;

        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();

        [NotMapped]
        public string FullCarName => $"{Manufacturer?.Name} {Model}";
    }
}