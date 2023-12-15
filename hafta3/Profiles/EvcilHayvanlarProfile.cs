using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;

namespace hafta3.Profiles
{
    public class EvcilHayvanlarProfile:Profile
    {
        public EvcilHayvanlarProfile()
        {
            CreateMap<EvcilHayvanlar, EvcilHayvanDTO>();
            CreateMap<EvcilHayvanEkleDTO, EvcilHayvanlar>();
            CreateMap<EvcilHayvanDTO, EvcilHayvanlar>();

        }

    }
}
