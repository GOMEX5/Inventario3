using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Domain.Models
{
    public class Diagnostico_Pc
    {
        public Guid diagnostico_pc_id { get; set; }
        public Pc Pc { get; set; } = null!  ;
        public string detalle { get; set; }
        public string estado { get; set; }
        public DateTime fecha_hora { get; set; }
        public string soluccion_asignada { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
