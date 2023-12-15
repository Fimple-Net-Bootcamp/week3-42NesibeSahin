using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hafta3.Controllers
{
    [Route("api/saglikdurumlari")]
    [ApiController]
    public class SaglikDurumlariController : Controller
    {
        private readonly ProjeDB _context;
        private readonly IMapper _mapper;

        public SaglikDurumlariController(ProjeDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //Evcil hayvanın sağlık durumunu günceller.
        [HttpPatch("evcilHayvanId")]
        public async Task<ActionResult> saglikDurumGuncelle(int evcilHayvanID, JsonPatchDocument<SaglikDurumlariDTO> saglikDurumlariDTO)
        {
            var evcilHayvanSaglik = await _context.SaglikDurumlari.Where(x => x.EvcilHayvanID == evcilHayvanID).FirstOrDefaultAsync();
            if (evcilHayvanSaglik == null)
            {
                evcilHayvanSaglik = new SaglikDurumlari()
                {
                    HastaMi = false,
                    DurumAdi = "İyi",
                    isSilindi = false,
                    Tarih = DateTime.Now,
                    EvcilHayvanID = evcilHayvanID,
                };
                _context.SaglikDurumlari.Add(evcilHayvanSaglik);
                await _context.SaveChangesAsync();
            }

            var evcilHayvanSaglikPatch = _mapper.Map<SaglikDurumlariDTO>(evcilHayvanSaglik);

            saglikDurumlariDTO.ApplyTo(evcilHayvanSaglikPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(evcilHayvanSaglikPatch, evcilHayvanSaglik);
            evcilHayvanSaglik.Tarih = DateTime.Now;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Belirli bir evcil hayvanın sağlık durumunu getirir.
        [HttpGet("evcilHayvanId")]
        public async Task<ActionResult<SaglikDurumlariDTO>> GetByID(int evcilHayvanID)
        {
            var saglikDurumuGetir = await _context.SaglikDurumlari.Where(x => x.EvcilHayvanID == evcilHayvanID).FirstOrDefaultAsync();

            if (saglikDurumuGetir == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            return Ok(_mapper.Map<SaglikDurumlariDTO>(saglikDurumuGetir));
        }

    }
}
