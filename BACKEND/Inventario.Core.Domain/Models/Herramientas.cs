using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Domain.Models
{
    public class Herramientas
    {
        public Guid herramienta_id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public int cantidad { get; set; }
        public Usuarios usuarios { get; set; } = null!;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
