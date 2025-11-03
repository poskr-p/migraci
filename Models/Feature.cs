using migraci.Models;
using System.ComponentModel.DataAnnotations;

namespace migraci.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public FeatureType Type { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
    }
}