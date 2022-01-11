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
    public class CicloController : ControllerBase
    {
        public ICicloBL cicloBL { get; set; }
       
        public CicloController(ICicloBL cicloBL)
        {
            this.cicloBL = cicloBL;
          
        }
       
        [HttpGet]
        [Route("Obtener_Todos_Los_Ciclos")]
        public List<CicloDTO> ObtenerCiclos()
        {
            return cicloBL.ObtenerCiclos();
        }
        [HttpGet]
        [Route("Buscar_Ciclo_Id")]
        public CicloDTO BuscarCicloId(int id)
        {
            return cicloBL.BuscarCicloId(id);
        }
        [HttpGet]
        [Route("Buscar_Ciclo_Nombre")]
        public CicloDTO BuscarCicloNombre(string nombre)
        {
            return cicloBL.BuscarCicloNombre(nombre);
        }
        [HttpGet]
        [Route("Obtener_Ciclos_Por_Familia")]

        public List<CicloDTO> ObtenerCiclosPorFamilia(int idFamilia)
        {
            return cicloBL.ObtenerCiclosPorFamilia(idFamilia);
        }

        [HttpGet]
        [Route("Obtener_Ciclos_Por_Tipo")]
        public List<CicloDTO> ObtenerCiclosPorTipo(int idTipo)
        {
            return cicloBL.ObtenerCiclosPorTipo(idTipo);
        }
        [HttpGet]
        [Route("Obtener_Ciclos_Por_Familia_Y_Tipo")]
        public List<CicloDTO> ObtenerCiclosPorFamiliaYTipo(int idTipo,int idFamilia)
        {
            return cicloBL.ObtenerCiclosPorFamiliaYTipo(idTipo,idFamilia);
        }
    }
}
