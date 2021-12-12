using AutoMapper;
using ProyectoIntegrado.BL.Contracts;
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
        public bool BorrarInscripcion(InscripcionDTO inscripcion)
        {
            var i = mapper.Map<InscripcionDTO, Inscripcion>(inscripcion);
            return inscripcionRepository.BorrarInscripcion(i);
        }

        public InscripcionDTO CreateInscripcion(InscripcionDTO inscripcion)
        {
            var i = mapper.Map<InscripcionDTO, Inscripcion>(inscripcion);
            if (!inscripcionRepository.Exists(i))
            {
            return mapper.Map<Inscripcion,InscripcionDTO> (inscripcionRepository.CreateInscripcion(i));

            }
            return null;
        }

        public bool Exists(InscripcionDTO inscripcion)
        {
            var i = mapper.Map<InscripcionDTO, Inscripcion>(inscripcion);

            return inscripcionRepository.Exists(i);
        }

        public List<InscripcionDTO> ObtenerInscripciones()
        {
           List<InscripcionDTO> list = mapper.Map<List<Inscripcion>, List<InscripcionDTO>>(inscripcionRepository.ObtenerInscripciones());
            return list;

        }
    }
}
