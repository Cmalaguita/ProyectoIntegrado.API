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
            return _context.Ciclos.Where(c => c.Id == id).Include("familia").Include("TipoCiclo").FirstOrDefault();
        }

        public Ciclo BuscarCicloNombre(string nombre)
        {
            return _context.Ciclos.Where(c => c.Nombre == nombre).Include("familia").Include("TipoCiclo").FirstOrDefault();
        }

        public List<Ciclo> ObtenerCiclos()
        {
            return _context.Ciclos.Include("familia").Include("TipoCiclo").ToList();
        }
    }
}
