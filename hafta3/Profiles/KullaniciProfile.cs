using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;

namespace hafta3.Profiles
{
    public class KullaniciProfile : Profile
    {
        public KullaniciProfile()
        {
            CreateMap<Kullanici, KullaniciDTO>();
            CreateMap<KullaniciEkleDTO, Kullanici>();    
        }
    }
}
