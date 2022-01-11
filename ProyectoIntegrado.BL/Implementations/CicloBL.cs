using AutoMapper;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
    public class CicloBL : ICicloBL
    {
        public ICicloRepository cicloRepository { get; set; }
        public IMapper mapper { get; set; }

        public CicloBL(ICicloRepository cicloRepository,IMapper mapper)
        {
            this.mapper = mapper;
            this.cicloRepository = cicloRepository;
        }
        public CicloDTO BuscarCicloId(int id)
        {
            var c = mapper.Map<Ciclo, CicloDTO>(cicloRepository.BuscarCicloId(id));
            return c;
        }

        public CicloDTO BuscarCicloNombre(string nombre)
        {
            var c = mapper.Map<Ciclo, CicloDTO>(cicloRepository.BuscarCicloNombre(nombre));
            return c;
        }

        public List<CicloDTO> ObtenerCiclos()
        {
            List<CicloDTO> list = mapper.Map<List<Ciclo>, List<CicloDTO>>(cicloRepository.ObtenerCiclos());
            return list;
        }

       public List<CicloDTO> ObtenerCiclosPorFamilia(int idFamilia)
        {
          return mapper.Map<List<Ciclo>, List<CicloDTO>>(cicloRepository.ObtenerCiclosPorFamilia( idFamilia));

        }

       public List<CicloDTO> ObtenerCiclosPorTipo(int idTipo)
        {
           return mapper.Map<List<Ciclo>, List<CicloDTO>>(cicloRepository.ObtenerCiclosPorTipo(idTipo));
        }

        public List<CicloDTO> ObtenerCiclosPorFamiliaYTipo(int idTipo, int idFamilia)
        {
            return mapper.Map<List<Ciclo>, List<CicloDTO>>(cicloRepository.ObtenerCiclosPorFamiliaYTipo(idTipo, idFamilia));
        }
    }
}