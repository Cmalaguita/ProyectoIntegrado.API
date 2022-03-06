using Microsoft.EntityFrameworkCore;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    public class MensajeRepository : IMensajeRepository
    {
        public proyectointegradodbContext _context { get; set; }

        public MensajeRepository(proyectointegradodbContext _context)
        {
            this._context = _context;
        }
        public bool BorrarMensaje(int mensajeId, int empresaId)
        {
            var m =existMensaje(mensajeId);
            if (m!=null)
            {
            _context.Mensajes.Remove(m);
            _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CambiarEstadoLecturaMensaje(int idmensaje, bool leido)
        {
            var m = existMensaje(idmensaje);
            if (m!=null)
            {
                m.leido = leido;
                _context.Update(m);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Mensaje existMensaje(int idMensaje)
        {
            return _context.Mensajes.Where(f => f.id == idMensaje).Include(f => f.alumno).ThenInclude(c => c.ciclo).FirstOrDefault();
        }

        public List<Mensaje> ObtenerMensajesPorAlumnoId(int alumnoId)
        {
            return _context.Mensajes.Where(m => m.alumnoId ==alumnoId).Include(m => m.alumno).ThenInclude(c => c.ciclo).Include(m => m.empresa).ThenInclude(e => e.Provincia).ToList();
        }

        public List<Mensaje> ObtenerMensajesPorEmpresaId(int empresaId)
        {
            return _context.Mensajes.Where(m => m.empresaId == empresaId).Include(m => m.alumno).ThenInclude(c => c.ciclo).Include(m => m.empresa).ThenInclude(e => e.Provincia).ToList();
        }

        public List<Mensaje> ObtenerMensajesSegunLecturaPorAlumnoId(int alumnoId, bool leido)
        {
            return _context.Mensajes.Where(m => m.id == alumnoId && m.leido==leido).Include(m => m.alumno).ThenInclude(c => c.ciclo).Include(m => m.empresa).ThenInclude(e => e.Provincia).ToList();
        }

        public Mensaje CrearMensaje(Mensaje mensaje)
        {
            _context.Mensajes.Add(mensaje);
            _context.SaveChanges();
           return _context.Mensajes.Where(m => m == mensaje).FirstOrDefault();
        }

        public Mensaje ActualizarMensaje(Mensaje mensaje)
        {
            var eu = existMensaje(mensaje.id);
            if (eu != null)
            {
                mensaje.id = eu.id;
                _context.Entry(eu).CurrentValues.SetValues(mensaje);
                _context.SaveChanges();
                var e = existMensaje(mensaje.id);
                
                return e;
            }
            return null;
        }
    }
}
