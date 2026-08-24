using PoliklinikSistemi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Poliklinik.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }

        [Required]
        [StringLength(11)]
        public string HastaTC { get; set; }

        [Required]
        [MaxLength(100)]
        public string HastaAdSoyad { get; set; }

        [Required]
        public DateTime TarihSaat { get; set; }

        [Required]
        [MaxLength(20)]
        public string Durum { get; set; }

        public int DoktorId { get; set; }

        [JsonIgnore]
        public Doktor? Doktor { get; set; }
    }
}
