using AutoMapper;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
    public class TipoDeCicloBL : ITipoDeCicloBL
    {
        public ITipoDeCicloRepository tipoDeCicloRepository { get; set; }
        public IMapper mapper { get; set; }
        public TipoDeCicloBL(ITipoDeCicloRepository tipoDeCicloRepository, IMapper mapper)
        {
            this.tipoDeCicloRepository = tipoDeCicloRepository;
            this.mapper = mapper;
        }
        public TipoDeCicloDTO BuscarTipoDeCicloId(int id)
        {
           return mapper.Map<TipoDeCiclo, TipoDeCicloDTO>(tipoDeCicloRepository.BuscarTipoDeCicloId(id));
        }

        public List<TipoDeCicloDTO> ObtenerTiposDeCiclos()
        {
            return mapper.Map<List<TipoDeCiclo>, List<TipoDeCicloDTO>>(tipoDeCicloRepository.ObtenerTiposDeCiclos());
        }
    }
}
