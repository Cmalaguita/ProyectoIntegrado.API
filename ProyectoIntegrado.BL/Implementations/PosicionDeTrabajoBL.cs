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
    public class PosicionDeTrabajoBL : IPosicionDeTrabajoBL
    {
        public IPosicionDeTrabajoRepository posicionDeTrabajoRepository { get; set; }
        public IMapper mapper { get; set; }


        public PosicionDeTrabajoBL(IPosicionDeTrabajoRepository posicionDeTrabajoRepository,IMapper mapper)
        {
            this.posicionDeTrabajoRepository = posicionDeTrabajoRepository;
            this.mapper = mapper;
        }
        public PosicionDeTrabajoDTO ActualizarPosicionDeTrabajo(PosicionDeTrabajoDTO posicionDeTrabajoDTO)
        {
            var p= mapper.Map<PosicionDeTrabajoDTO, PosicionDeTrabajo>(posicionDeTrabajoDTO);

            PosicionDeTrabajoDTO actualizado = mapper.Map<PosicionDeTrabajo, PosicionDeTrabajoDTO>(posicionDeTrabajoRepository.ActualizarPosicionDeTrabajo(p));
            return actualizado;
        }

        public bool BorrarPosicion(PosicionDeTrabajoDTO posicionDeTrabajoDTO)
        {
            var p = mapper.Map<PosicionDeTrabajoDTO, PosicionDeTrabajo>(posicionDeTrabajoDTO);
            return posicionDeTrabajoRepository.BorrarPosicion(p);
        }

        public PosicionDeTrabajoDTO BuscarPosicionDeTrabajoId(int id)
        {
            var p = mapper.Map<PosicionDeTrabajo, PosicionDeTrabajoDTO>(posicionDeTrabajoRepository.BuscarPosicionDeTrabajoId(id));
            return p;
        }

        public List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoActivasHoy()
        {
            List<PosicionDeTrabajoDTO> list = mapper.Map<List<PosicionDeTrabajo>, List<PosicionDeTrabajoDTO>>(posicionDeTrabajoRepository.BuscarPosicionesDeTrabajoActivasHoy());
            return list;
        }

        public List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorNombre(string nombre)
        {
            List<PosicionDeTrabajoDTO> list = mapper.Map<List<PosicionDeTrabajo>, List<PosicionDeTrabajoDTO>>(posicionDeTrabajoRepository.BuscarPosicionesDeTrabajoPorNombre(nombre));
            return list;
        }

        public PosicionDeTrabajoDTO CreatePosicionDeTrabajo(PosicionDeTrabajoDTO posicionDeTrabajoDTO)
        {
            var p = mapper.Map<PosicionDeTrabajoDTO, PosicionDeTrabajo>(posicionDeTrabajoDTO);
            if (!posicionDeTrabajoRepository.Exists(p))
            {

            return mapper.Map<PosicionDeTrabajo,PosicionDeTrabajoDTO>(posicionDeTrabajoRepository.CreatePosicionDeTrabajo(p));
            }
            return null;
        }

        public bool Exists(PosicionDeTrabajoDTO posicionDeTrabajoDTO)
        {
            var p = mapper.Map<PosicionDeTrabajoDTO, PosicionDeTrabajo>(posicionDeTrabajoDTO);
            return posicionDeTrabajoRepository.Exists(p);
        }

        public List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajo()
        {
            List<PosicionDeTrabajoDTO> list = mapper.Map<List<PosicionDeTrabajo>, List<PosicionDeTrabajoDTO>>(posicionDeTrabajoRepository.ObtenerPosicionesDeTrabajo());
            return list;
        }
    }
}
