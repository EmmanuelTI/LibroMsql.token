using AutoMapper;
using UTTT.Micro.Libro.Models;

namespace UTTT.Micro.Libro.Applicaciones
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriasMateriales, LibroMaterialDto>();
        }

    }
}
