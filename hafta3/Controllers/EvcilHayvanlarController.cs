using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hafta3.Controllers
{
    [Route("api/evcilhayvanlar")]
    [ApiController]
    public class EvcilHayvanlarController : Controller
    {
        private readonly ProjeDB _context;
        private readonly IMapper _mapper;

        public EvcilHayvanlarController(ProjeDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //Tüm evcil hayvanları listeler.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvcilHayvanDTO>>> GetEvcilHayvanlar(
           [FromQuery] int? page = 1,
           [FromQuery] int? pageSize = 10,
           [FromQuery] string name = null,
           [FromQuery] string sortField = "Isim",
           [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var query = _context.EvcilHayvanlar.AsQueryable();

                // Filtreleme
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(u => u.Isim.Contains(name));
                }

                // Sıralama
                if (!string.IsNullOrEmpty(sortField))
                {
                    switch (sortOrder.ToLower())
                    {
                        case "asc":
                            query = query.OrderBy(u => EF.Property<object>(u, sortField));
                            break;
                        case "desc":
                            query = query.OrderByDescending(u => EF.Property<object>(u, sortField));
                            break;
                    }
                }

                // Sayfalama
                if (page.HasValue && pageSize.HasValue)
                {
                    query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                }

                var hayvanlar = await query.ToListAsync();
                IEnumerable<EvcilHayvanDTO> hayvanlarDto = _mapper.Map<IEnumerable<EvcilHayvanDTO>>(hayvanlar);
                return Ok(hayvanlarDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        //Belirli bir evcil hayvanın bilgilerini getirir.
        [HttpGet("evcilHayvanId")]
        public async Task<ActionResult<EvcilHayvanDTO>> GeEvcilHayvanlarById(int id)
        {
            var hayvan = await _context.EvcilHayvanlar.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (hayvan == null)
            {
                return NotFound("Evcil Hayvan bulunamadı.");
            }
            return Ok(_mapper.Map<EvcilHayvanDTO>(hayvan));
        }

        //Yeni evcil hayvan oluşturur.
        [HttpPost]
        public async Task<ActionResult<EvcilHayvanDTO>> Add(EvcilHayvanEkleDTO evcilHayvanEkleDTO)
        {
            try
            {
                EvcilHayvanlar hayvanNew = _mapper.Map<EvcilHayvanlar>(evcilHayvanEkleDTO);
                _context.EvcilHayvanlar.Add(hayvanNew);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GeEvcilHayvanlarById), new { id = hayvanNew.ID }, _mapper.Map<EvcilHayvanDTO>(hayvanNew));
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
        }

        //Evcil hayvanın bilgilerini günceller.
        [HttpPut("evcilHayvanId")]
        public async Task<IActionResult> UpdateEvcilHayvan(int evcilHayvanId,EvcilHayvanEkleDTO evcilHayvanDTO)
        {


            if (evcilHayvanId == 0)
            {
                return BadRequest("Bad Request: Evcil Hayvan Kimliği eşleşmiyor.");
            }
            EvcilHayvanlar evcilHayvanlar = _mapper.Map<EvcilHayvanlar>(evcilHayvanDTO);
            evcilHayvanlar.ID = evcilHayvanId;
            _context.Entry(evcilHayvanlar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvcilHayvanExists(evcilHayvanlar.ID))
                {
                    return NotFound("Evcil hayvan bulunamadı.");
                }
                else
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
        }

        private bool EvcilHayvanExists(int id)
        {
            return _context.EvcilHayvanlar.Any(e => e.ID == id);
        }
    }
}

