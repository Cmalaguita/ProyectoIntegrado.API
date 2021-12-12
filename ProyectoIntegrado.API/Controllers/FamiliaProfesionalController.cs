using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.BL.Implementations;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaProfesionalController : ControllerBase
    {
        public IFamiliaProfesionalBL familiaProfesionalBL { get; set; }
        public FamiliaProfesionalController(IFamiliaProfesionalBL familiaProfesionalBL)
        {
             this.familiaProfesionalBL = familiaProfesionalBL;
        }
        // Comienza el controlador de FamiliaProfesional
        [HttpGet]
        [Route("Obtener_Todas_Las_Familias_Profesionales")]
        public  List<FamiliaProfesionalDTO> ObtenerFamiliasProfesionales()
        {
            return familiaProfesionalBL.ObtenerFamiliasProfesionales();
        }
        [HttpGet]
        [Route("Buscar_Familia_Profesional_Id")]
        public  FamiliaProfesionalDTO BuscarFamiliaProfesionalId(int id)
        {
            return familiaProfesionalBL.BuscarFamiliaProfesionalId(id);
        }
        // Termina el controlador de FamiliaProfesional

       
    }
}
