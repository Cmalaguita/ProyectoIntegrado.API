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
        public ICicloRepository cicloRepository { get; set; }

        public PosicionDeTrabajoBL(IPosicionDeTrabajoRepository posicionDeTrabajoRepository,IMapper mapper, ICicloRepository cicloRepository)
        {
            this.posicionDeTrabajoRepository = posicionDeTrabajoRepository;
            this.mapper = mapper;
            this.cicloRepository = cicloRepository;
        }
        
        public PosicionDeTrabajoCreateDTO ActualizarPosicionDeTrabajo(PosicionDeTrabajoCreateDTO posicionDeTrabajoCreateDTO)
        {
           List<Ciclo> ciclos = new List<Ciclo>();

            foreach (var item in posicionDeTrabajoCreateDTO.Ciclos)
            {
                ciclos.Add(cicloRepository.BuscarCicloId(item.Id));
            }
         
            var p = mapper.Map<PosicionDeTrabajoCreateDTO, PosicionDeTrabajo>(posicionDeTrabajoCreateDTO);

            p.Ciclos = ciclos;

            PosicionDeTrabajoCreateDTO actualizado = mapper.Map<PosicionDeTrabajo, PosicionDeTrabajoCreateDTO>(posicionDeTrabajoRepository.ActualizarPosicionDeTrabajo(p));
            return actualizado;
        }

        public bool BorrarPosicion(PosicionDeTrabajoDeleteDTO posicionDeTrabajoDeleteDTO)
        {
            var p = mapper.Map<PosicionDeTrabajoDeleteDTO, PosicionDeTrabajo>(posicionDeTrabajoDeleteDTO);
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

        public PosicionDeTrabajoCreateDTO CreatePosicionDeTrabajo(PosicionDeTrabajoCreateDTO posicionDeTrabajoCreateDTO)
        {
            List<Ciclo> ciclos = new List<Ciclo>();
            foreach (var item in posicionDeTrabajoCreateDTO.Ciclos)
            {
                ciclos.Add(cicloRepository.BuscarCicloId(item.Id));
            }       
            var p = mapper.Map<PosicionDeTrabajoCreateDTO, PosicionDeTrabajo>(posicionDeTrabajoCreateDTO);

            p.Ciclos = ciclos;
            if (!posicionDeTrabajoRepository.Exists(p))
            {

            return mapper.Map<PosicionDeTrabajo,PosicionDeTrabajoCreateDTO>(posicionDeTrabajoRepository.CreatePosicionDeTrabajo(p));
            }
            return null;
        }

        public bool Exists(PosicionDeTrabajoDTO posicionDeTrabajoDTO)
        {
            var p = mapper.Map<PosicionDeTrabajoDTO, PosicionDeTrabajo>(posicionDeTrabajoDTO);
            return posicionDeTrabajoRepository.Exists(p);
        }
        public bool Exists(PosicionDeTrabajoCreateDTO posicionDeTrabajoCreateDTO)
        {
            var p = mapper.Map<PosicionDeTrabajoCreateDTO, PosicionDeTrabajo>(posicionDeTrabajoCreateDTO);
            return posicionDeTrabajoRepository.Exists(p);
        }

        public List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajo()
        {
            List<PosicionDeTrabajoDTO> list = mapper.Map<List<PosicionDeTrabajo>, List<PosicionDeTrabajoDTO>>(posicionDeTrabajoRepository.ObtenerPosicionesDeTrabajo());
            foreach (var item in list)
            {
                item.empresa.Password = null;
            }
            return list;
        }

       public List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorEmpresa(int id)
        {
            List<PosicionDeTrabajoDTO> list = mapper.Map<List<PosicionDeTrabajo>, List<PosicionDeTrabajoDTO>>(posicionDeTrabajoRepository.BuscarPosicionesDeTrabajoPorEmpresa(id));
            foreach (var item in list)
            {
                item.empresa.Password = null;
            }
            return list;
        }

        public List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorCiclo(int id)
        {

            List<PosicionDeTrabajoDTO> list = mapper.Map<List<PosicionDeTrabajo>, List<PosicionDeTrabajoDTO>>(posicionDeTrabajoRepository.BuscarPosicionesDeTrabajoPorCiclo(id));
            foreach (var item in list)
            {
                item.empresa.Password = null;
            }
            return list;
        }
    }
}
