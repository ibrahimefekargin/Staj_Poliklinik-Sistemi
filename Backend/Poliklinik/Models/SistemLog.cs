using System.ComponentModel.DataAnnotations;

namespace Poliklinik.Models
{
    public class SistemLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string IslemTipi { get; set; }

        [Required]
        [MaxLength(250)]
        public string IslemAciklama { get; set; }

        [Required]
        public DateTime IslemTarihi { get; set; }

        public int IslemYapanId { get; set; }
    }
}
