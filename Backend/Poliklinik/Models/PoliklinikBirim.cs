using System.ComponentModel.DataAnnotations;

namespace Poliklinik.Models
{
    public class PoliklinikBirim
    {
        [Key]
        public int PoliklinikId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BirimAdi { get; set; }
    }
}
