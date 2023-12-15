using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hafta3.Controllers
{
    [Route("api/aktiviteler")]
    [ApiController]
    public class AktivitelerController : Controller
    {


        private readonly ProjeDB _context;
        private readonly IMapper _mapper;

        public AktivitelerController(ProjeDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //Evcil hayvan için yeni bir aktivite ekler.
        [HttpPost]
        public async Task<ActionResult<AktivitelerDTO>> Add(AktivitelerEkleDTO aktivitelerEkleDTO)
        {
            try
            {
                Aktiviteler aktivite = _mapper.Map<Aktiviteler>(aktivitelerEkleDTO);
                _context.Aktiviteler.Add(aktivite);
                await _context.SaveChangesAsync();
                AktivitelerDTO returnAktivite = _mapper.Map<AktivitelerDTO>(aktivite);
                return CreatedAtAction(nameof(GetAktiviteByID), new { id = aktivite.ID }, returnAktivite);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
        }

        //Evcil hayvanın yapabileceği aktiviteleri listeler.
        [HttpGet("evcilHayvanId")]
        public async Task<ActionResult<IEnumerable<AktivitelerDTO>>> GetAktiviteByID( int evcilHayvanId)
        {
            try
            {
                var query = _context.Aktiviteler.Where(x=>x.EvcilHayvanID== evcilHayvanId).AsQueryable();

               
                var aktivite = await query.ToListAsync();
                IEnumerable<AktivitelerDTO> aktiviteDto = _mapper.Map<IEnumerable<AktivitelerDTO>>(aktivite);

                return Ok(aktiviteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

       

    }
}
