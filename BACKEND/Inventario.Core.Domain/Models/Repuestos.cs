using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Domain.Models
{
    public class Repuestos
    {
        public Guid repuesto_id { get; set; }
        public string nombre { get; set; }
        public string serie { get; set; }
        public string estado { get; set; }
        public int cantidad { get; set; }
        public string info { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
