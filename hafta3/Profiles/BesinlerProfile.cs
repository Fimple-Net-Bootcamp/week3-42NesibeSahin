using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;

namespace hafta3.Profiles
{
    public class BesinlerProfile:Profile
    {
        public BesinlerProfile()
        {
            CreateMap<Besinler, BesinlerDTO>();
            CreateMap<BesinlerDTO,Besinler>();
            CreateMap<BesinlerEkleDTO, Besinler>();
        }
    }
}
