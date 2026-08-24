using System.ComponentModel.DataAnnotations;

namespace PoliklinikSistemi.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorId { get; set; }
        public string AdSoyad { get; set; }
        public string Brans { get; set; } 
    }
}