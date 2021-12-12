using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    public class TipoDeCicloRepository : ITipoDeCicloRepository
    {

        public proyectointegradodbContext _context { get; set; }
        public TipoDeCicloRepository(proyectointegradodbContext _context)
        {
            this._context = _context;
        }
        public TipoDeCiclo BuscarTipoDeCicloId(int id)
        {
            return _context.TipoCiclos.Where(tp=> tp.Id==id).FirstOrDefault();
        }

        public List<TipoDeCiclo> ObtenerTiposDeCiclos()
        {
            return _context.TipoCiclos.ToList();
        }
    }
}
