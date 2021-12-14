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

                CreateMap<AlumnoLoginDTO, Alumno>();
                CreateMap<Alumno, AlumnoLoginDTO>();

                CreateMap<AlumnoSignUpDTO, Alumno>();
                CreateMap<Alumno, AlumnoSignUpDTO>();

                CreateMap<EmpresaDTO, Empresa>();
                CreateMap<Empresa, EmpresaDTO>();

                CreateMap<EmpresaLoginDTO, Empresa>();
                CreateMap<Empresa, EmpresaLoginDTO>();

                CreateMap<EmpresaSignUpDTO, Empresa>();
                CreateMap<Empresa, EmpresaSignUpDTO>();

                CreateMap<ProvinciaDTO, Provincia>();
                CreateMap<Provincia, ProvinciaDTO>();
        
                CreateMap<PosicionDeTrabajoDTO, PosicionDeTrabajo>();
                CreateMap<PosicionDeTrabajo, PosicionDeTrabajoDTO>();

                CreateMap<PosicionDeTrabajoCicloDTO, Ciclo>();
                CreateMap<Ciclo,PosicionDeTrabajoCicloDTO>();

                CreateMap<PosicionDeTrabajoCreateDTO, PosicionDeTrabajo>();
                CreateMap<PosicionDeTrabajo, PosicionDeTrabajoCreateDTO>();

                CreateMap<PosicionDeTrabajoDeleteDTO, PosicionDeTrabajo>();
                CreateMap<PosicionDeTrabajo, PosicionDeTrabajoDeleteDTO>();

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
