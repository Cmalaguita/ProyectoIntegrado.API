using AutoMapper;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
    public class InscripcionBL : IInscripcionBL
    {
        public IInscripcionRepository inscripcionRepository { get; set; }
        public IMapper mapper { get; set; }
        public InscripcionBL(IInscripcionRepository inscripcionRepository, IMapper mapper)
        {
            this.inscripcionRepository = inscripcionRepository;
            this.mapper = mapper;
        }
        public bool BorrarInscripcion(int id)
        {
           
            return inscripcionRepository.BorrarInscripcion(id);
        }

        public InscripcionDTO CreateInscripcion(CrearInscripcionDTO inscripcion)
        {
            var i = mapper.Map<CrearInscripcionDTO, Inscripcion>(inscripcion);
            if (!inscripcionRepository.Exists(i.Id))
            {
            return mapper.Map<Inscripcion,InscripcionDTO> (inscripcionRepository.CreateInscripcion(i));

            }
            return null;
        }

        public bool Exists(int id)
        {
           
            return inscripcionRepository.Exists(id);
        }

        public List<InscripcionDTO> ObtenerInscripciones()
        {
           List<InscripcionDTO> list = mapper.Map<List<Inscripcion>, List<InscripcionDTO>>(inscripcionRepository.ObtenerInscripciones());
            return list;

        }

        public List<InscripcionDTO> ObtenerInscripcionesPorFamilia(int id)
        {
            List<InscripcionDTO> list = mapper.Map<List<Inscripcion>, List<InscripcionDTO>>(inscripcionRepository.ObtenerInscripcionesPorFamilia(id));
            return list;
        }

        public List<InscripcionDTO> ObtenerInscripcionesPorCiclo(int id)
        {
            List<InscripcionDTO> list = mapper.Map<List<Inscripcion>, List<InscripcionDTO>>(inscripcionRepository.ObtenerInscripcionesPorCiclo(id));
            return list;
        }

       

        public List<InscripcionDTO> ObtenerInscripcionesPorEmpresa(int id)
        {
            List<InscripcionDTO> list = mapper.Map<List<Inscripcion>, List<InscripcionDTO>>(inscripcionRepository.ObtenerInscripcionesPorEmpresa(id));
            return list;
        }

        public List<InscripcionDTO> ObtenerInscripcionesPorAlumno(int id)
        {
            List<InscripcionDTO> list = mapper.Map<List<Inscripcion>, List<InscripcionDTO>>(inscripcionRepository.ObtenerInscripcionesPorAlumno(id));
            return list;
        }

        public bool ExistsPorAlumnoYPosicion(int idP, int idA)
        {
            return inscripcionRepository.ExistsPorAlumnoYPosicion(idP, idA);
        }

        public List<InscripcionDTO> ObtenerInscripcionesPorPosicion(int idPosicion)
        {
            List<InscripcionDTO> list = mapper.Map<List<Inscripcion>, List<InscripcionDTO>>(inscripcionRepository.ObtenerInscripcionesPorPosicion(idPosicion));
            return list;
        }

        public List<AlumnoDTO> ObtenerAlumnosEnInscripcionPorPosicion(int idPosicion)
        {
            List<AlumnoDTO> list = mapper.Map<List<Alumno>,List<AlumnoDTO>>(inscripcionRepository.ObtenerAlumnosEnInscripcionPorPosicion(idPosicion));
            return list;
        }

        public InscripcionDTO UpdateInscripcion(UpdateInscripcionDTO i)
        {
               var e=mapper.Map<UpdateInscripcionDTO, Inscripcion>(i);

            return mapper.Map< Inscripcion,InscripcionDTO >(inscripcionRepository.UpdateInscripcion(e));
        }
    }
}
