using migraci.Models;
using System.ComponentModel.DataAnnotations;

namespace migraci.Models
{
    public class CarFeature
    {
        [Required]
        public int CarId { get; set; }

        [Required]
        public int FeatureId { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual Feature Feature { get; set; } = null!;
    }
}