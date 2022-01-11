using Microsoft.EntityFrameworkCore;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    public class CicloRepository : ICicloRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public CicloRepository( proyectointegradodbContext _context)
        {
            this._context = _context;
        }
        public Ciclo BuscarCicloId(int id)
        {
            return _context.Ciclos.Where(c => c.Id == id).Include(c => c.familia).Include(c => c.Tipociclo).FirstOrDefault();
        }

        public Ciclo BuscarCicloNombre(string nombre)
        {
            return _context.Ciclos.Where(c => c.Nombre == nombre).Include(c=>c.familia).Include(c => c.Tipociclo).FirstOrDefault();
        }

        public List<Ciclo> ObtenerCiclos()
        {
            return _context.Ciclos.Include(c => c.familia).Include(c => c.Tipociclo).ToList();
        }

        public List<Ciclo> ObtenerCiclosPorFamilia(int idFamilia)
        {
            return _context.Ciclos.Where(c => c.IdFamilia == idFamilia).Include(c => c.familia).Include(c => c.Tipociclo).ToList();
        }

        public List<Ciclo> ObtenerCiclosPorTipo(int idTipo)
        {
          return  _context.Ciclos.Where(c => c.IdTipo == idTipo).Include(c => c.familia).Include(c => c.Tipociclo).ToList();
        }

        public List<Ciclo> ObtenerCiclosPorFamiliaYTipo(int idTipo, int idFamilia)
        {
           return _context.Ciclos.Where(c=>c.IdTipo==idTipo && c.IdFamilia== idFamilia).Include(c => c.familia).Include(c => c.Tipociclo).ToList();
        }
    }
}
