using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace hafta3.Controllers
{
    [Route("api/kullanicilar")]
    [ApiController]
    public class KullaniciController : Controller
    {

        private readonly ProjeDB _context;
        private readonly IMapper _mapper;

        public KullaniciController(ProjeDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KullaniciDTO>>> GetKullanici(
           [FromQuery] int? page = 1,
           [FromQuery] int? pageSize = 10,
           [FromQuery] string name = null,
           [FromQuery] string sortField = "Adi",
           [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var query = _context.Kullanicilar.AsQueryable();

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

                var kullanicilar = await query.ToListAsync();
                IEnumerable<KullaniciDTO> kullanicilarDto = _mapper.Map<IEnumerable<KullaniciDTO>>(kullanicilar);

                return Ok(kullanicilarDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        //Belirli bir kullanıcının bilgilerini getirir.
        [HttpGet("kullaniciId")]
        public async Task<ActionResult<KullaniciDTO>> GetByID(int id)
        {
            var kullaniciGetir = await _context.Kullanicilar.Where(x => x.ID == id).FirstOrDefaultAsync();

            if (kullaniciGetir == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            return Ok(_mapper.Map<KullaniciDTO>(kullaniciGetir));
        }

        //Yeni kullanıcı oluşturur.
        [HttpPost]
        public async Task<ActionResult<KullaniciDTO>> Add(KullaniciEkleDTO kullaniciEkleDTO)
        {
            try
            {
                Kullanici kullaniciNew = _mapper.Map<Kullanici>(kullaniciEkleDTO);                                          
                _context.Kullanicilar.Add(kullaniciNew);
                await _context.SaveChangesAsync();
                KullaniciDTO returnKullanici = _mapper.Map<KullaniciDTO>(kullaniciNew);
                return CreatedAtAction(nameof(GetByID), new { id = kullaniciNew.ID }, returnKullanici);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
        }
    }
}


