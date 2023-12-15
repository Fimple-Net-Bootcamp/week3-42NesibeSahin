using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;

namespace hafta3.Profiles
{
    public class AktivitelerProfile:Profile
    {
        public AktivitelerProfile()
        {
            CreateMap<Aktiviteler, AktivitelerDTO>();
            CreateMap<AktivitelerEkleDTO, Aktiviteler>();
            CreateMap<Aktiviteler, AktivitelerEkleDTO>();
            CreateMap<AktivitelerDTO, Aktiviteler>();
        }
        
    }
}
