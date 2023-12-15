using AutoMapper;
using hafta3.DTOs;
using hafta3.Entities;

namespace hafta3.Profiles
{
    public class SaglikDurumlariProfile : Profile
    {
        public SaglikDurumlariProfile()
        {
            CreateMap<SaglikDurumlari, SaglikDurumlariDTO>();
            CreateMap<SaglikDurumlariDTO, SaglikDurumlari>();

        }
    }
}
