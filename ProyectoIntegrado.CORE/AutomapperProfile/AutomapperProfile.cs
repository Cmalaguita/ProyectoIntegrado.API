using AutoMapper;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;

namespace ProyectoIntegrado.CORE.AutomapperProfile
{
   public class AutomapperProfile
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<AlumnoDTO, Alumno>();
                CreateMap<Alumno, AlumnoDTO>();
                CreateMap<AlumnoDTO, Alumno>();
                CreateMap<Alumno, AlumnoDTO>();
                CreateMap<EmpresaDTO, Empresa>();
                CreateMap<Empresa, EmpresaDTO>();
                CreateMap<EmpresaDTO, Empresa>();
                CreateMap<Empresa, EmpresaDTO>();
            }
        }
    }
}
