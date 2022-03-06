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
   public class MensajeBL:IMensajeBL
    {
        public IMapper mapper { get; set; }
        public IMensajeRepository mensajeRepository { get; set; }
        public MensajeBL(IMapper mapper, IMensajeRepository mensajeRepository)
        {
            this.mensajeRepository = mensajeRepository;
            this.mapper = mapper;
        }

        public MensajeDTO ActualizarMensaje(MensajeDTO mensaje)
        {
            var m = mapper.Map<MensajeDTO, Mensaje>(mensaje);
            return mapper.Map<Mensaje, MensajeDTO>(mensajeRepository.ActualizarMensaje(m));
        }

        public bool BorrarMensaje(int mensajeId, int empresaId)
        {
            return mensajeRepository.BorrarMensaje(mensajeId,empresaId);
        }

        public bool CambiarEstadoLecturaMensaje(int idmensaje, bool leido)
        {
            return mensajeRepository.CambiarEstadoLecturaMensaje(idmensaje, leido);
        }

        public MensajeDTO CrearMensaje(CrearMensajeDTO mensaje)
        {
            var m = mapper.Map<CrearMensajeDTO, Mensaje>(mensaje);
            return mapper.Map<Mensaje,MensajeDTO>(mensajeRepository.CrearMensaje(m));
        }

        public MensajeDTO existMensaje(int idMensaje)
        {
            return mapper.Map<Mensaje,MensajeDTO>(mensajeRepository.existMensaje(idMensaje));
        }

        public List<MensajeDTO> ObtenerMensajesPorAlumnoId(int alumnoId)
        {
            return mapper.Map<List<Mensaje>, List<MensajeDTO>>(mensajeRepository.ObtenerMensajesPorAlumnoId(alumnoId));
        }

        public List<MensajeDTO> ObtenerMensajesPorEmpresaId(int empresaId)
        {
            return mapper.Map<List<Mensaje>, List<MensajeDTO>>(mensajeRepository.ObtenerMensajesPorEmpresaId(empresaId));
        }

        public List<MensajeDTO> ObtenerMensajesNoLeidos(int alumnoId)
        {
            return mapper.Map<List<Mensaje>, List<MensajeDTO>>(mensajeRepository.ObtenerMensajesNoLeidos(alumnoId));
        }
    }
}
