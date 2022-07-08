using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Domain.Models
{
    public class Pc
    {
        public Guid pc_id { get; set; }
        public string modelo { get; set; }
        public Laboratorios lab_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
