using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {

        public IInscripcionBL inscripcionBL { get; set; }
        public InscripcionController(IInscripcionBL inscripcionBL)
        {
            this.inscripcionBL = inscripcionBL;
        }

        [HttpGet]
        [Route("Obtener_Inscripciones_Por_Familia")]
        public List<InscripcionDTO> ObtenerInscripcionesPorFamilia(int id)
        {
            return inscripcionBL.ObtenerInscripcionesPorFamilia(id);
        }
        [HttpGet]
        [Route("Obtener_Inscripciones_Por_Ciclo")]
        public List<InscripcionDTO> ObtenerInscripcionesPorCiclo(int id)
        {
            return inscripcionBL.ObtenerInscripcionesPorCiclo(id);
        }

        [HttpGet]
        [Route("Obtener_Inscripciones_Por_Empresa")]
        public List<InscripcionDTO> ObtenerInscripcionesPorEmpresa(int id)
        {
            return inscripcionBL.ObtenerInscripcionesPorEmpresa(id);
        }
        [HttpGet]
        [Route("Obtener_Inscripciones_Por_Alumno")]
        public List<InscripcionDTO> ObtenerInscripcionesPorAlumno(int id)
        {
            return inscripcionBL.ObtenerInscripcionesPorAlumno(id);
        }
        [HttpPost]
        [Route("Crear_Inscripcion")]
        public InscripcionDTO CreateInscripcion(CrearInscripcionDTO inscripcion)
        {
            return inscripcionBL.CreateInscripcion(inscripcion);
        }
        [HttpPost]
        [Route("Actualizar_Inscripcion")]
        public InscripcionDTO UpdateInscripcion(UpdateInscripcionDTO i)
        {
            return inscripcionBL.UpdateInscripcion(i);
        }
        [HttpGet]
        [Route("Obtener_Todas_Las_Inscripciones_")]
        public List<InscripcionDTO> ObtenerInscripciones()
        {
            return inscripcionBL.ObtenerInscripciones();
        }
        [HttpDelete]
        [Route("Borrar_Inscripcion")]
        public bool BorrarInscripcion(int id)
        {
            return inscripcionBL.BorrarInscripcion(id);
        }
        [HttpGet]
        [Route("Comprobar_Existencia_Por_Alumno_Y_Posicion")]
        public bool ExistsPorAlumnoYPosicion(int idP, int idA)
        {
            return inscripcionBL.ExistsPorAlumnoYPosicion(idP, idA);
        }

        [HttpGet]
        [Route("Obtener_Inscripciones_Por_Posicion")]
        public List<InscripcionDTO> ObtenerInscripcionesPorPosicion(int idPosicion)
        {
            return inscripcionBL.ObtenerInscripcionesPorPosicion(idPosicion);
        }

        [HttpGet]
        [Route("Obtener_Alumnos_Inscritos_Por_Posicion")]
        public List<AlumnoDTO> ObtenerAlumnosEnInscripcionPorPosicion(int idPosicion)
        {
            return inscripcionBL.ObtenerAlumnosEnInscripcionPorPosicion(idPosicion);
        }
       
    }
}

