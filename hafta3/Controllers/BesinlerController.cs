using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hafta3.Controllers
{
    [Route("api/besinler")]
    [ApiController]
    public class BesinlerController : Controller
    {
        private readonly ProjeDB _context;
        private readonly IMapper _mapper;

        public BesinlerController(ProjeDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //Tüm besinleri listeler.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BesinlerDTO>>> GetBesinler(
           [FromQuery] int? page = 1,
           [FromQuery] int? pageSize = 10,
           [FromQuery] string name = null,
           [FromQuery] string sortField = "Adi",
           [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var query = _context.Besinler.AsQueryable();

                // Filtreleme
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(u => u.Adi.Contains(name));
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

                var besinler = await query.ToListAsync();
                IEnumerable<BesinlerDTO> besinlerDto = _mapper.Map<IEnumerable<BesinlerDTO>>(besinler);

                return Ok(besinlerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        //Evcil hayvana besin verir.
        [HttpPost("evcilHayvanId")]
        public async Task<ActionResult<BesinlerDTO>> Add(BesinlerEkleDTO besinEkleDTO,int evcilHayvanId)
        {
            try
            {
                Besinler besin = _mapper.Map<Besinler>(besinEkleDTO);
                besin.EvcilHayvanID= evcilHayvanId;
                _context.Besinler.Add(besin);
                await _context.SaveChangesAsync();
                BesinlerDTO returnBesin = _mapper.Map<BesinlerDTO>(besin);
                return CreatedAtAction(nameof(GetByID), new { id = besin.ID }, returnBesin);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
        }
        
        [HttpGet("id")]
        public async Task<ActionResult<BesinlerDTO>> GetByID(int id)
        {
            var besinGetir = await _context.Besinler.Where(x => x.ID == id).FirstOrDefaultAsync();

            if (besinGetir == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            return Ok(_mapper.Map<BesinlerDTO>(besinGetir));
        }
    }
}
