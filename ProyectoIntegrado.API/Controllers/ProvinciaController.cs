using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        public IProvinciaBL provinciaBL { get; set; }
        public ProvinciaController(IProvinciaBL provinciaBL)
        {
            this.provinciaBL = provinciaBL;
        }
        [HttpGet]
        [Route("Obtener_Todas_Las_Provincias")]
      public List<ProvinciaDTO> ObtenerProvincias()
        {
            return provinciaBL.ObtenerProvincias();
        }
        [HttpGet]
        [Route("Buscar_Provincia_Nombre")]
        public ProvinciaDTO BuscarProvinciaNombre(String nombre)
        {
            return provinciaBL.BuscarProvinciaNombre(nombre);
        }

        [HttpGet]
        [Route("Buscar_Provincia_Id")]
        public ProvinciaDTO BuscarProvinciaId(int id)
        {
            return provinciaBL.BuscarProvinciaId(id);
        }

    }
}
