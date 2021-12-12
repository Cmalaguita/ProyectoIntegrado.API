using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
  public class ProvinciaRepository : IProvinciaRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public ProvinciaRepository(proyectointegradodbContext _context)
        {
            this._context = _context;
        }
        public Provincia BuscarProvinciaId(int id)
        {
            return _context.Provincias.Where(p=> p.Id==id).FirstOrDefault();
        }

        public Provincia BuscarProvinciaNombre(string nombre)
        {
            return _context.Provincias.Where(p=>p.Nombre.Equals(nombre)).FirstOrDefault();
        }

        public List<Provincia> ObtenerProvincias()
        {
            return _context.Provincias.ToList();
        }
    }
}
