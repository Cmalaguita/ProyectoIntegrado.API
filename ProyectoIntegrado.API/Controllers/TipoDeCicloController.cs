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
    public class TipoDeCicloController : ControllerBase
    {
      
        public ITipoDeCicloBL tipoDeCicloBL { get; set; }
       
        public TipoDeCicloController(ITipoDeCicloBL tipoDeCicloBL)
        {
           
            this.tipoDeCicloBL = tipoDeCicloBL;
            
        }
        
        [HttpGet]
        [Route("Obtener_Todos_Los_Tipos_De_Ciclo")]
        public List<TipoDeCicloDTO> ObtenerTiposDeCiclos()
        {
            return tipoDeCicloBL.ObtenerTiposDeCiclos();
        }
        [HttpGet]
        [Route("Buscar_Tipo_De_Ciclo_Id")]
        public TipoDeCicloDTO BuscarTipoDeCicloId(int id)
        {
            return tipoDeCicloBL.BuscarTipoDeCicloId(id);
        }
    }
}
