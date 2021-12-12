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
              
                CreateMap<EmpresaDTO, Empresa>();
                CreateMap<Empresa, EmpresaDTO>();

                CreateMap<ProvinciaDTO, Provincia>();
                CreateMap<Provincia, ProvinciaDTO>();
        
                CreateMap<PosicionDeTrabajoDTO, PosicionDeTrabajo>();
                CreateMap<PosicionDeTrabajo, PosicionDeTrabajoDTO>();

                CreateMap<FamiliaProfesionalDTO, FamiliaProfesional>();
                CreateMap<FamiliaProfesional, FamiliaProfesionalDTO>();
                
                CreateMap<CicloDTO, Ciclo>();
                CreateMap<Ciclo, CicloDTO>();
                
                CreateMap<TipoDeCicloDTO, TipoDeCiclo>();
                CreateMap<TipoDeCiclo, TipoDeCicloDTO>();
                
                CreateMap<InscripcionDTO, Inscripcion>();
                CreateMap<Inscripcion, InscripcionDTO>();

            }
        }
    }
}
