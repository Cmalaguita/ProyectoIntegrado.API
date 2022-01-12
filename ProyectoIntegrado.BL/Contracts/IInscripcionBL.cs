using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IInscripcionBL
    {
        InscripcionDTO CreateInscripcion(CrearInscripcionDTO inscripcion);
        bool Exists(int id);
        List<InscripcionDTO> ObtenerInscripciones();
        List<InscripcionDTO> ObtenerInscripcionesPorFamilia(int id);
        List<InscripcionDTO> ObtenerInscripcionesPorCiclo(int id);
        List<InscripcionDTO> ObtenerInscripcionesPorEmpresa(int id);
        List<InscripcionDTO> ObtenerInscripcionesPorAlumno(int id);
        List<InscripcionDTO> ObtenerInscripcionesPorPosicion(int idPosicion);
        List<AlumnoDTO> ObtenerAlumnosEnInscripcionPorPosicion(int idPosicion);
        InscripcionDTO ExistsPorAlumnoYPosicion(int idP, int idA);
        bool BorrarInscripcion(int id);
        InscripcionDTO UpdateInscripcion(UpdateInscripcionDTO i);
    }
}
