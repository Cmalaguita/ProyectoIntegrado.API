using AutoMapper;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
   public class FamiliaProfesionalBL : IFamiliaProfesionalBL
    {
        public IFamiliaProfesionalRepository familiaProfesionalRepository { get; set; }
        public IMapper mapper { get; set; }
        public FamiliaProfesionalBL(IFamiliaProfesionalRepository familiaProfesionalRepository, IMapper mapper)
        {
            this.familiaProfesionalRepository = familiaProfesionalRepository;
            this.mapper = mapper;
        }
        public FamiliaProfesionalDTO BuscarFamiliaProfesionalId(int id)
        {
            var fp = mapper.Map<FamiliaProfesional, FamiliaProfesionalDTO>(familiaProfesionalRepository.BuscarFamiliaProfesionalId(id));
            return fp;
        }

        public List<FamiliaProfesionalDTO> ObtenerFamiliasProfesionales()
        {
            List<FamiliaProfesionalDTO> list = mapper.Map<List <FamiliaProfesional>, List<FamiliaProfesionalDTO>>(familiaProfesionalRepository.ObtenerFamiliasProfesionales());
            return list;
        }
    }
}
