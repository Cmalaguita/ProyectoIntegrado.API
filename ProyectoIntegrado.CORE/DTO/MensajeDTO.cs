using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
    class MensajeDTO
    {
       
        public int id { get; set; }
        public int alumnoId { get; set; }
        public Alumno alumno { get; set; }
        public int empresaId { get; set; }
        public Empresa empresa { get; set; }
        public string contenido { get; set; }
        public bool leido { get; set; }
    }
}
