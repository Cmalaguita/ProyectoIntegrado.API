using AutoMapper;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
   public class ProvinciaBL : IProvinciaBL
    {
        public IProvinciaRepository provinciaRepository { get; set; }
        public IMapper mapper { get; set; }
        public ProvinciaBL(IProvinciaRepository provinciaRepository, IMapper mapper)
        {
            this.provinciaRepository = provinciaRepository;
            this.mapper = mapper;
        }
        public ProvinciaDTO BuscarProvinciaId(int id)
        {
            var pr = mapper.Map<Provincia, ProvinciaDTO>(provinciaRepository.BuscarProvinciaId(id));
            return pr;
        }

        public ProvinciaDTO BuscarProvinciaNombre(string nombre)
        {
            var pr = mapper.Map<Provincia, ProvinciaDTO>(provinciaRepository.BuscarProvinciaNombre(nombre));
            return pr;
        }

        public List<ProvinciaDTO> ObtenerProvincias()
        {
            return mapper.Map<List<Provincia>, List<ProvinciaDTO>>(provinciaRepository.ObtenerProvincias());
        }
    }
}
