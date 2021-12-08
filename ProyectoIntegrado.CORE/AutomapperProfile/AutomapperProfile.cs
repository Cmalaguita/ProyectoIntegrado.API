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
                CreateMap<AlumnoCompletoDTO, Alumno>();
                CreateMap<Alumno, AlumnoCompletoDTO>();
                CreateMap<EmpresaDTO, Empresa>();
                CreateMap<Empresa, EmpresaDTO>();
                CreateMap<EmpresaCompletaDTO, Empresa>();
                CreateMap<Empresa, EmpresaCompletaDTO>();
            }
        }
    }
}
