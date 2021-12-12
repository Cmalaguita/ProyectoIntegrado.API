using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IInscripcionBL
    {
        InscripcionDTO CreateInscripcion(InscripcionDTO inscripcion);
        bool Exists(InscripcionDTO inscripcion);
        List<InscripcionDTO> ObtenerInscripciones();
        bool BorrarInscripcion(InscripcionDTO inscripcion);
    }
}
