using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poliklinik.Data;
using Poliklinik.Models;
using PoliklinikSistemi.Models;

namespace Poliklinik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandevularController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RandevularController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRandevular()
        {
            var randevular = _context.Randevular.Include(r => r.Doktor).ToList();
            bool degisiklikVarMi = false;

            foreach (var randevu in randevular)
            {
                if (randevu.TarihSaat < DateTime.Now && randevu.Durum == "Bekliyor")
                {
                    randevu.Durum = "Tedavi Yapıldı";
                    degisiklikVarMi = true;
                }
            }

            if (degisiklikVarMi)
            {
                _context.SaveChanges();
            }

            return Ok(randevular);
        }

        [HttpPost]
        public IActionResult RandevuOlustur(Randevu yeniRandevu)
        {
            bool varMi = _context.Randevular.Any(x => x.DoktorId == yeniRandevu.DoktorId && x.TarihSaat == yeniRandevu.TarihSaat);
            if (varMi)
                return BadRequest("Bu doktorun bu saatte başka bir randevusu var.");

            _context.Randevular.Add(yeniRandevu);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}/iptal")]
        public IActionResult RandevuIptalveLoglama(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu is null)
                return NotFound();

            randevu.Durum = "İptal";
            SistemLog yeniSistem = new()
            {
                IslemYapanId = 1,
                IslemTipi = "Randevu İptali",
                IslemTarihi = DateTime.Now,
                IslemAciklama = "Randevu iptal edildi."
            };
            _context.SistemLoglar.Add(yeniSistem);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}/ertele")]
        public IActionResult RandevuErtele(int id, [FromBody] string yeniTarih)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu == null) return NotFound();

            randevu.TarihSaat = DateTime.Parse(yeniTarih);
            randevu.Durum = "Bekliyor";

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("doktorlar")]
        public IActionResult GetDoktorlar()
        {
            return Ok(_context.Doktorlar.ToList());
        }
    }
}
