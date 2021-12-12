using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    public class FamiliaProfesionalRepository : IFamiliaProfesionalRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public FamiliaProfesionalRepository(proyectointegradodbContext _context)
        {
            this._context = _context;
        }
        public FamiliaProfesional BuscarFamiliaProfesionalId(int id)
        {
            return _context.FamiliasP.Where(fp=>fp.Id==id).FirstOrDefault();
        }

        public List<FamiliaProfesional> ObtenerFamiliasProfesionales()
        {
            return _context.FamiliasP.ToList();
        }
    }
}
