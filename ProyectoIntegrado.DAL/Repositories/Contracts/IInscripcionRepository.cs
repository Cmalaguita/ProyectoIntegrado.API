using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
    interface IInscripcionRepository
    {
        Inscripcion CreateInscripcion(Inscripcion inscripcion);
        bool Exists(Inscripcion inscripcion);
        List<Inscripcion> ObtenerInscripciones();
        bool BorrarInscripcion(Inscripcion inscripcion);
    }
}
