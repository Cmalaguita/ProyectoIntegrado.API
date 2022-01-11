using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
    public interface IInscripcionRepository
    {
        Inscripcion CreateInscripcion(Inscripcion inscripcion);
        bool Exists(int id);
        List<Inscripcion> ObtenerInscripciones();
        List<Inscripcion> ObtenerInscripcionesPorFamilia(int id);
        bool ExistsPorAlumnoYPosicion(int idP, int idA);
        List<Inscripcion> ObtenerInscripcionesPorCiclo(int id);
        List<Inscripcion> ObtenerInscripcionesPorAlumno(int id);
        List<Inscripcion> ObtenerInscripcionesPorPosicion(int idPosicion);
        List<Alumno> ObtenerAlumnosEnInscripcionPorPosicion(int idPosicion);
        List<Inscripcion> ObtenerInscripcionesPorEmpresa(int id);
        bool BorrarInscripcion(int id);
        Inscripcion UpdateInscripcion(Inscripcion i);
    }
}
