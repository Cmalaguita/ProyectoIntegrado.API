using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    public class Factura
    {
        public int id { get; set; }
        public string url { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
